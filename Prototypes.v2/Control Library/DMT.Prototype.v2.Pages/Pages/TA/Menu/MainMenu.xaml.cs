﻿#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

#endregion

namespace DMT.Pages.TA
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();

            InitPlazaFund();
        }

        #endregion

        private Models.FundEntry plaza = new Models.FundEntry();

        private void InitPlazaFund()
        {
            plaza.Description = "เงินยืม-ทอน (ด่าน)";
            plaza.BHT1 = 890;
            plaza.BHT2 = 910;
            plaza.BHT5 = 870;
            plaza.BHT10c = 410;
            plaza.BHT20 = 130;
            plaza.BHT50 = 82;
            plaza.BHT100 = 125;
            plaza.BHT500 = 58;
            plaza.BHT1000 = 85;


            plaza.EXCHANGE = 10000;
            plaza.BORROW = 20000;
            plaza.REVOLVINGFUNDS = 0;

            plaza.HasRemark = false;
        }

        #region Button (Menu) Command Handlers

        private void exchangeBankNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Exchange Fund Page.
                var page = new Pages.TA.Exchange.PlazaRequestExchangePage();

                BindingList<Models.FundExchange> items = new BindingList<Models.FundExchange>();

                Models.LoanMoneyEntry loan = new Models.LoanMoneyEntry();
                loan.Description = "รายละเอียด";
                loan.RevolvingFunds = 150000;
                loan.LoanMoney = 42000;
                loan.LoanMoneyCabinet = 47640;

                page.Setup(plaza, items, loan);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void plazaReceivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Old
                /*
                // Plaza Coupon Received
                var page = new TA.Plaza.PlazaCouponReceivedReturnPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Count = 10;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 15, 08, 50, 21);
                coupon.StaffId = "14124";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Count = 20;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 09, 10, 42);
                coupon.StaffId = "14211";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Count = 15;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
                */
                #endregion

                var page = new DMT.Pages.TA.Coupon.CouponReturnPage();

                List<Models.Coupon35> coupons = new List<Models.Coupon35>();
                List<Models.CouponUser35> couponUs = new List<Models.CouponUser35>();
                List<Models.Coupon80> coupons80 = new List<Models.Coupon80>();
                List<Models.CouponUser80> couponsU80 = new List<Models.CouponUser80>();

                Models.Coupon35 coupon;

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635001";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635002";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635003";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635004";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635005";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635006";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635007";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635008";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635009";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635010";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635011";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635012";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635013";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635014";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635015";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635016";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635017";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635018";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635019";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635020";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635021";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635022";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635023";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635024";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635025";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635026";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635027";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635028";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635029";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635030";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635031";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635032";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635033";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635034";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635035";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635036";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635037";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635038";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635039";
                coupons.Add(coupon);

                coupon = new Models.Coupon35();
                coupon.CouponCode = "ข635040";
                coupons.Add(coupon);

                /*
                Models.CouponUser35 coupon35;

                coupon35 = new Models.CouponUser35();
                coupon35.CouponCode = "ข635009";
                couponUs.Add(coupon35);

                coupon35 = new Models.CouponUser35();
                coupon35.CouponCode = "ข635010";
                couponUs.Add(coupon35);

                coupon35 = new Models.CouponUser35();
                coupon35.CouponCode = "ข635019";
                couponUs.Add(coupon35);
                */

                Models.Coupon80 coupon80;
                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635010";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635011";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635012";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635013";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635014";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635015";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635016";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635017";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635018";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635019";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635020";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635021";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635022";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635023";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635024";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635025";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635026";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635027";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635028";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635029";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635030";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635031";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635032";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635033";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635034";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635035";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635036";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635037";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635038";
                coupons80.Add(coupon80);

                coupon80 = new Models.Coupon80();
                coupon80.CouponCode = "C635039";
                coupons80.Add(coupon80);

                /*
                Models.CouponUser80 cop80;

                cop80 = new Models.CouponUser80();
                cop80.CouponCode = "C635014";
                couponsU80.Add(cop80);

                cop80 = new Models.CouponUser80();
                cop80.CouponCode = "C635015";
                couponsU80.Add(cop80);

                cop80 = new Models.CouponUser80();
                cop80.CouponCode = "C635018";
                couponsU80.Add(cop80);
                */

                page.Setup(coupons, couponUs, coupons80, couponsU80);
                PageContentManager.Instance.Current = page;

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void refundBankNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Plaza Fund Received
                var page = new TA.Plaza.PlazaReceivedReturnPage();

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;
                fund = new Models.FundEntry();
                fund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                fund.StaffId = "14055";
                fund.StaffName = "นางวิภา สวัสดิวัฒน์";
                fund.ListType = "ยืม";

                fund.BHT1 = 890;
                fund.BHT2 = 910;
                fund.BHT5 = 870;
                fund.BHT10c = 410;
                fund.BHT20 = 130;
                fund.BHT50 = 82;
                fund.BHT100 = 125;
                fund.BHT500 = 58;
                fund.BHT1000 = 85;

                funds.Add(fund);

                Models.LoanMoneyEntry loan  = new Models.LoanMoneyEntry();
                loan.Description = "รายละเอียด";
                loan.RevolvingFunds = 150000;
                loan.LoanMoney = 42000;
                loan.LoanMoneyCabinet = 47640;

                page.Setup(fund, loan, funds);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void plazaAllCoupon_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void exchangeMoney_Click(object sender, RoutedEventArgs e)
        {
            var page = new TA.Plaza.PlazaReceivedFundReturnPage();

            BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
            Models.FundEntry fund;
            fund = new Models.FundEntry();
            fund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
            fund.StaffId = "14055";
            fund.StaffName = "นางวิภา สวัสดิวัฒน์";
            fund.ListType = "ยืม";
            fund.BHT1 = 890;
            fund.BHT2 = 910;
            fund.BHT5 = 870;
            fund.BHT10c = 410;
            fund.BHT20 = 130;
            fund.BHT50 = 82;
            fund.BHT100 = 125;
            fund.BHT500 = 58;
            fund.BHT1000 = 85;

            funds.Add(fund);

            Models.LoanMoneyEntry loan = new Models.LoanMoneyEntry();
            loan.Description = "รายละเอียด";
            loan.RevolvingFunds = 150000;
            loan.LoanMoney = 42000;
            loan.LoanMoneyCabinet = 47640;

            page.Setup(fund, loan, funds);

            PageContentManager.Instance.Current = page;
        }

        private void collectorFundReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var page = new TA.Reports.CollectorFundSummaryReportPage();
                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorFund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var page = new TA.Collector.CollectorFundViewPage();

                Models.FundEntry plazaFund = new Models.FundEntry();
                plazaFund.Description = "เงินยืม-ทอน (ด่าน)";
                plazaFund.HasRemark = false;

                plazaFund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                plazaFund.StaffId = "14055";
                plazaFund.BHT1 = 890;
                plazaFund.BHT2 = 910;
                plazaFund.BHT5 = 870;
                plazaFund.BHT10c = 410;
                plazaFund.BHT20 = 130;
                plazaFund.BHT50 = 82;
                plazaFund.BHT100 = 125;
                plazaFund.BHT500 = 58;
                plazaFund.BHT1000 = 85;

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;
                // Collector 1
                fund = new Models.FundEntry();
                fund.Description = "นาย สุเทพ เหมัน";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.BagNo = "301";
                fund.StaffId = "14321";
                fund.StaffName = fund.Description;
                fund.BeltNo = "10";
                fund.Side = "ขาเข้า";
                fund.Lane = 1;
                fund.BHT1 = 50;
                fund.BHT2 = 50;
                fund.BHT5 = 40;
                fund.BHT10c = 20;
                fund.BHT20 = 10;
                fund.BHT50 = 5;
                fund.BHT100 = 18;
                fund.BHT500 = 10;
                fund.BHT1000 = 5;
                funds.Add(fund);

                // Collector 2
                fund = new Models.FundEntry();
                fund.Description = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.BagNo = "302";
                fund.StaffId = "13201";
                fund.StaffName = fund.Description;
                fund.BeltNo = "18";
                fund.Side = "ขาเข้า";
                fund.Lane = 4;
                fund.BHT1 = 20;
                fund.BHT2 = 15;
                fund.BHT5 = 60;
                fund.BHT10c = 45;
                fund.BHT20 = 45;
                fund.BHT50 = 5;
                fund.BHT100 = 24;
                fund.BHT500 = 10;
                fund.BHT1000 = 5;
                funds.Add(fund);

                // Collector 3
                fund = new Models.FundEntry();
                fund.Description = "นางวิภา สวัสดิวัฒน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.BagNo = "789";
                fund.StaffId = "11559";
                fund.StaffName = fund.Description;
                fund.BeltNo = "19";
                fund.Side = "ขาออก";
                fund.Lane = 8;
                fund.BHT1 = 20;
                fund.BHT2 = 15;
                fund.BHT5 = 20;
                fund.BHT10c = 20;
                fund.BHT20 = 10;
                fund.BHT50 = 3;
                fund.BHT100 = 21;
                fund.BHT500 = 14;
                fund.BHT1000 = 2;
                funds.Add(fund);

                // Collector 4
                fund = new Models.FundEntry();
                fund.Description = "นาย ภักดี อมรรุ่งโรจน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.BagNo = "415";
                fund.StaffId = "12866";
                fund.StaffName = fund.Description;
                fund.BeltNo = "45";
                fund.Side = "ขาออก";
                fund.Lane = 5;
                fund.BHT1 = 0;
                fund.BHT2 = 0;
                fund.BHT5 = 0;
                fund.BHT10c = 0;
                fund.BHT20 = 0;
                fund.BHT50 = 0;
                fund.BHT100 = 0;
                fund.BHT500 = 0;
                fund.BHT1000 = 0;
                funds.Add(fund);

                // Collector 5
                fund = new Models.FundEntry();
                fund.Description = "นาย สุเทพ เหมัน";
                fund.Date = new DateTime(2020, 3, 17, 12, 05, 00);
                fund.BagNo = "521";
                fund.StaffId = "14321";
                fund.StaffName = fund.Description;
                fund.BeltNo = "72";
                fund.Side = "ขาออก";
                fund.Lane = 2;
                fund.BHT1 = 20;
                fund.BHT2 = 10;
                fund.BHT5 = 10;
                fund.BHT10c = 5;
                fund.BHT20 = 5;
                fund.BHT50 = 5;
                fund.BHT100 = 12;
                fund.BHT500 = 8;
                fund.BHT1000 = 3;
                funds.Add(fund);

                Models.LoanMoneyEntry loan = new Models.LoanMoneyEntry();
                loan.Description = "รายละเอียด";
                loan.RevolvingFunds = 150000;
                loan.LoanMoney = 42000;
                loan.LoanMoneyCabinet = 47640;

                page.Setup(plazaFund, funds, loan);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorReveivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Coupon Return
                var page = new TA.Coupon.ReceivedCouponPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Lane = 6;
                coupon.Count = 5;
                coupon.Count80 = 10;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = "14147";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Lane = 2;
                coupon.Count = 4;
                coupon.Count80 = 5;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = "12562";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Lane = 4;
                coupon.Count = 9;
                coupon.Count80 = 3;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void changeBorrowingHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void collectorReturnCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Coupon Return
                var page = new TA.Coupon.ReturnCouponPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Lane = 6;
                coupon.Count = 10;
                coupon.Count80 = 5;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = "14147";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Lane = 2;
                coupon.Count = 7;
                coupon.Count80 = 3;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = "12562";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Lane = 4;
                coupon.Count = 8;
                coupon.Count80 = 2;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void plazaAllStock_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.TA.Plaza.PlazaStockWindow();
            win.Owner = Application.Current.MainWindow;

            Models.FundEntry fund = new Models.FundEntry();
            fund.Description = "เงินยืมทอน";
            fund.HasRemark = false;
            fund.BHT1 = 890;
            fund.BHT2 = 910;
            fund.BHT5 = 870;
            fund.BHT10c = 410;
            fund.BHT20 = 130;
            fund.BHT50 = 82;
            fund.BHT100 = 125;
            fund.BHT500 = 58;
            fund.BHT1000 = 85;

            Models.CouponEntry coupon = new Models.CouponEntry();
            coupon.Description = "คุปอง";
            coupon.BHT35 = 32;
            coupon.BHT80 = 43;

            Models.LoanMoneyEntry loan = new Models.LoanMoneyEntry();
            loan.Description = "รายละเอียด";
            loan.RevolvingFunds = 150000;
            loan.LoanMoney = 42000;
            loan.LoanMoneyCabinet = 47640;


            win.Setup(fund, coupon, loan);

            if (win.ShowDialog() == false)
            {
                return;
            }
            try
            {

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.Current = new TA.SignInPage();
        }

        // ไม่ได้ใช้
        #region No Use
        //private void plazaReceivedReturnFund_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        // Plaza Fund Received
        //        var page = new TA.Plaza.PlazaFundReceivedReturnPage();

        //        BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
        //        Models.FundEntry fund;

        //        fund = new Models.FundEntry();
        //        fund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
        //        fund.StaffId = "14055";
        //        fund.StaffName = "นางวิภา สวัสดิวัฒน์";
        //        fund.BHT1 = 10;
        //        fund.BHT2 = 10;
        //        fund.BHT5 = 10;
        //        fund.BHT10c = 10;
        //        fund.BHT20 = 10;
        //        fund.BHT50 = 10;
        //        fund.BHT100 = 10;
        //        fund.BHT500 = 10;
        //        fund.BHT1000 = 10;
        //        funds.Add(fund);

        //        page.Setup(plaza, funds);

        //        PageContentManager.Instance.Current = page;
        //    }
        //    catch (Exception)
        //    {
        //        //Console.WriteLine("Refresh data error.");
        //    }
        //}

        #endregion

        #endregion

    }
}
