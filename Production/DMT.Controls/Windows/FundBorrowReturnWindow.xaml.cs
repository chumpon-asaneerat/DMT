using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DMT.Windows
{
    /// <summary>
    /// Interaction logic for FundBorrowReturnWindow.xaml
    /// </summary>
    public partial class FundBorrowReturnWindow : Window
    {
        public FundBorrowReturnWindow()
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

        private void UpdateResult()
        {
            if (null == this.Source || null == this.Borrow || null == this.Result) return;
            this.Result.BHT1 = this.Source.BHT1 + this.Borrow.BHT1 - this.Return.BHT1;
            this.Result.BHT2 = this.Source.BHT2 + this.Borrow.BHT2 - this.Return.BHT2;
            this.Result.BHT5 = this.Source.BHT5 + this.Borrow.BHT5 - this.Return.BHT5;
            this.Result.BHT10c = this.Source.BHT10c + this.Borrow.BHT10c - this.Return.BHT10c;
            this.Result.BHT20 = this.Source.BHT20 + this.Borrow.BHT20 - this.Return.BHT20;
            this.Result.BHT50 = this.Source.BHT50 + this.Borrow.BHT50 - this.Return.BHT50;
            this.Result.BHT100 = this.Source.BHT100 + this.Borrow.BHT100 - this.Return.BHT100;
            this.Result.BHT500 = this.Source.BHT500 + this.Borrow.BHT500 - this.Return.BHT500;
            this.Result.BHT1000 = this.Source.BHT1000 + this.Borrow.BHT1000 - this.Return.BHT1000;
        }

        public void Setup(Models.FundEntry srcObj, 
            Models.FundEntry rcvObj, Models.FundEntry retObj,
            Models.FundEntry resObj)
        {
            if (null != this.Return) this.Return.PropertyChanged -= Return_PropertyChanged;
            if (null != this.Borrow) this.Borrow.PropertyChanged -= Borrow_PropertyChanged;

            this.Source = srcObj;
            this.Borrow = rcvObj;
            this.Return = retObj;
            this.Result = resObj;

            if (null != this.Borrow) this.Borrow.PropertyChanged += Borrow_PropertyChanged;
            if (null != this.Return) this.Return.PropertyChanged += Return_PropertyChanged;

            this.srcEntry.DataContext = this.Source;
            this.borrowEntry.DataContext = this.Borrow;
            this.returnEntry.DataContext = this.Return;
            this.sumEntry.DataContext = this.Result;

            UpdateResult();
        }

        private void Borrow_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateResult();
        }

        private void Return_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateResult();
        }

        public Models.FundEntry Source { get; private set; }
        public Models.FundEntry Borrow { get; private set; }
        public Models.FundEntry Return { get; private set; }
        public Models.FundEntry Result { get; private set; }
    }
}
