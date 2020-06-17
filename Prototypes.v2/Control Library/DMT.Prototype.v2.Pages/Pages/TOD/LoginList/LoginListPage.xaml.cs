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
            // Main Menu Page
            var page = new MainMenu();
            PageContentManager.Instance.Current = page;
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
