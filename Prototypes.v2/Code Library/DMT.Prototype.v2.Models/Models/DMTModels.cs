#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NLib;

// required for JsonIgnore.
using Newtonsoft.Json;

#endregion

namespace DMT.Sample
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
}

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
            string fileName = NJson.LocalFile("sample.json");

            //string json = list.ToJson();
            //Console.WriteLine(json);

            if (!list.SaveToFile(fileName))
            {
                Console.WriteLine("Cannot save file.");
            }

            List<X> list2;
            list2 = NJson.LoadFromFile<List<X>>(fileName);
            Console.WriteLine(list2);
            Console.WriteLine(list2.ToJson());
        }
    }

    #endregion

    #region DMTBaseModel (abstract)

    /// <summary>
    /// The DMTBaseModel abstract class.
    /// Provide basic implementation of INotifyPropertyChanged interface.
    /// </summary>
    public abstract class DMTBaseModel : INotifyPropertyChanged
    {
        #region Private Methods

        /// <summary>
        /// Raise Property Changed Event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected void RaiseChanged(string propertyName)
        {
            PropertyChanged.Call(this, new PropertyChangedEventArgs(propertyName));
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

    #region DMTModel

    /// <summary>
    /// The DMT Model class.
    /// </summary>
    public class DMTModel : DMTBaseModel
    {
        #region Internal Variables

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
    public class Plaza : DMTBaseModel
    {
        #region Internal Variables

        private string _appMode = string.Empty;
        private string _plazaId = string.Empty;
        private string _plazaName = string.Empty;
        private Shift _shift;
        private Staff _supervisor;

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
        /// Gets or sets Application mode.
        /// </summary>
        public string Mode
        {
            get { return _appMode; }
            set
            {
                if (_appMode != value)
                {
                    _appMode = value;
                    // Raise event.
                    RaiseChanged("Mode");
                }
            }
        }
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
                    RaiseChanged("PlazaId");
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
                    RaiseChanged("PlazaName");
                }
            }
        }

        /// <summary>
        /// Gets Current Shift.
        /// </summary>
        public Shift Shift
        {
            get { return _shift;  }
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    // Raise event.
                    RaiseChanged("Shift");
                    RaiseChanged("ShiftId");
                    RaiseChanged("ShiftDate");
                    RaiseChanged("ShiftTime");
                }
            }
        }
        /// <summary>
        /// Gets Current Shift Id.
        /// </summary>
        [JsonIgnore]
        public string ShiftId
        {
            get { return (null != _shift) ? _shift.ShiftId.ToString() : ""; }
        }
        /// <summary>
        /// Gets Current Shift Begin date (in string).
        /// </summary>
        [JsonIgnore]
        public string ShiftDate
        {
            get { return (null != _shift) ? _shift.BeginDateString : ""; }
        }
        /// <summary>
        /// Gets Current Shift Begin time (in string).
        /// </summary>
        [JsonIgnore]
        public string ShiftTime
        {
            get { return (null != _shift) ? _shift.BeginTimeString : ""; }
        }

        /// <summary>
        /// Gets Current Supervisor.
        /// </summary>
        public Staff Supervisor
        {
            get { return _supervisor; }
            set
            {
                if (_supervisor != value)
                {
                    _supervisor = value;
                    // Raise event.
                    RaiseChanged("Supervisor");
                    RaiseChanged("SupervisorId");
                    RaiseChanged("SupervisorName");
                }
            }
        }
        /// <summary>
        /// Gets Current supervisor Id.
        /// </summary>
        [JsonIgnore]
        public string SupervisorId
        {
            get { return (null != _supervisor) ? _supervisor.StaffId.ToString() : ""; }
        }
        /// <summary>
        /// Gets Current supervisor name.
        /// </summary>
        [JsonIgnore]
        public string SupervisorName
        {
            get { return (null != _supervisor) ? _supervisor.StaffName : ""; }
        }

        #endregion
    }

    #endregion

    #region Job

    /// <summary>
    /// The Job Class.
    /// </summary>
    public class Job : DMTBaseModel
    {
        #region Internal Variables

        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MinValue;

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
                _begin, _end);
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
        public DateTime Begin
        {
            get { return _begin; }
            set
            {
                if (_begin != value)
                {
                    _begin = value;
                    // Raise event.
                    RaiseChanged("Begin");
                    RaiseChanged("BeginDateString");
                    RaiseChanged("BeginTimeString");
                }
            }
        }
        /// <summary>
        /// Gets or sets Job End Date.
        /// </summary>
        public DateTime End
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    // Raise event.
                    RaiseChanged("End");
                    RaiseChanged("EndDateString");
                    RaiseChanged("EndTimeString");
                }
            }
        }
        /// <summary>
        /// Gets Begin Date String.
        /// </summary>
        [JsonIgnore]
        public string BeginDateString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("yyyy-MM-dd");
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets End Date String.
        /// </summary>
        [JsonIgnore]
        public string EndDateString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("yyyy-MM-dd");
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets Begin Time String.
        /// </summary>
        [JsonIgnore]
        public string BeginTimeString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiTimeString();
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets End Time String.
        /// </summary>
        [JsonIgnore]
        public string EndTimeString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        #endregion
    }

    #endregion

    #region Shift

    /// <summary>
    /// The Shift Class.
    /// </summary>
    public class Shift : DMTBaseModel
    {
        #region Internal Variables

        private int _shiftId = 0;
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MinValue;

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
                _shiftId, _begin, _end);
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
                    RaiseChanged("ShiftId");
                }
            }
        }
        /// <summary>
        /// Gets or sets Shift Begin Date.
        /// </summary>
        public DateTime Begin
        {
            get { return _begin; }
            set
            {
                if (_begin != value)
                {
                    _begin = value;
                    // Raise event.
                    RaiseChanged("Begin");
                    RaiseChanged("BeginDateString");
                    RaiseChanged("BeginTimeString");
                }
            }
        }
        /// <summary>
        /// Gets or sets Shift End Date.
        /// </summary>
        public DateTime End
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    // Raise event.
                    RaiseChanged("End");
                    RaiseChanged("EndDateString");
                    RaiseChanged("EndTimeString");
                }
            }
        }
        /// <summary>
        /// Gets Begin Date String.
        /// </summary>
        [JsonIgnore]
        public string BeginDateString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("yyyy-MM-dd");
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets End Date String.
        /// </summary>
        [JsonIgnore]
        public string EndDateString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("yyyy-MM-dd");
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets Begin Time String.
        /// </summary>
        [JsonIgnore]
        public string BeginTimeString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiTimeString();
                return ret;
            }
            set { }
        }
        /// <summary>
        /// Gets End Time String.
        /// </summary>
        [JsonIgnore]
        public string EndTimeString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        #endregion
    }

    #endregion

    #region Staff

    /// <summary>
    /// The Staff class.
    /// </summary>
    public class Staff : DMTBaseModel
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
                    RaiseChanged("Role");
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
                    RaiseChanged("StaffId");
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
                    RaiseChanged("StaffName");
                }
            }
        }

        #endregion
    }

    #endregion
}
