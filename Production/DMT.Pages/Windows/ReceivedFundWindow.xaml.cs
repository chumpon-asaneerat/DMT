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

        public void Setup(Models.BagEntry bag)
        {
            this.Bag = bag;
            entry.DataContext = this.Bag;
        }

        public Models.BagEntry Bag { get; private set; }
    }
}
