﻿#region Using

using System.Windows;
using System.Windows.Controls;

#endregion


namespace DMT.Controls.Headers.Elements
{
    /// <summary>
    /// Interaction logic for Plaza.xaml
    /// </summary>
    public partial class Plaza : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public Plaza()
        {
            InitializeComponent();
        }

        #endregion

        #region Load/Unload

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //PlazaService.Instance.ShiftChanged += ShiftChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //PlazaService.Instance.ShiftChanged -= ShiftChanged;
        }

        #endregion

        #region Event Handlers

        private void ShiftChanged(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}
