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
    /// Interaction logic for TASignInPage.xaml
    /// </summary>
    public partial class TASignInPage : UserControl
    {
        public TASignInPage()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            // Init Main Menu
            PageContentManager.Instance.Current = new Pages.TAMainPage();
        }
    }
}
