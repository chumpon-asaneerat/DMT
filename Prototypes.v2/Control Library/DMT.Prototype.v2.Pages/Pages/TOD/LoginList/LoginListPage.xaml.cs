using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TOD.Job
{
    /// <summary>
    /// Interaction logic for LoginListPage.xaml
    /// </summary>
    public partial class LoginListPage : UserControl
    {
        public LoginListPage()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {


            // Main Menu Page
            var page = new MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<Models.Lane> lanes = new List<Models.Lane>();
            Models.Lane lane;

            lane = new Models.Lane();
            lane.StaffId = "14055";
            lane.StaffName = "นางวิภา สวัสดิวัฒน์";
            lane.Begin = new DateTime(2020, 6, 16, 18, 50, 11);
            lane.Shift = "ดึก";
            lanes.Add(lane);

            lane = new Models.Lane();
            lane.StaffId = "14147";
            lane.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
            lane.Begin = new DateTime(2020, 6, 17, 08, 50, 11);
            lane.Shift = "เช้า";
            lanes.Add(lane);


            grid.Setup(lanes);


        }

        public void Setup(List<Models.Lane> lanes)
        {
            if (null != lanes)
            {
               
                grid.Setup(lanes);
            }
            else
            {

            }
        }
    }
}
