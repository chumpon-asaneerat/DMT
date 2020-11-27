using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;


namespace DMT.Pages.Account.Check
{
    /// <summary>
    /// Interaction logic for AllPlazaFundPage.xaml
    /// </summary>
    public partial class AllPlazaFundPage : UserControl
    {
        public AllPlazaFundPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void LoadData()
        {
            List<test> items = new List<test>();
            items.Add(new test()
            {
                PlazaName = "ดินแดน",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "สุทธิสาร",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "ลาดพร้าว",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "รัชดาภิเษก",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "บางเขน",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "แจ้งวัฒนะ",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "หลักสี่",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "ดอนเมือง",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "อนุสรณ์สถาน",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
            });
            items.Add(new test()
            {
                PlazaName = "รวม",
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Coupon35 = decimal.Parse("350"),
                Coupon80 = decimal.Parse("800"),
                Total = decimal.Parse("30000"),
                Amount = decimal.Parse("3900")
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

                    var page = new Pages.Account.Check.PlazaFundPage();
                    page.Setup(((test)li).PlazaName.ToString());
                    PageContentManager.Instance.Current = page;
                    break;
                }

            }
        }
    }

    public class test
    {
        public string PlazaName { get; set; }
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
        public decimal? Total { get; set; }
        public decimal? Amount { get; set; }
    }
}
