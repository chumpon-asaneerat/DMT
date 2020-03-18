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
    /// Interaction logic for RevenueEntryPage.xaml
    /// </summary>
    public partial class RevenueEntryPage : UserControl
    {
        public RevenueEntryPage()
        {
            InitializeComponent();
        }

        private Models.Job _job;
        private Models.RevenueEntry _entry;

        public void Setup(Models.Job job, Models.RevenueEntry entry)
        {
            _job = job;
            _entry = entry;
            revEntry.Setup(_job, _entry);
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.RevenuePreviewPage();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TODMainPage();
            PageContentManager.Instance.Current = page;
        }
    }
}
