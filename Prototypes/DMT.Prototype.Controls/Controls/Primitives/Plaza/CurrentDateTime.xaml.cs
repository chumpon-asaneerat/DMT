#region Using

using System;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

using DMT.Services;

#endregion

namespace DMT.Controls.Primitives.Plaza
{
    /// <summary>
    /// Interaction logic for CurrentDateTime.xaml
    /// </summary>
    public partial class CurrentDateTime : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public CurrentDateTime()
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
            txtDate.Text = dt.ToDateString();
            txtTime.Text = dt.ToTimeString();
        }

        #endregion
    }
}
