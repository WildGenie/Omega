using System.ComponentModel;

namespace Omega.Ots.Common.Enums
{
    public enum TcmbDovizKodu : byte
    {
        [Description(" - ")]
        Bos = 0,
        [Description("TRY")]
        TRY = 1,
        [Description("USD")]
        USD = 2,
        [Description("AUD")]
        AUD = 3,
        [Description("DKK")]
        DKK = 4,
        [Description("EUR")]
        EUR = 5,
        [Description("GBP")]
        GBP = 6,
        [Description("CHF")]
        CHF = 7,
        [Description("SEK")]
        SEK = 8,
        [Description("CAD")]
        CAD = 9,
        [Description("KWD")]
        KWD = 10,
        [Description("NOK")]
        NOK = 11,
        [Description("SAR")]
        SAR = 12,
        [Description("JPY")]
        JPY = 13,
        [Description("BGN")]
        BGN = 14,
        [Description("RON")]
        RON = 15,
        [Description("RUB")]
        RUB = 16,
        [Description("IRR")]
        IRR = 17,
        [Description("CNY")]
        CNY = 18,
        [Description("PKR")]
        PKR = 19,
        [Description("QAR")]
        QAR = 20
    }
}