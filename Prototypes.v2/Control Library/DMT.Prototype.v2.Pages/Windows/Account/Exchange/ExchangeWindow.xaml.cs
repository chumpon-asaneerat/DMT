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
    /// Interaction logic for ExchangeWindow.xaml
    /// </summary>
    public partial class ExchangeWindow : Window
    {
        public ExchangeWindow()
        {
            InitializeComponent();
        }

        private void cmdApprove_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.Approve2Window();
            if (win.ShowDialog() == false)
            {
                return;
            }
            this.DialogResult = true;
        }
        private void cmdUnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Fund.Remark))
            {
                var win = new DMT.Windows.Account.UnApprove2Window();
                if (win.ShowDialog() == false)
                {
                    return;
                }
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("โปรดระบุ หมายเหตุ", "โปรดระบุ",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }
        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void Setup(Models.FundEntry fund, Models.AccountFundEntry accoun)
        {
            this.Fund = fund;
            this.Accoun = accoun;
            //this.LoanMoney = loan;
            fundEntry.DataContext = this.Fund;
            accountFundEntry.DataContext = this.Accoun;
            loanMoneyEntry.DataContext = this.Accoun;
        }

        public Models.FundEntry Fund { get; set; }
        public Models.AccountFundEntry Accoun { get; set; }

        //public Models.LoanMoneyEntry LoanMoney { get; set; }

    }
}
