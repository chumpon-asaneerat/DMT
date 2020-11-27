using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;


namespace DMT.Pages.Account.Check
{
    /// <summary>
    /// Interaction logic for PlazaFundPage.xaml
    /// </summary>
    public partial class PlazaFundPage : UserControl
    {
        public PlazaFundPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtPlazaName.Text = PlazaName;
            LoadData();
        }

        string PlazaName = string.Empty;

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.Check.AllPlazaFundPage();
            PageContentManager.Instance.Current = page;
        }

        private void LoadData()
        {
            List<test2> items = new List<test2>();
            items.Add(new test2()
            {
                EmpCode = "14321",
                EmpName = "สุเทพ เหมัน",
                Baht1 = decimal.Parse("1"),
                Baht2 = decimal.Parse("2"),
                Baht5 = decimal.Parse("5"),
                Baht10 = decimal.Parse("10"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("100"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("35"),
                Coupon80 = decimal.Parse("80"),

                Amount = decimal.Parse("1803")
            });
            items.Add(new test2()
            {
                EmpCode = "13201",
                EmpName = "แก้วใส ฟ้ารุ่งโรจน์",
                Baht1 = decimal.Parse("1"),
                Baht2 = decimal.Parse("2"),
                Baht5 = decimal.Parse("5"),
                Baht10 = decimal.Parse("10"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("100"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("35"),
                Coupon80 = decimal.Parse("80"),

                Amount = decimal.Parse("1803")
            });
            items.Add(new test2()
            {
                EmpCode = "11559",
                EmpName = "วิภา สวัวดิวัฒน์",
                Baht1 = decimal.Parse("1"),
                Baht2 = decimal.Parse("2"),
                Baht5 = decimal.Parse("5"),
                Baht10 = decimal.Parse("10"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("100"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("35"),
                Coupon80 = decimal.Parse("80"),

                Amount = decimal.Parse("1803")
            });
            items.Add(new test2()
            {
                EmpCode = "12860",
                EmpName = "ภักดี อมรรุ่งโรจน์",
                Baht1 = decimal.Parse("1"),
                Baht2 = decimal.Parse("2"),
                Baht5 = decimal.Parse("5"),
                Baht10 = decimal.Parse("10"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("100"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("35"),
                Coupon80 = decimal.Parse("80"),

                Amount = decimal.Parse("1803")
            });

            listTest.ItemsSource = items;
        }

        private void listTest_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.listTest.SelectedItems.Count > 0)
            {
                foreach (var li in this.listTest.SelectedItems)
                {
                    //MessageBox.Show(((test)li).PlazaName.ToString());
                }

            }
        }

        public void Setup(string plName)
        {
            if (PlazaName != null)
            {
                PlazaName = plName;
            }
        }

    }

    public class test2
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public decimal? Baht1 { get; set; }
        public decimal? Baht2 { get; set; }
        public decimal? Baht5 { get; set; }
        public decimal? Baht10 { get; set; }
        public decimal? Baht20 { get; set; }
        public decimal? Baht50 { get; set; }
        public decimal? Baht100 { get; set; }
        public decimal? Baht500 { get; set; }
        public decimal? Baht1000 { get; set; }
        public decimal? Coupon35 { get; set; }
        public decimal? Coupon80 { get; set; }
        public decimal? Amount { get; set; }
    }

}
