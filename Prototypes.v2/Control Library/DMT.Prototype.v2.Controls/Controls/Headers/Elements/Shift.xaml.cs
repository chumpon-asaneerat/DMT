﻿#region Using

using System.Windows;
using System.Windows.Controls;

#endregion


namespace DMT.Controls.Headers.Elements
{
    /// <summary>
    /// Interaction logic for Shift.xaml
    /// </summary>
    public partial class Shift : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public Shift()
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
