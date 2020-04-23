using Omega.Ots.Common.Message;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Omega.Ots.UI.Win.Functions
{
    public class Currency
    {
        public string Name { get; }
        public string Code { get; }
        public string CrossRateName { get; }
        public double ForexBuying { get; }
        public double ForexSelling { get; }
        public double BanknoteBuying { get; }
        public double BanknoteSelling { get; }

        public Currency(string name, string code, string crossRateName, double forexBuying, double forexSelling, double banknoteBuying, double banknoteSelling)
        {
            Name = name;
            Code = code;
            CrossRateName = crossRateName;
            ForexBuying = forexBuying;
            ForexSelling = forexSelling;
            BanknoteBuying = banknoteBuying;
            BanknoteSelling = banknoteSelling;
        }
    }

    public class GetCurrencyRates
    {
        public static Dictionary<string, Currency> GetCurrencyRate(DateTime date)
        {
            int tryTimes = 0;

            Start:
            date = date.AddDays(-1);
            string SYear = String.Format("{0:0000}", date.Year);
            string SMonth = String.Format("{0:00}", date.Month);
            string SDay = String.Format("{0:00}", date.Day);

            Dictionary<string, Currency> ExchangeRates = new Dictionary<string, Currency>();
            string Link = "http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml";
            try
            {
                XmlTextReader rdr = new XmlTextReader(Link);
                // XmlTextReader nesnesini yaratıyoruz ve parametre olarak xml dokümanın urlsini veriyoruz
                // XmlTextReader urlsi belirtilen xml dokümanlarına hızlı ve forward-only giriş imkanı sağlar.
                XmlDocument myxml = new XmlDocument();
                // XmlDocument nesnesini yaratıyoruz.
                myxml.Load(rdr);
                // Load metodu ile xml yüklüyoruz
                XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
                XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
                XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
                XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
                XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
                XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
                XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
                XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");

                ExchangeRates.Add("TRY", new Currency("Türk Lirası", "TRY", "TRY/TRY", 1, 1, 1, 1));

                for (int i = 0; i < adi.Count; i++)
                {
                    Currency cur = new Currency(adi.Item(i).InnerText.ToString(),
                        kod.Item(i).InnerText.ToString(),
                        kod.Item(i).InnerText.ToString() + "/TRY",
                        (String.IsNullOrWhiteSpace(doviz_alis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDouble(doviz_alis.Item(i).InnerText.ToString().Replace(",", ".")),
                        (String.IsNullOrWhiteSpace(doviz_satis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDouble(doviz_satis.Item(i).InnerText.ToString().Replace(",", ".")),
                        (String.IsNullOrWhiteSpace(efektif_alis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDouble(efektif_alis.Item(i).InnerText.ToString().Replace(",", ".")),
                        (String.IsNullOrWhiteSpace(efektif_satis.Item(i).InnerText.ToString())) ? 0 : Convert.ToDouble(efektif_satis.Item(i).InnerText.ToString().Replace(",", "."))
                        );

                    ExchangeRates.Add(kod.Item(i).InnerText.ToString(), cur);
                }

                return ExchangeRates;
            }
            catch (Exception ex)
            {
                tryTimes++;
                if (tryTimes < 10)
                    goto Start;

                Messages.HataMesaji(
                    "Belirtilen tarihden önce 10 gün kontrol edildi, Tcmb sitesinde kur bulunamadı" +
                    "\nİnternetinizde problem olabilir veya bu tarihler resmi tatil olabilir" +
                    "\nİlgili tarihe son günün kurlarını kopyalayabilirsiniz."
                    );
                return ExchangeRates;
                throw ex;
            }
        }
    }
}