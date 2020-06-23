using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TOD.TollAdmin
{
    /// <summary>
    /// Interaction logic for ChangeShiftPage.xaml
    /// </summary>
    public partial class ChangeShiftPage : UserControl
    {
        public ChangeShiftPage()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TOD.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TOD.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        /*
        private Models.Job _job;

        public void Setup(Models.Job job) 
        {
            _job = job;
            grid.Setup(_job.Lanes);
        }
        */
        public void Setup(List<Models.Lane> lanes)
        {
            grid.Setup(lanes);
        }
    }
}
