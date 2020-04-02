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
    /// Interaction logic for BOJPage.xaml
    /// </summary>
    public partial class BOJPage : UserControl
    {
        public BOJPage()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TODMainPage();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TODMainPage();
            PageContentManager.Instance.Current = page;
        }

        private Models.Job _job;
        private Models.RevenueEntry _entry;

        public void Setup(Models.Job job, Models.RevenueEntry entry)
        {
            _job = job;
            _entry = entry;
            grid.Setup(_job.Shifts);
        }
    }
}
