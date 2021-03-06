﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TA.Plaza
{
    /// <summary>
    /// Interaction logic for PlazaReceivedFundReturnPage.xaml
    /// </summary>
    public partial class PlazaReceivedFundReturnPage : UserControl
    {
        public PlazaReceivedFundReturnPage()
        {
            InitializeComponent();
        }

        private void ReturnFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 -= dst.BHT1;
            src.BHT2 -= dst.BHT2;
            src.BHT5 -= dst.BHT5;
            src.BHT10c -= dst.BHT10c;
            src.BHT20 -= dst.BHT20;
            src.BHT50 -= dst.BHT50;
            src.BHT100 -= dst.BHT100;
            src.BHT500 -= dst.BHT500;
            src.BHT1000 -= dst.BHT1000;

            src.EXCHANGE -= dst.EXCHANGE;
            src.BORROW -= dst.BORROW;
            src.REVOLVINGFUNDS -= dst.REVOLVINGFUNDS;
        }

        private void BorrowFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 += dst.BHT1;
            src.BHT2 += dst.BHT2;
            src.BHT5 += dst.BHT5;
            src.BHT10c += dst.BHT10c;
            src.BHT20 += dst.BHT20;
            src.BHT50 += dst.BHT50;
            src.BHT100 += dst.BHT100;
            src.BHT500 += dst.BHT500;
            src.BHT1000 += dst.BHT1000;

            src.EXCHANGE += dst.EXCHANGE;
            src.BORROW += dst.BORROW;
            src.REVOLVINGFUNDS += dst.REVOLVINGFUNDS;
        }

        private void assign(Models.FundEntry src, Models.FundEntry dst)
        {
            dst.BHT1 = src.BHT1;
            dst.BHT2 = src.BHT2;
            dst.BHT5 = src.BHT5;
            dst.BHT10c = src.BHT10c;
            dst.BHT20 = src.BHT20;
            dst.BHT50 = src.BHT50;
            dst.BHT100 = src.BHT100;
            dst.BHT500 = src.BHT500;
            dst.BHT1000 = src.BHT1000;

            dst.EXCHANGE = src.EXCHANGE;
            dst.BORROW = src.BORROW;
            dst.REVOLVINGFUNDS = src.REVOLVINGFUNDS;

        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdAppend_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.TA.Plaza.FundBorrowReturnWindow();
            win.Owner = Application.Current.MainWindow;

            Models.FundEntry srcObj = new Models.FundEntry();
            Models.FundEntry rcvObj = new Models.FundEntry();
            Models.FundEntry retObj = new Models.FundEntry();
            Models.FundEntry resObj = new Models.FundEntry();

            assign(_plaza, srcObj);

            srcObj.Description = "ยอดเงินยืม-ทอน (ด่าน)";
            srcObj.HasRemark = false;

            rcvObj.Description = "เงินขอแลกออก";

            retObj.Description = "เงินขอแลกเข้า";
            retObj.HasRemark = false;

            resObj.Description = "เงินขอแลกเข้า";
            resObj.HasRemark = false;

            resObj.DescriptionDetail = "รายละเอียด";


            win.Title = "แลกเงินหมุนเวียนภายในด่าน";
            win.Setup(srcObj, rcvObj, retObj, resObj,false);
            if (win.ShowDialog() == false)
            {
                return;
            }

            Models.FundEntry obj = new Models.FundEntry();

            obj.BHT1 = rcvObj.BHT1 - retObj.BHT1;
            obj.BHT2 = rcvObj.BHT2 - retObj.BHT2;
            obj.BHT5 = rcvObj.BHT5 - retObj.BHT5;
            obj.BHT10c = rcvObj.BHT10c - retObj.BHT10c;
            obj.BHT20 = rcvObj.BHT20 - retObj.BHT20;
            obj.BHT50 = rcvObj.BHT50 - retObj.BHT50;
            obj.BHT100 = rcvObj.BHT100 - retObj.BHT100;
            obj.BHT500 = rcvObj.BHT500 - retObj.BHT500;
            obj.BHT1000 = rcvObj.BHT1000 - retObj.BHT1000;

            obj.EXCHANGE = rcvObj.EXCHANGE - retObj.EXCHANGE;
            obj.BORROW = rcvObj.BORROW - retObj.BORROW;
            obj.REVOLVINGFUNDS = rcvObj.REVOLVINGFUNDS - retObj.REVOLVINGFUNDS;

            // Update plaza balance
            BorrowFund(_plaza, rcvObj);
            ReturnFund(_plaza, retObj);

            //if (obj.BHTTotal != decimal.Zero)
            {
                obj.StaffId = "14477";
                obj.StaffName = "นาย ศิริลักษณ์ วงษาหาร";
                obj.Date = DateTime.Now;
                _funds.Add(obj);
            }
        }

        private void UpdateBalance()
        {
            plazaBalance.Text = (_plaza.BHTTotal+_plaza.TOTALAMOUNT).ToString("n0");
        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundEntry> _funds;

        public void Setup(Models.FundEntry fund, Models.LoanMoneyEntry loan ,BindingList<Models.FundEntry> funds)
        {
            if (null != _plaza) _plaza.PropertyChanged -= _plaza_PropertyChanged;
            
            _plaza = fund;

            if (null != _plaza) _plaza.PropertyChanged += _plaza_PropertyChanged;

            plaza.IsEnabled = false;
            plaza.DataContext = _plaza; // bind plaza current fund.
            _plaza.HasRemark = false;

            loanEntry.IsEnabled = false;
            loanEntry.DataContext = loan; // bind plaza current fund.

            _funds = funds;

            this.plaza.DataContext = _plaza;
            this.grid.Setup(_plaza, _funds);

            txtDate.Text = (DateTime.Now == DateTime.MinValue) ? "" : DateTime.Now.ToThaiDateString() + " " + DateTime.Now.ToString("HH:mm");
            //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            UpdateBalance();


        }

        private void _plaza_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateBalance();
        }
    }
}
