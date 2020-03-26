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
    /// Interaction logic for RequestExchangeView.xaml
    /// </summary>
    public partial class RequestExchangeView : UserControl
    {
        public RequestExchangeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Models.FundExchange item = b.CommandParameter as Models.FundExchange;
            if (null != item)
            {
                Windows.FundExchangeWindow win = new Windows.FundExchangeWindow();
                win.Owner = Application.Current.MainWindow;

                win.Title = "Request Exchange";
                win.Setup(Windows.ExchangeWindowMode.Edit, item);
                if (win.ShowDialog() == false)
                {
                    return;
                }
                // update item.
            }
        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundExchange> _items;

        public void Setup(Models.FundEntry plaza, BindingList<Models.FundExchange> items)
        {
            _plaza = plaza;
            _items = items;
            listView.ItemsSource = _items;
        }
    }
}
