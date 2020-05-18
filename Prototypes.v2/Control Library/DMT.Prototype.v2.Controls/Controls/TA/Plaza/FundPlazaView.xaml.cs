using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for FundPlazaView.xaml
    /// </summary>
    public partial class FundPlazaView : UserControl
    {
        public FundPlazaView()
        {
            InitializeComponent();
        }

        public void Setup(BindingList<Models.FundEntry> funds)
        {
            listView.ItemsSource = funds;
        }
    }
}
