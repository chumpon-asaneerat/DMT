﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Windows.TA.Collector
{
    /// <summary>
    /// Interaction logic for FundReturnWindow.xaml
    /// </summary>
    public partial class FundReturnWindow : Window
    {
        public FundReturnWindow()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.TA.Collector.MessageWindow();

            win.Setup(Description, Total);

            if (win.ShowDialog() == false)
            {
                return;
            }

            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void Setup(Models.FundEntry src, 
            Models.FundEntry fund, Models.FundEntry result)
        {
            if (null != this.Fund) this.Fund.PropertyChanged -= Fund_PropertyChanged;

            this.Source = src;
            this.Fund = fund;
            this.Result = result;

            if (null != this.Fund) this.Fund.PropertyChanged += Fund_PropertyChanged;

            this.srcEntry.DataContext = this.Source;
            this.usrEntry.DataContext = this.Fund;
            //this.sumEntry.DataContext = this.Result;


            txtDescription.Text = this.Source.StaffName;


            UpdateResult();
        }

        private void UpdateResult()
        {
            if (null == this.Source || null == this.Fund || null == this.Result) return;
            /*
            this.Result.BHT1 = this.Source.BHT1 - this.Fund.BHT1;
            this.Result.BHT2 = this.Source.BHT2 - this.Fund.BHT2;
            this.Result.BHT5 = this.Source.BHT5 - this.Fund.BHT5;
            this.Result.BHT10c = this.Source.BHT10c - this.Fund.BHT10c;
            this.Result.BHT20 = this.Source.BHT20 - this.Fund.BHT20;
            this.Result.BHT50 = this.Source.BHT50 - this.Fund.BHT50;
            this.Result.BHT100 = this.Source.BHT100 - this.Fund.BHT100;
            this.Result.BHT500 = this.Source.BHT500 - this.Fund.BHT500;
            this.Result.BHT1000 = this.Source.BHT1000 - this.Fund.BHT1000;
            */
        }

        private void Fund_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateResult();
        }

        public Models.FundEntry Source { get; private set; }
        public Models.FundEntry Fund { get; private set; }
        public Models.FundEntry Result { get; private set; }

        public string Description { get { return txtDescription.Text; } }
        public string Total { get { return this.Fund.BHTTotal.ToString("#,##0"); } }
    }
}
