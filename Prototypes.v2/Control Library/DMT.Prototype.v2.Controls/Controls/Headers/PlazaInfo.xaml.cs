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
            if (null != DMTPlazaManager.Instance.Plaza)
            {
                Models.Plaza plaza = DMTPlazaManager.Instance.Plaza;
                // Plaza
                txtPlazaId.Text = "รหัสด่าน: " + plaza.PlazaId;
                txtPlazaName.Text = "ชื่อด่าน: " + plaza.PlazaName;
                // Shift
                txtShiftId.Text = plaza.ShiftId;
                txtShiftDate.Text = plaza.ShiftDate;
                txtShiftTime.Text = plaza.ShiftTime;
                // Supervisor
                txtSupervisorId.Text = "รหัสหัวหน้าด่าน: " + plaza.SupervisorId;
                txtSupervisorName.Text = "หัวหน้าด่าน: " + plaza.SupervisorName;
            }
            else 
            {
                // Plaza
                txtPlazaId.Text = "รหัสด่าน: ";
                txtPlazaName.Text = "ชื่อด่าน: ";
                // Shift
                txtShiftId.Text = "";
                txtShiftDate.Text = "";
                txtShiftTime.Text = "";
                // Supervisor
                txtSupervisorId.Text = "รหัสหัวหน้าด่าน: ";
                txtSupervisorName.Text = "หัวหน้าด่าน: ";
            }
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
