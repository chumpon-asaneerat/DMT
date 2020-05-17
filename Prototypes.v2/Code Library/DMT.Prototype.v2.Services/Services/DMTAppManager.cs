#region Using

using System;
using System.Threading;
using NLib;
using DMT.Models;
using System.Runtime.InteropServices;

#endregion

namespace DMT.Services
{
    /// <summary>
    /// DMT App Manager.
    /// </summary>
    public class DMTAppManager
    {
        #region Static Instance Access

        private static DMTAppManager _instance = null;

        /// <summary>
        /// Gets DMTAppManager instance access.
        /// </summary>
        public static DMTAppManager Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (typeof(DMTAppManager))
                    {
                        _instance = new DMTAppManager();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Internal Variables

        private Thread _th = null;
        private bool _running = false;
        private string _fileName = NJson.LocalFile("app.json");
        private Plaza _plaza = null;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private DMTAppManager() : base()
        {
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~DMTAppManager()
        {
            Shutdown();
        }

        #endregion

        #region Private Methods

        private void Processing()
        {
            DateTime dt = DateTime.Now;
            TimeSpan ts;
            while (null != _th && _running &&
                !ApplicationManager.Instance.IsExit)
            {
                ts = DateTime.Now - dt;
                if (ts.TotalMilliseconds > 250)
                {
                    UpdateInfo();
                    dt = DateTime.Now;
                }
            }
            Shutdown();
        }

        private void UpdateInfo()
        {
            if (!NJson.Exists(_fileName))
            {
                _plaza = new Plaza();
                // _plaza.Mode = "Account";
                _plaza.Mode = "Plaza";
                _plaza.PlazaId = "01";
                _plaza.PlazaName = "ดินแดง";
                _plaza.Shift = new Shift();
                _plaza.Shift.ShiftId = 1;
                _plaza.Shift.Begin = DateTime.Now;
                _plaza.Supervisor = new Staff();
                _plaza.Supervisor.Role = "Supervisor";
                _plaza.Supervisor.StaffId = "17155";
                _plaza.Supervisor.StaffName = "นาย สมบูรณ์ สบายดี";
                _plaza.SaveToFile(_fileName);
            }
            _plaza = NJson.LoadFromFile<Plaza>(_fileName);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start Service.
        /// </summary>
        public void Start()
        {
            if (null == _th)
            {
                _th = new Thread(Processing);
                _th.Priority = ThreadPriority.BelowNormal;
                _th.Name = "DMT Plaza App Manager Thread";
                _th.IsBackground = true;
                _running = true;
                _th.Start();
            }
        }
        /// <summary>
        /// Shutdown Service.
        /// </summary>
        public void Shutdown()
        {
            _running = false;
            if (null != _th)
            {
                try { _th.Abort(); }
                catch (ThreadAbortException) { }
            }
            _th = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets is service is running.
        /// </summary>
        public bool IsRunning { get { return _running; } }
        /// <summary>
        /// Gets current plaza app information.
        /// </summary>
        public Plaza Plaza { get { return _plaza;  } }

        #endregion
    }
}
