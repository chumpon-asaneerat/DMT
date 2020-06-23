#region Using

using System;
using System.Windows;
using System.Windows.Controls;

using NLib.Services;
using DMT.Services;

#endregion

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for AccountInfo.xaml
    /// </summary>
    public partial class AccountInfo : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public AccountInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Load/Unload

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick += TimerTick;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick -= TimerTick;
        }

        #endregion

        private DateTime lastUpdated = DateTime.MinValue;

        private void UpdateInfo()
        {
            txtUserId.Text = "รหัสพนักงาน: " + SmartCardManager.UserId;
            txtUserName.Text = "ชื่อผู้ใช้งาน: " + SmartCardManager.UserName;
        }

        private void UpdateTime()
        {
            // Current date time.
            txtCurrentTime.Text = DateTime.Now.ToThaiTimeString();
            txtCurrentDate.Text = DateTime.Now.ToThaiDateTimeString("dd/MM/yyyy");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - lastUpdated;
            if (ts.TotalMilliseconds > 500)
            {
                // Check information every 0.5 second.
                UpdateInfo();

                lastUpdated = dt;
            }
            UpdateTime();
        }
    }
}
