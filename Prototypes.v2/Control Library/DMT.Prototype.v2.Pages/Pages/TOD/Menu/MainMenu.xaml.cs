
#region Using

using System.Windows;
using System.Windows.Controls;

using NLib.Services;

using System;
using System.Collections.Generic;

using NLib;

#endregion

namespace DMT.Pages.TOD
{
    /// <summary>
    /// Interaction logic for TODMainMenu.xaml
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
        }

        #endregion

        #region Button (Menu) Command Handlers

        private void beginJob_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Begin of Job Page
            Windows.TOD.Job.BOJWindow jobWindow = new Windows.TOD.Job.BOJWindow();
            jobWindow.Owner = Application.Current.MainWindow;
            if (jobWindow.ShowDialog() == false)
            {
                return;
            }
        }

        private void endJob_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // End of Job Page
            var page = new Job.EOJPage();
            // setup
            page.Setup(Models.Job.FindJob("14077"));
            PageContentManager.Instance.Current = page;
        }

        private void revEntry_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Revenue Entry
            var page = new Revenue.RevenueDateSelectionPage();
            // setup
            Models.RevenueEntry entry = new Models.RevenueEntry();
            page.Setup(Models.Job.FindJob("14077"), entry);
            PageContentManager.Instance.Current = page;
        }

        private void reprintRevSlip_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var search = new Windows.TOD.Reports.RevenueSlipSearchWindow();
            search.Owner = Application.Current.MainWindow;
            if (search.ShowDialog() == false)
            {
                return;
            }
            var page = new Revenue.RevenueDateSelectionPage();
            // setup
            Models.RevenueEntry entry = new Models.RevenueEntry();
            page.Setup(Models.Job.FindJob("14077"), entry);
            PageContentManager.Instance.Current = page;
            /*
            // Revenue Slip Preview
            var page = new Reports.RevenueSlipPreview();
            page.MenuPage = this;
            PageContentManager.Instance.Current = page;
            */
        }

        private void changeShift_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Change Shift
            var page = new TollAdmin.ChangeShiftPage();
            // setup
            //page.Setup(Models.Job.FindJob("14077"));
            List<Models.Lane> lanes = new List<Models.Lane>();
            Models.Lane lane;

            lane = new Models.Lane();
            lane.StaffId = "14077";
            lane.StaffName = "นายเอนก หอมจรูง";
            lane.Begin = new DateTime(2020, 6, 16, 13, 20, 50);
            lane.End = new DateTime(2020, 6, 16, 22, 22, 20);
            lane.LaneId = 4;
            lanes.Add(lane);

            lane = new Models.Lane();
            lane.StaffId = "14055";
            lane.StaffName = "นางวิภา สวัสดิวัฒน์";
            lane.Begin = new DateTime(2020, 6, 16, 18, 50, 11);
            lane.End = new DateTime(2020, 6, 16, 23, 50, 00);
            lane.LaneId = 1;
            lanes.Add(lane);

            lane = new Models.Lane();
            lane.StaffId = "14147";
            lane.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
            lane.Begin = new DateTime(2020, 6, 17, 08, 50, 11);
            lane.End = new DateTime(2020, 6, 17, 13, 00, 10);
            lane.LaneId = 3;
            lanes.Add(lane);

            lane = new Models.Lane();
            lane.StaffId = "12562";
            lane.StaffName = "นาย ภักดี อมรรุ่งโรจฌ์";
            lane.Begin = new DateTime(2020, 6, 17, 08, 00, 50);
            lane.End = new DateTime(2020, 6, 17, 18, 00, 50);
            lane.LaneId = 2;
            lanes.Add(lane);
            page.Setup(Models.Job.FindJob("14077"), lanes);
            PageContentManager.Instance.Current = page;
        }

        private void reportMenu_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var page = new TOD.ReportMenu();
            PageContentManager.Instance.Current = page;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
        }


        private void emvQRCode_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var page = new DMT.Pages.TOD.Job.EMVQRCode();
            List<Models.EMVQRCode> emvQRs = new List<Models.EMVQRCode>();
            Models.EMVQRCode emvQR;

            emvQR = new Models.EMVQRCode();
            emvQR.Type = "EMV";
            emvQR.DateQR = new DateTime(2020, 6, 16, 18, 50, 11);
            emvQR.StaffId = "14055";
            emvQR.LaneId = 1;
            emvQR.ApprovalCode = "459564";
            emvQR.Qty = 110;
            emvQRs.Add(emvQR);

            emvQR = new Models.EMVQRCode();
            emvQR.Type = "EMV";
            emvQR.DateQR = new DateTime(2020, 6, 16, 23, 15, 24);
            emvQR.StaffId = "14147";
            emvQR.LaneId = 3;
            emvQR.ApprovalCode = "485564";
            emvQR.Qty = 80;
            emvQRs.Add(emvQR);

            emvQR = new Models.EMVQRCode();
            emvQR.Type = "EMV";
            emvQR.DateQR = new DateTime(2020, 6, 17, 08, 15, 0);
            emvQR.StaffId = "14148";
            emvQR.LaneId = 3;
            emvQR.ApprovalCode = "485568";
            emvQR.Qty = 80;
            emvQRs.Add(emvQR);

            emvQR = new Models.EMVQRCode();
            emvQR.Type = "QR Code";
            emvQR.DateQR = new DateTime(2020, 6, 17, 12, 1, 47);
            emvQR.StaffId = "12562";
            emvQR.LaneId = 2;
            emvQR.ApprovalCode = "459564";
            emvQR.Qty = 110;
            emvQRs.Add(emvQR);

            emvQR = new Models.EMVQRCode();
            emvQR.Type = "QR Code";
            emvQR.DateQR = new DateTime(2020, 6, 18, 12, 5, 10);
            emvQR.StaffId = "12563";
            emvQR.LaneId = 2;
            emvQR.ApprovalCode = "459566";
            emvQR.Qty = 110;
            emvQRs.Add(emvQR);

            page.Setup(emvQRs);

            PageContentManager.Instance.Current = page;
        }

        private void loginList_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var page = new DMT.Pages.TOD.Job.LoginListPage();
            List<Models.Lane> Lanes = new List<Models.Lane>();
            Models.Lane lane;

            lane = new Models.Lane();
            lane.StaffId = "14077";
            lane.StaffName = "นายเอนก หอมจรูง";
            lane.Begin = new DateTime(2020, 6, 16, 08, 00, 00);
            lane.End = new DateTime(2020, 6, 16, 10, 00, 11);
            lane.Shift = "เช้า";
            Lanes.Add(lane);

            lane = new Models.Lane();
            lane.Begin = new DateTime(2020, 6, 16, 01, 50, 11);
            lane.End = new DateTime(2020, 6, 17, 10, 00, 11);
            lane.StaffId = "14055";
            lane.StaffName = "นางวิภา สวัสดิวัฒน์";
            lane.Shift = "เช้า";
            Lanes.Add(lane);

            lane = new Models.Lane();
            lane.Begin = new DateTime(2020, 6, 17, 00, 50, 24);
            lane.End = new DateTime(2020,6, 17, 08, 00, 11);
            lane.StaffId = "14147";
            lane.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
            lane.Shift = "ดึก";
            Lanes.Add(lane);

            lane = new Models.Lane();
            lane.Begin = new DateTime(2020, 6, 17, 12, 1, 47);
            lane.End = new DateTime(2020, 6, 17, 08, 30, 00);
            lane.StaffId = "12562";
            lane.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
            lane.Shift = "บ่าย";
            Lanes.Add(lane);
           
            page.Setup(Lanes);

            PageContentManager.Instance.Current = page;
        }

        #endregion
    }
}
