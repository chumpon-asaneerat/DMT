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
    #region Test Class

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

        public static void Test()
        {
            // Test Json Code.
            List<X> list = X.getTests();
            string fileName = Json.LocalFile("sample.json");

            //string json = list.ToJson();
            //Console.WriteLine(json);

            if (!list.SaveToFile(fileName))
            {
                Console.WriteLine("Cannot save file.");
            }

            List<X> list2;
            list2 = Json.LoadFromFile<List<X>>(fileName);
            Console.WriteLine(list2);
            Console.WriteLine(list2.ToJson());
        }
    }

    #endregion

    #region DMTModel

    /// <summary>
    /// The DMT Model class.
    /// </summary>
    public class DMTModel
    {
        #region Public Methods - example code from MyChoice
        /*
        /// <summary>
        /// Checks Properties Equals.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>Returns true if current properties is same as source.</returns>
        public bool PropertiesEquals(MyChoiceDevice source)
        {
            if (null == source)
                return false;
            int cnt = 0;
            if (this.Group != source.Group) ++cnt;
            if (this.DeviceSerialNumber != source.DeviceSerialNumber) ++cnt;
            if (this.LastScanTime != source.LastScanTime) ++cnt;
            if (this.Model != source.Model) ++cnt;
            if (this.Mode != source.Mode) ++cnt;
            if (this.HasErrors != source.HasErrors) ++cnt;
            if (this.CallCounter != source.CallCounter) ++cnt;
            if (this.AckCounter != source.AckCounter) ++cnt;
            return (cnt == 0);
        }
        /// <summary>
        /// Clone properties.
        /// </summary>
        /// <param name="source">The source object.</param>
        public void Clone(MyChoiceDevice source)
        {
            if (null == source)
                return;
            this.Group = source.Group;
            this.DeviceSerialNumber = source.DeviceSerialNumber;
            this.LastScanTime = source.LastScanTime;
            this.Model = source.Model;
            this.Mode = source.Mode;
            this.HasErrors = source.HasErrors;
            this.CallCounter = source.CallCounter;
            this.AckCounter = source.AckCounter;
        }
        */
        #endregion

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

    #endregion

    #region Plaza

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

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _plazaId.GetHashCode();
        }
        /// <summary>
        /// Equals overrides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

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

    #endregion

    #region Job

    /// <summary>
    /// The Job Class.
    /// </summary>
    public class Job
    {
        #region Internal Variables

        private DateTime _jobBegin = DateTime.MinValue;
        private DateTime _jobEnd = DateTime.MinValue;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}",
                _jobBegin, _jobEnd);
            return result.GetHashCode();
        }
        /// <summary>
        /// Equals overrides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Job Begin Date.
        /// </summary>
        public DateTime JobBegin
        {
            get { return _jobBegin; }
            set
            {
                if (_jobBegin != value)
                {
                    _jobBegin = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("JobBegin"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Job End Date.
        /// </summary>
        public DateTime JobEnd
        {
            get { return _jobEnd; }
            set
            {
                if (_jobEnd != value)
                {
                    _jobEnd = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("JobEnd"));
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

    #endregion

    #region Shift

    /// <summary>
    /// The Shift Class.
    /// </summary>
    public class Shift
    {
        #region Internal Variables

        private int _shiftId = 0;
        private DateTime _shiftBegin = DateTime.MinValue;
        private DateTime _shiftEnd = DateTime.MinValue;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}_{2}", 
                _shiftId, _shiftBegin, _shiftEnd);
            return result.GetHashCode();
        }
        /// <summary>
        /// Equals overrides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Shift Id.
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
        /// <summary>
        /// Gets or sets Shift Begin Date.
        /// </summary>
        public DateTime ShiftBegin
        {
            get { return _shiftBegin; }
            set
            {
                if (_shiftBegin != value)
                {
                    _shiftBegin = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ShiftBegin"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Shift End Date.
        /// </summary>
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

    #endregion

    #region Staff

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

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _staffId.GetHashCode();
        }
        /// <summary>
        /// Equals overrides.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

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

    #endregion
}
