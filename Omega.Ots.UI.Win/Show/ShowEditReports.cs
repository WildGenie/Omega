using Omega.Ots.Common.Enums;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Reports.FormReports.Base;
using System;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.Show
{
    public class ShowEditReports<TForm> where TForm : BaseRapor
    {
        public static void ShowEditReport(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();
        }
    }
}