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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {

            }
            try
            {

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void endJob_Click(object sender, RoutedEventArgs e)
        {

        }

        private void revEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reprintRevSlip_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
