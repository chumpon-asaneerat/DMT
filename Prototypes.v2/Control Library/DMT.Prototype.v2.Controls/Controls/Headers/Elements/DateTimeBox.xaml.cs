#region Using

using System;
using System.Windows;
using System.Windows.Controls;

using NLib.Services;

#endregion

namespace DMT.Controls.Headers.Elements
{
    /// <summary>
    /// Interaction logic for DateTimeBox.xaml
    /// </summary>
    public partial class DateTimeBox : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public DateTimeBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Load/Unload

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick += TimeTick;
        }


        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick -= TimeTick;
        }

        #endregion

        #region Event Handlers

        private void TimeTick(object sender, System.EventArgs e)
        {
            DateTime dt = DateTime.Now;
            txtDate.Text = dt.ToThaiDateString();
            txtTime.Text = dt.ToThaiTimeString();
        }

        #endregion
    }
}
