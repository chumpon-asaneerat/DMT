#region Using

using System;
using System.Windows;
using System.Windows.Controls;

using NLib.Services;

#endregion

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for PlazaInfo.xaml
    /// </summary>
    public partial class PlazaInfo : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlazaInfo()
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
            // Plaze
            txtPlazaId.Text = "รหัสด่าน: " + "01";
            txtPlazaName.Text = "ชื่อด่าน: " + "ดินแดง";
            // Shift
            txtShiftId.Text = "2";
            txtShiftDate.Text = "2563-05-17";
            txtShiftTime.Text = "14:03:22";
            // Supervisor
            txtSupervisorId.Text = "รหัสหัวหน้าด่าน: " + "12012";
            txtSupervisorName.Text = "หัวหน้าด่าน: " + "นาย ศิระ ทรงศรีชาติ";
        }
        private void UpdateTime()
        {
            // Current date time.
            txtCurrentTime.Text = DateTime.Now.ToThaiTimeString();
            txtCurrentDate.Text = DateTime.Now.ToThaiDateTimeString("yyyy-MM-dd");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts = dt - lastUpdated;
            if (ts.TotalSeconds > 2)
            {
                // Check information every 2 second.
                UpdateInfo();

                lastUpdated = dt;
            }
            UpdateTime();
        }
    }
}
