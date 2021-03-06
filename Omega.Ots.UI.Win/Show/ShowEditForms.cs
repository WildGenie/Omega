﻿using Omega.Ots.Common.Enums;
using Omega.Ots.Model.Entities.Base.Interfaces;
using Omega.Ots.UI.Win.Forms.BaseForms;
using Omega.Ots.UI.Win.Functions;
using Omega.Ots.UI.Win.Show.Interfaces;
using System;
using System.Windows.Forms;

namespace Omega.Ots.UI.Win.Show
{
    public class ShowEditForms<TForm> : IBaseFormShow where TForm : BaseEditForm //Interfaces gelecek
    {

        public long ShowDialogEditForms(KartTuru kartTuru, long id)
        {
            if (!Functions.GeneralFunctions.EditFormYetkiKontrolu(id, kartTuru)) return 0;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;
            }
        }

        public static long ShowDialogEditForms(KartTuru kartTuru, long id, params object[] prm)
        {
            if (!Functions.GeneralFunctions.EditFormYetkiKontrolu(id, kartTuru)) return 0;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;
            }
        }

        public static long ShowDialogEditForms(long id, params object[] prm)
        {

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;
            }
        }

        public static void ShowDialogEditForms(long? id, params object[] prm)
        {

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                frm.ShowDialog();
            }
        }

        public static bool ShowDialogEditForms(params object[] prm)
        {
            //Yetki kontrolü yapılacak
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                return frm.DialogResult == DialogResult.OK;
            }
        }

        public static bool ShowDialogEditForms(KartTuru kartTuru, params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return false;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                frm.ShowDialog();
                return frm.DialogResult == DialogResult.OK;
            }
        }

        public static void ShowDialogEditForms(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = IslemTuru.EntityUpdate;
                frm.Yukle();
                frm.ShowDialog();
            }
        }

        public static void ShowDialogEditForms()
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.Yukle();
                frm.ShowDialog();
            }
        }

        public static bool ShowDialogEditForms(IslemTuru islemTuru, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = IslemTuru.EntityUpdate;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak;
            }
        }

        public static T ShowDialogEditForms<T>(params object[] prm) where T : IBaseEntity
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {

                frm.Yukle();
                frm.ShowDialog();
                return (T)frm.ReturnEntity();
            }
        }

    }
}