﻿using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Omega.Ots.Common.Enums;
using Omega.Ots.Common.Functions;
using Omega.Ots.Model.Dto;
using Omega.Ots.Model.Entities;
using Omega.Ots.UI.Win.Forms.BankaForms;
using Omega.Ots.UI.Win.Forms.BankaHesapForms;
using Omega.Ots.UI.Win.Forms.BankaSubeForms;
using Omega.Ots.UI.Win.Forms.KasaForms;
using Omega.Ots.UI.Win.Forms.SchoolForms;
using Omega.Ots.UI.Win.Forms.YakinlikForms;
using Omega.Ots.UI.Win.IptalNedeniForms;
using Omega.Ots.UI.Win.Show;

namespace Omega.Ots.UI.Win.Functions
{
    public static class SelectRepositoryFunctions
    {
        #region Variables
        private static GridView _tablo;
        private static ControlNavigator _navigator;
        private static RepositoryItemButtonEdit _buttonEdit;
        private static GridColumn _idColumn;
        private static GridColumn _nameColumn;
        private static GridColumn _prmIdColumn;
        private static GridColumn _prmNameColumn;
        #endregion

        private static void RemoveEvent()
        {
            if (_buttonEdit == null) return;

            _buttonEdit.ButtonClick -= ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown -= ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick -= ButtonEdit_DoubleClick;
            _tablo.KeyDown -= Tablo_KeyDown;
        }

        public static void Sec(this GridColumn nameColumn, GridView tablo, ControlNavigator navigator, RepositoryItemButtonEdit buttonEdit, GridColumn idColumn)
        {
            RemoveEvent();
            _tablo = tablo;
            _navigator = navigator;
            _buttonEdit = buttonEdit;
            _idColumn = idColumn;
            _nameColumn = nameColumn;

            _buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown += ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick += ButtonEdit_DoubleClick;
            _tablo.KeyDown += Tablo_KeyDown;
        }

        public static void Sec(this GridColumn nameColumn, GridView tablo, ControlNavigator navigator, RepositoryItemButtonEdit buttonEdit, GridColumn idColumn, GridColumn prmIdColumn, GridColumn prmNameColumn)
        {
            RemoveEvent();
            _tablo = tablo;
            _navigator = navigator;
            _buttonEdit = buttonEdit;
            _idColumn = idColumn;
            _nameColumn = nameColumn;
            _prmIdColumn = prmIdColumn;
            _prmNameColumn = prmNameColumn;

            _buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown += ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick += ButtonEdit_DoubleClick;
            _tablo.KeyDown += Tablo_KeyDown;
        }

        private static void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap();
        }

        private static void ButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when e.Control && e.Shift:
                    _tablo.SetFocusedRowCellValue(_idColumn, null);
                    _tablo.SetFocusedRowCellValue(_nameColumn, null);
                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    break;
                case Keys.F4:
                case Keys.Down when e.Alt:
                    SecimYap();
                    break;
            }
        }

        private static void ButtonEdit_DoubleClick(object sender, EventArgs e)
        {
            SecimYap();

        }

        private static void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (_tablo.FocusedColumn.ColumnEdit == null) return;

            var type = _tablo.FocusedColumn.ColumnEdit.GetType();
            if (type != typeof(RepositoryItemButtonEdit)) return;

            switch (e.KeyCode)
            {
                case Keys.Delete when e.Control && e.Shift:
                    _tablo.SetFocusedRowCellValue(_idColumn, null);
                    _tablo.SetFocusedRowCellValue(_nameColumn, null);
                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    break;
                case Keys.F4:
                case Keys.Down when e.Alt:
                    SecimYap();
                    break;
            }
        }

        private static void SecimYap()
        {
            switch (_buttonEdit.Name)
            {
                case "repositoryYakinlik":
                    {

                        var id = _tablo.GetRowCellId(_idColumn);

                        var entity = (Yakinlik)ShowListForms<YakinlikListForm>.ShowDialogListForm(KartTuru.Yakinlik, id);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.YakinlikAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryBanka":
                    {
                        if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);

                        var entity = (BankaL)ShowListForms<BankaListForm>.ShowDialogListForm(KartTuru.Banka, id);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.BankaAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryBankaSube":
                    {
                        if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);
                        var bankaId = _tablo.GetRowCellId(_prmIdColumn);
                        var bankaAdi = _tablo.GetFocusedRowCellValue(_prmNameColumn).ToString();

                        var entity = (BankaSube)ShowListForms<BankaSubeListForm>.ShowDialogListForm(KartTuru.BankaSube, id, bankaId, bankaAdi);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.SubeAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryBankaHesap":
                    {
                        if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);
                        var odemeTipi = _tablo.GetFocusedRowCellValue("OdemeTipi").ToString().GetEnum<OdemeTipi>();

                        var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, id, odemeTipi);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.HesapAdi);
                            _tablo.SetFocusedRowCellValue("BlokeGunSayisi", entity.BlokeGunSayisi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryIptalNedeni":
                    {
                        if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);

                        var entity = (IptalNedeni)ShowListForms<IptalNedeniListForm>.ShowDialogListForm(KartTuru.IptalNedeni, id);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.IptalNedeniAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryGittigiOKul":
                    {
                        if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);

                        var entity = (OkulL)ShowListForms<OkulListForm>.ShowDialogListForm(KartTuru.Okul, id);
                        if (entity != null)
                        {
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.OkulAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }
                    }
                    break;

                case "repositoryHesap":
                    {

                        var id = _tablo.GetRowCellId(_idColumn);

                        switch (_tablo.GetRow<GeriOdemeBilgileriL>().HesapTuru)
                        {
                            case GeriOdemeHesapTuru.Banka:
                                {
                                    var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, id, OdemeTipi.Elden);

                                    if (entity == null) return;
                                    _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                                    _tablo.SetFocusedRowCellValue(_nameColumn, entity.HesapAdi);
                                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                                    break;
                                }

                            case GeriOdemeHesapTuru.Kasa:
                                {
                                    var entity = (KasaL)ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, id);
                                    if (entity == null) return;
                                    _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                                    _tablo.SetFocusedRowCellValue(_nameColumn, entity.KasaAdi);
                                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

    }
}
