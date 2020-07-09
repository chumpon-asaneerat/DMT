using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace DMT.Windows.TA.Collector
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void Setup(string des, string total)
        {

            txtDescription.Text = des + " จำนวนเงิน " + total + " บาท";

        }


    }
}
