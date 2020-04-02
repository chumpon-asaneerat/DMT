using System;
using System.Windows;
using System.Windows.Controls;
using NLib.Services;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for PlazaInfo.xaml
    /// </summary>
    public partial class PlazaInfo : UserControl
    {
        public PlazaInfo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick += TimerTick;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick -= TimerTick;
        }


        private void UpdateTime()
        {
            // update current date time.
            txtCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss",
                System.Globalization.DateTimeFormatInfo.InvariantInfo);
            txtCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
