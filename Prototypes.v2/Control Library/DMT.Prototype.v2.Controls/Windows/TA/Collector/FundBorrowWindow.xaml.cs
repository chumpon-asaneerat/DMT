﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Windows.TA.Collector
{
    /// <summary>
    /// Interaction logic for FundBorrowWindow.xaml
    /// </summary>
    public partial class FundBorrowWindow : Window
    {
        public FundBorrowWindow()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void Setup(Models.FundEntry plaza, Models.FundEntry src, 
            Models.FundEntry fund, Models.FundEntry result, bool isNew = false)
        {
            if (isNew)
            {
                //infoPanel.Visibility = Visibility.Visible;
                infoPanel.IsEnabled = true;
            }
            else
            {
                //infoPanel.Visibility = Visibility.Collapsed;
                infoPanel.IsEnabled = false;
            }

            if (null != this.Fund) this.Fund.PropertyChanged -= Fund_PropertyChanged;

            this.Plaza = plaza;
            this.Source = src;
            this.Fund = fund;
            this.Result = result;

            if (null != this.Fund) this.Fund.PropertyChanged += Fund_PropertyChanged;

            //this.plazaEntry.DataContext = this.Plaza;
            this.srcEntry.DataContext = this.Source;
            this.usrEntry.DataContext = this.Fund;
            this.sumEntry.DataContext = this.Result;
           
            if (null != this.Fund)
            {
                txtStaffId.Text = this.Source.StaffId;
                txtName.Text = this.Source.StaffName;
                txtBagNo.Text = this.Source.BagNo;

                if (!string.IsNullOrEmpty(this.Source.BeltNo))
                {
                    txtBeltNo.Text = this.Source.BeltNo;
                }
                else if (string.IsNullOrEmpty(this.Source.BeltNo))
                {
                    if (txtBeltNo.IsEnabled == false)
                    {
                        var rand = new Random();
                        int num = rand.Next(1000);
                        txtBeltNo.Text = num.ToString("#,##0");
                    }
                }

                cbSide.Text = this.Source.Side;
            }

            UpdateResult();
        }

        private void UpdateResult()
        {
            if (null == this.Source || null == this.Fund || null == this.Result) return;
            /*
            this.Result.BHT1 = this.Source.BHT1 + this.Fund.BHT1;
            this.Result.BHT2 = this.Source.BHT2 + this.Fund.BHT2;
            this.Result.BHT5 = this.Source.BHT5 + this.Fund.BHT5;
            this.Result.BHT10c = this.Source.BHT10c + this.Fund.BHT10c;
            this.Result.BHT20 = this.Source.BHT20 + this.Fund.BHT20;
            this.Result.BHT50 = this.Source.BHT50 + this.Fund.BHT50;
            this.Result.BHT100 = this.Source.BHT100 + this.Fund.BHT100;
            this.Result.BHT500 = this.Source.BHT500 + this.Fund.BHT500;
            this.Result.BHT1000 = this.Source.BHT1000 + this.Fund.BHT1000;
            */
            this.Result.BHT1 = this.Plaza.BHT1 - this.Fund.BHT1;
            this.Result.BHT2 = this.Plaza.BHT2 - this.Fund.BHT2;
            this.Result.BHT5 = this.Plaza.BHT5 - this.Fund.BHT5;
            this.Result.BHT10c = this.Plaza.BHT10c - this.Fund.BHT10c;
            this.Result.BHT20 = this.Plaza.BHT20 - this.Fund.BHT20;
            this.Result.BHT50 = this.Plaza.BHT50 - this.Fund.BHT50;
            this.Result.BHT100 = this.Plaza.BHT100 - this.Fund.BHT100;
            this.Result.BHT500 = this.Plaza.BHT500 - this.Fund.BHT500;
            this.Result.BHT1000 = this.Plaza.BHT1000 - this.Fund.BHT1000;
        }

        private void Fund_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateResult();
        }

        public Models.FundEntry Plaza { get; private set; }
        public Models.FundEntry Source { get; private set; }
        public Models.FundEntry Fund { get; private set; }
        public Models.FundEntry Result { get; private set; }

        public Models.LoanMoneyEntry Loan { get; private set; }

        public string StaffId { get { return txtStaffId.Text; } }
        public string CollectorName { get { return txtName.Text; } }

        public string Side { get { return cbSide.Text; } }
    }
}
