using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.Account.Limit
{
    /// <summary>
    /// Interaction logic for LimitPage.xaml
    /// </summary>
    public partial class LimitPage : UserControl
    {
        public LimitPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Report Page
            var page = new Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }
        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.EditAmountWindow();
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void LoadData()
        {
            List<test6> items = new List<test6>();
            items.Add(new test6()
            {
                PlazaName = "ดินแดน",
                AmountRequested = decimal.Parse("10000"),
                ApprovedAmount = decimal.Parse("20000")
            }); ;
            items.Add(new test6()
            {
                PlazaName = "สุทธิสาร",
                AmountRequested = decimal.Parse("1000"),
                ApprovedAmount = decimal.Parse("2000")
            });
            items.Add(new test6()
            {
                PlazaName = "ลาดพร้าว",
                AmountRequested = decimal.Parse("10000"),
                ApprovedAmount = decimal.Parse("20000")
            });
            items.Add(new test6()
            {
                PlazaName = "รัชดาภิเษก",
                AmountRequested = decimal.Parse("15000"),
                ApprovedAmount = decimal.Parse("25000")
            });
            items.Add(new test6()
            {
                PlazaName = "บางเขน",
                AmountRequested = decimal.Parse("16000"),
                ApprovedAmount = decimal.Parse("25000")
            });
            items.Add(new test6()
            {
                PlazaName = "แจ้งวัฒนะ",
                AmountRequested = decimal.Parse("11100"),
                ApprovedAmount = decimal.Parse("21000")
            });
            items.Add(new test6()
            {
                PlazaName = "หลักสี่",
                AmountRequested = decimal.Parse("10000"),
                ApprovedAmount = decimal.Parse("20000")
            });
            items.Add(new test6()
            {
                PlazaName = "ดอนเมือง",
                AmountRequested = decimal.Parse("20000"),
                ApprovedAmount = decimal.Parse("23000")

            });
            items.Add(new test6()
            {
                PlazaName = "อนุสรณ์สถาน",
                AmountRequested = decimal.Parse("12100"),
                ApprovedAmount = decimal.Parse("21200")
            });
            listTest.ItemsSource = items;
        }

        private void LoadDataApprove(string plazaName)
        {
            listApprove.ItemsSource = null;

            List<test7> items = new List<test7>();

            if (plazaName == "ดินแดน")
            {
                items.Add(new test7()
                {
                    PlazaName = "ดินแดน",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("15000"),
                    EditApprovedAmount = decimal.Parse("25000"),
                    webSiteAddress = "www.google.com"
                });
                items.Add(new test7()
                {
                    PlazaName = "ดินแดน",
                    DocDate = DateTime.Now.AddDays(1),
                    Status = "ลด",
                    EditAmountRequested = decimal.Parse("100"),
                    EditApprovedAmount = decimal.Parse("200")
                });

            }

            if (plazaName == "สุทธิสาร")
            {
                items.Add(new test7()
                {
                    PlazaName = "สุทธิสาร",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("1000"),
                    EditApprovedAmount = decimal.Parse("2000")
                });
            }

            if (plazaName == "ลาดพร้าว")
            {
                items.Add(new test7()
                {
                    PlazaName = "ลาดพร้าว",
                    DocDate = DateTime.Now.AddDays(-1),
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("10000"),
                    EditApprovedAmount = decimal.Parse("20000")
                });
                items.Add(new test7()
                {
                    PlazaName = "ลาดพร้าว",
                    DocDate = DateTime.Now,
                    Status = "เพิ่ม",
                    EditAmountRequested = decimal.Parse("110"),
                    EditApprovedAmount = decimal.Parse("210")
                });
                items.Add(new test7()
                {
                    PlazaName = "ลาดพร้าว",
                    Status = "เพิ่ม",
                    DocDate = DateTime.Now.AddDays(1),
                    EditAmountRequested = decimal.Parse("120"),
                    EditApprovedAmount = decimal.Parse("220")
                });
            }

            if (plazaName == "รัชดาภิเษก")
            {
                items.Add(new test7()
                {
                    PlazaName = "รัชดาภิเษก",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("15000"),
                    EditApprovedAmount = decimal.Parse("25000")
                });
            }

            if (plazaName == "บางเขน")
            {
                items.Add(new test7()
                {
                    PlazaName = "บางเขน",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("16000"),
                    EditApprovedAmount = decimal.Parse("25000")
                });
            }
            if (plazaName == "แจ้งวัฒนะ")
            {
                items.Add(new test7()
                {
                    PlazaName = "แจ้งวัฒนะ",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("11100"),
                    EditApprovedAmount = decimal.Parse("21000")
                });
                items.Add(new test7()
                {
                    PlazaName = "แจ้งวัฒนะ",
                    DocDate = DateTime.Now,
                    Status = "เพิ่ม",
                    EditAmountRequested = decimal.Parse("100"),
                    EditApprovedAmount = decimal.Parse("1000")
                });
            }
            if (plazaName == "หลักสี่")
            {
                items.Add(new test7()
                {
                    PlazaName = "หลักสี่",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("10000"),
                    EditApprovedAmount = decimal.Parse("20000")
                });
            }
            if (plazaName == "ดอนเมือง")
            {
                items.Add(new test7()
                {
                    PlazaName = "ดอนเมือง",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("20000"),
                    EditApprovedAmount = decimal.Parse("23000")

                });
                items.Add(new test7()
                {
                    PlazaName = "ดอนเมือง",
                    DocDate = DateTime.Now,
                    Status = "เพิ่ม",
                    EditAmountRequested = decimal.Parse("200"),
                    EditApprovedAmount = decimal.Parse("230")

                });
                items.Add(new test7()
                {
                    PlazaName = "ดอนเมือง",
                    DocDate = DateTime.Now,
                    Status = "เพิ่ม",
                    EditAmountRequested = decimal.Parse("500"),
                    EditApprovedAmount = decimal.Parse("500")

                });
            }
            if (plazaName == "อนุสรณ์สถาน")
            {
                items.Add(new test7()
                {
                    PlazaName = "อนุสรณ์สถาน",
                    DocDate = DateTime.Now,
                    Status = "ตั้งต้น",
                    EditAmountRequested = decimal.Parse("12100"),
                    EditApprovedAmount = decimal.Parse("21200")
                });
            }

            listApprove.ItemsSource = items;
        }

        private void listTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = e.OriginalSource as ListView;

            if (!string.IsNullOrEmpty(((DMT.Pages.Account.Limit.test6)lv.SelectedItem).PlazaName))
            {
                txtPlazaName.Text = ((DMT.Pages.Account.Limit.test6)lv.SelectedItem).PlazaName;
                LoadDataApprove(txtPlazaName.Text);
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            string errMsg = "";
            try
            {
              
            }
            catch (UnauthorizedAccessException uae)
            {
                errMsg = uae.Message;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
        }
    }

    public class test6
    {
        public string PlazaName { get; set; }
     
        public decimal? AmountRequested { get; set; }
        public decimal? ApprovedAmount { get; set; }
    }

    public class test7
    {
        public string PlazaName { get; set; }
        public string Status { get; set; }
        public DateTime? DocDate { get; set; }
        public decimal? EditAmountRequested { get; set; }
        public decimal? EditApprovedAmount { get; set; }

        public string webSiteAddress { get; set; }
    }
}
