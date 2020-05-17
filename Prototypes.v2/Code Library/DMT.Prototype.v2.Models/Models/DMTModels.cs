#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NLib;

// required for JsonIgnore.
using Newtonsoft.Json;

#endregion

namespace DMT.Models
{
    public class X
    {
        public string account { get; set; }
        public DateTime logindate { get; set; }

        public string data { get; set; }

        [JsonIgnore]
        public string ignore { get; set; }

        public static List<X> getTests()
        {
            List<X> list = new List<X>();
            Random r = new Random();
            X inst;
            inst = new X();
            inst.account = "aaa";
            inst.logindate = DateTime.Now;
            inst.data = "1";
            inst.ignore = "ignore a";
            list.Add(inst);
            inst = new X();
            inst.account = "bbb";
            inst.logindate = DateTime.Now.AddMilliseconds(r.Next(999));
            inst.data = "2";
            inst.ignore = "ignore b";
            list.Add(inst);
            inst = new X();
            inst.account = "ccc";
            inst.data = "3";
            inst.ignore = "ignore c";
            inst.logindate = DateTime.Now.AddMilliseconds(r.Next(999));
            list.Add(inst);

            return list;
        }
    }

    /// <summary>
    /// The DMT Model class.
    /// </summary>
    public class DMTModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets all plazas.
        /// </summary>
        public List<Plaza> plazas { get; set; }
        /// <summary>
        /// Gets or sets all staffs.
        /// </summary>
        public List<Staff> staffs { get; set; }

        #endregion
    }

    /// <summary>
    /// The plaza information class.
    /// </summary>
    public class Plaza : INotifyPropertyChanged
    {
        #region Internal Variables

        private string _plazaId = string.Empty;
        private string _plazaName = string.Empty;
        private int _shiftId = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Plaza Id.
        /// </summary>
        public string PlazaId 
        {
            get { return _plazaId; }
            set
            {
                if (_plazaId != value)
                {
                    _plazaId = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("PlazaId"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Plaza Name.
        /// </summary>
        public string PlazaName 
        {
            get { return _plazaName; }
            set
            {
                if (_plazaName != value)
                {
                    _plazaName = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("PlazaName"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Current Shift Id.
        /// </summary>
        public int ShiftId
        {
            get { return _shiftId; }
            set
            {
                if (_shiftId != value)
                {
                    _shiftId = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ShiftId"));
                }
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    /// <summary>
    /// The Shift Class.
    /// </summary>
    public class Shift
    {
        #region Internal Variables

        private DateTime _shifrBegin = DateTime.MinValue;
        private DateTime _shiftEnd = DateTime.MinValue;

        #endregion

        #region Public Properties

        public int ShiftId
        {
            get;
            set;
        }
        public DateTime ShiftBegin
        {
            get { return _shifrBegin; }
            set
            {
                if (_shifrBegin != value)
                {
                    _shifrBegin = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ShiftBegin"));
                }
            }
        }
        public DateTime ShiftEnd
        {
            get { return _shiftEnd; }
            set
            {
                if (_shiftEnd != value)
                {
                    _shiftEnd = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ShiftEnd"));
                }
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    /// <summary>
    /// The Staff class.
    /// </summary>
    public class Staff
    {
        #region Internal Variables

        private string _role = "Collector";
        private string _staffId = string.Empty;
        private string _staffName = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Rule.
        /// </summary>
        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Role"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Staff Id.
        /// </summary>
        public string StaffId
        {
            get { return _staffId; }
            set
            {
                if (_staffId != value)
                {
                    _staffId = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("StaffId"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Staff Name.
        /// </summary>
        public string StaffName
        {
            get { return _staffName; }
            set
            {
                if (_staffName != value)
                {
                    _staffName = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("StaffName"));
                }
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
