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
using System.Windows.Shapes;

namespace DMT.Windows.Account
{
    /// <summary>
    /// Interaction logic for UnApproveWindow.xaml
    /// </summary>
    public partial class UnApproveWindow : Window
    {
        public UnApproveWindow()
        {
            InitializeComponent();

            txtRemark.SelectAll();
            txtRemark.Focus();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
