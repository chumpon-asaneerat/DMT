#region Using

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NLib;
using DMT.Models;

#endregion

namespace DMT.Services
{
    #region PlazaService

    /// <summary>
    /// The PlazaService class.
    /// </summary>
    public class PlazaService
    {
        #region Static Instance Access

        private static PlazaService _instance = null;

        /// <summary>
        /// Gets PlazaService instance access.
        /// </summary>
        public static PlazaService Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock(typeof(PlazaService))
                    {
                        _instance = new PlazaService();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Internal Variables

        private Thread _th = null;
        private bool _running = false;
        private Plaza _plaza = null;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private PlazaService() : base() 
        {
            _plaza = new Plaza();
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~PlazaService()
        {
            Shutdown();
            _plaza = null;
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
            if (null != ShiftChanged) ShiftChanged.Invoke(this, EventArgs.Empty);
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
                _th.Name = "PlazaService Thread";
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
        /// <summary>
        /// Change Shift.
        /// </summary>
        /// <param name="supervisor"></param>
        public void ChangeShift(Supervisor supervisor)
        {
            if (null != _plaza)
            {
                _plaza.ChangeShift(supervisor);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets is service is running.
        /// </summary>
        public bool IsRunning { get { return _running; } }
        /// <summary>
        /// Gets Plaza instance.
        /// </summary>
        public Plaza Plaza { get { return _plaza; } }

        #endregion

        #region Public Events

        /// <summary>
        /// The Shift Changed event.
        /// </summary>
        public event System.EventHandler ShiftChanged;

        #endregion
    }

    #endregion
}
