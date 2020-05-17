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

namespace DMT.Windows.TOD.Job
{
    /// <summary>
    /// Interaction logic for BOJWindow.xaml
    /// </summary>
    public partial class BOJWindow : Window
    {
        public BOJWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtDate.Text = DateTime.Now.ToThaiDateString();
            txtTime.Text = DateTime.Now.ToThaiTimeString();
        }

        private void cmdOK_Click(object sender, RoutedEventArgs e)
        {
            Models.Job.BeginJob("14077", "นายเอนก หอมจรูง", 2);
            DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
