using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Services
{
    public class PlazaService
    {
        #region Static Instance Access

        private static PlazaService _instance = null;

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

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        private PlazaService()
        {

        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~PlazaService()
        {
            Shutdown();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start Service.
        /// </summary>
        public void Start()
        {

        }
        /// <summary>
        /// Shutdown Service.
        /// </summary>
        public void Shutdown()
        {

        }

        #endregion

        #region Public Events

        #endregion
    }
}
