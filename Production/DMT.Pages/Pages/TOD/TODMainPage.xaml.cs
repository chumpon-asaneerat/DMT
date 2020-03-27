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
using System.Windows.Navigation;
using System.Windows.Shapes;

using NLib;
using NLib.Services;

namespace DMT.Pages
{
    /// <summary>
    /// Interaction logic for TODMainPage.xaml
    /// </summary>
    public partial class TODMainPage : UserControl
    {
        #region Constructor

        public TODMainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Button (Menu) Command Handlers

        private void beginJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Windows.BOJWindow win = new Windows.BOJWindow();
                win.Owner = Application.Current.MainWindow;

                if (win.ShowDialog() == false)
                {
                    return;
                }
                /*
                // Begin of Job Page
                var page = new Pages.BOJPage();
                PageContentManager.Instance.Current = page;
                var job = new Models.Job();
                //job.Begin = new DateTime(2020, 3, 17, 9, 30, 45);
                //job.End = new DateTime(2020, 3, 17, 22, 15, 33);
                job.Staff = new Models.Staff();
                job.Staff.CardID = "14077";
                job.Staff.Name = "นายเอนก หอมจรูง";

                var entry = new Models.RevenueEntry();
                page.Setup(job, entry);
                */
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void endJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // End of Job Page
                var page = new Pages.EOJPage();
                PageContentManager.Instance.Current = page;
                var job = new Models.Job();
                job.Begin = new DateTime(2020, 3, 17, 9, 30, 45);
                job.End = new DateTime(2020, 3, 17, 22, 15, 33);
                job.Staff = new Models.Staff();
                job.Staff.CardID = "14077";
                job.Staff.Name = "นายเอนก หอมจรูง";

                var shift = new Models.Shift(job);
                shift.Lane = 3;
                shift.Begin = new DateTime(2020, 3, 17, 9, 31, 22);
                shift.End = new DateTime(2020, 3, 17, 11, 30, 45);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 1;
                shift.Begin = new DateTime(2020, 3, 17, 13, 10, 11);
                shift.End = new DateTime(2020, 3, 17, 17, 22, 58);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 6;
                shift.Begin = new DateTime(2020, 3, 17, 20, 3, 12);
                shift.End = new DateTime(2020, 3, 17, 22, 50, 6);
                job.Shifts.Add(shift);

                var entry = new Models.RevenueEntry();
                page.Setup(job, entry);
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void revEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Revenue Entry Page
                var page = new Pages.RevenueDateSelectionPage();
                PageContentManager.Instance.Current = page;
                var job = new Models.Job();
                job.Begin = new DateTime(2020, 3, 17, 9, 30, 45);
                job.End = new DateTime(2020, 3, 17, 22, 15, 33);
                job.Staff = new Models.Staff();
                job.Staff.CardID = "14077";
                job.Staff.Name = "นายเอนก หอมจรูง";

                var shift = new Models.Shift(job);
                shift.Lane = 3;
                shift.Begin = new DateTime(2020, 3, 17, 9, 31, 22);
                shift.End = new DateTime(2020, 3, 17, 11, 30, 45);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 1;
                shift.Begin = new DateTime(2020, 3, 17, 13, 10, 11);
                shift.End = new DateTime(2020, 3, 17, 17, 22, 58);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 6;
                shift.Begin = new DateTime(2020, 3, 17, 20, 3, 12);
                shift.End = new DateTime(2020, 3, 17, 22, 50, 6);
                job.Shifts.Add(shift);

                var entry = new Models.RevenueEntry();
                page.Setup(job, entry);
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void reprintRevSlip_Click(object sender, RoutedEventArgs e)
        {

        }


        private void changeShift_Click(object sender, RoutedEventArgs e)
        {
            /*
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
            */
            try
            {
                // Revenue Entry Page
                var page = new Pages.ChangeShiftPage();
                PageContentManager.Instance.Current = page;
                var job = new Models.Job();
                job.Begin = new DateTime(2020, 3, 17, 9, 30, 45);
                job.End = new DateTime(2020, 3, 17, 22, 15, 33);
                job.Staff = new Models.Staff();
                job.Staff.CardID = "14077";
                job.Staff.Name = "นายเอนก หอมจรูง";

                var shift = new Models.Shift(job);
                shift.Lane = 3;
                shift.Begin = new DateTime(2020, 3, 17, 9, 31, 22);
                shift.End = new DateTime(2020, 3, 17, 11, 30, 45);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 1;
                shift.Begin = new DateTime(2020, 3, 17, 13, 10, 11);
                shift.End = new DateTime(2020, 3, 17, 17, 22, 58);
                job.Shifts.Add(shift);
                shift = new Models.Shift(job);
                shift.Lane = 6;
                shift.Begin = new DateTime(2020, 3, 17, 20, 3, 12);
                shift.End = new DateTime(2020, 3, 17, 22, 50, 6);
                job.Shifts.Add(shift);

                var entry = new Models.RevenueEntry();
                page.Setup(job, entry);
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void reportMenu_Click(object sender, RoutedEventArgs e)
        {
            var page = new Pages.TODReportMenu();
            PageContentManager.Instance.Current = page;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            // Init Sign In Page
            PageContentManager.Instance.Current = new Pages.TODSignInPage();
        }

        #endregion
    }
}
