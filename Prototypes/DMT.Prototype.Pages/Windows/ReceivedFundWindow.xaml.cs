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

namespace DMT.Windows
{
    /// <summary>
    /// Interaction logic for ReceivedFundWindow.xaml
    /// </summary>
    public partial class ReceivedFundWindow : Window
    {
        public ReceivedFundWindow()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void Setup(Models.FundEntry fund)
        {
            this.Fund = fund;
            entry.DataContext = this.Fund;
        }

        public Models.FundEntry Fund { get; private set; }
    }
}
