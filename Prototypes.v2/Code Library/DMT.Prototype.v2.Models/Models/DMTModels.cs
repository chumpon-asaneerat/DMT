#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using NLib;
using DMT;

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
}

namespace DMT.Models
{
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

        private int _shiftId = 0;
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MinValue;
        private string _staffId = string.Empty;
        private string _staffName = string.Empty;

        private List<Lane> _lanes = new List<Lane>();

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}_{2}_{3}_{4}",
                _shiftId, _staffId, _staffName, _begin, _end);
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

        #region Public Methods

        public void AddLane(int laneId, 
            DateTime begin, DateTime end)
        {
            Lane lane = new Lane();
            lane.LaneId = laneId;
            lane.Begin = begin;
            lane.End = end;
            lane.StaffId = _staffId;
            lane.StaffName = _staffName;
            this.Lanes.Add(lane);
        }
        /// <summary>
        /// End Job.
        /// </summary>
        public void EndJob()
        {
            if (!string.IsNullOrWhiteSpace(_staffId) &&
                !string.IsNullOrWhiteSpace(_staffName) &&
                _shiftId > 0 && _shiftId <= 3)
            {
                string _fileName = NJson.LocalFile("job." + _staffId + ".json");
                if (NJson.Exists(_fileName))
                {
                    this.End = DateTime.Now;
                    this.SaveToFile(_fileName); // update end datetime.
                    // should delete file.
                }
            }
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
        /// <summary>
        /// Access Lanes.
        /// </summary>
        public List<Lane> Lanes
        {
            get
            {
                if (null == _lanes) _lanes = new List<Lane>();
                return _lanes;
            }
            set {
                if (_lanes != value)
                {
                    _lanes = value;
                    if (null == _lanes) _lanes = new List<Lane>();
                }
            }
        }
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
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("dd/MM/yyyy");
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
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("dd/MM/yyyy");
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

        #region Static Methods

        /// <summary>
        /// Begin Job.
        /// </summary>
        /// <param name="staffId">The staff Id.</param>
        /// <param name="staffName">The staff Name.</param>
        /// <param name="shiftId">The shift Id.</param>
        /// <returns>Returns new Job instance.</returns>
        public static Job BeginJob(string staffId, string staffName, int shiftId)
        {
            Job job = null;
            if (!string.IsNullOrWhiteSpace(staffId) &&
                !string.IsNullOrWhiteSpace(staffName) &&
                shiftId > 0 && shiftId <= 3)
            {
                string _fileName = NJson.LocalFile("job." + staffId + ".json");
                if (!NJson.Exists(_fileName))
                {
                    job = new Job();
                    job.ShiftId = shiftId;
                    job.StaffId = staffId;
                    job.StaffName = staffName;
                    job.Begin = DateTime.Now;

                    job.AddLane(3, DateTime.Now, DateTime.Now.AddHours(4).AddMinutes(22).AddSeconds(33));
                    job.AddLane(1, DateTime.Now.AddHours(5), DateTime.Now.AddHours(6).AddMinutes(17).AddSeconds(12));
                    job.AddLane(6, DateTime.Now.AddHours(12), DateTime.Now.AddHours(3).AddMinutes(39).AddSeconds(23));

                    job.SaveToFile(_fileName);
                }
                job = NJson.LoadFromFile<Job>(_fileName);
            }

            return job;
        }
        /// <summary>
        /// Find Job.
        /// </summary>
        /// <param name="staffId">The staff Id.</param>
        /// <returns>Returns new Job instance.</returns>
        public static Job FindJob(string staffId)
        {
            Job job = null;
            if (!string.IsNullOrWhiteSpace(staffId))
            {
                string _fileName = NJson.LocalFile("job." + staffId + ".json");
                if (NJson.Exists(_fileName))
                {
                    job = NJson.LoadFromFile<Job>(_fileName);
                    if (null != job && null != job.Lanes)
                    {
                        foreach (Lane lane in job.Lanes)
                        {
                            lane.StaffId = job.StaffId;
                            lane.StaffName = job.StaffName;
                        }
                    }
                }
            }

            return job;
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
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("dd/MM/yyyy");
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
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("dd/MM/yyyy");
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

    #region Lane

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class Lane : DMTBaseModel
    {
        #region Internal Variables

        private int _laneId = 1;
        private string _staffId = string.Empty;
        private string _staffName = string.Empty;
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MinValue;
        private string _shift = string.Empty;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}_{2}_{3}_{4}_{5}",
                _laneId, _staffId, _staffName, _begin, _end,_shift);
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
        /// Gets or sets lane id.
        /// </summary>
        public int LaneId
        {
            get { return _laneId; }
            set
            {
                if (_laneId != value)
                {
                    _laneId = value;
                    // Raise event.
                    RaiseChanged("LaneId");
                }
            }
        }
        /// <summary>
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
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
        [JsonIgnore]
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
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
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
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
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

        [JsonIgnore]
        public string Shift
        {
            get { return _shift; }
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    // Raise event.
                    RaiseChanged("Shift");
                }
            }
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

    #region QRCodeEntry

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class QRCodeEntry : DMTBaseModel
    {
        #region Internal Variables

        private string _approvalCode = string.Empty;
        private DateTime _dateQR = DateTime.MinValue;
        private decimal? _qty = null;

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
                _approvalCode, _dateQR, _qty);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string ApprovalCode
        {
            get { return _approvalCode; }
            set
            {
                if (_approvalCode != value)
                {
                    _approvalCode = value;
                    // Raise event.
                    RaiseChanged("ApprovalCode");
                }
            }
        }

        /// <summary>
        /// Gets or sets Shift Begin Date.
        /// </summary>
        public DateTime DateQR
        {
            get { return _dateQR; }
            set
            {
                if (_dateQR != value)
                {
                    _dateQR = value;
                    // Raise event.
                    RaiseChanged("DateQR");
                    RaiseChanged("DateQRDateString");
                    RaiseChanged("DateQRTimeString");
                }
            }
        }

        /// <summary>
        /// Gets Begin Date String.
        /// </summary>
        [JsonIgnore]
        public string DateQRDateString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
                return ret;
            }
            set { }
        }

        /// <summary>
        /// Gets Begin Time String.
        /// </summary>
        [JsonIgnore]
        public string DateQRTimeString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        [JsonIgnore]
        public decimal? Qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    // Raise event.
                    RaiseChanged("Qty");
                }
            }
        }
        #endregion
    }

    #endregion

    #region EMV

    /// <summary>
    /// The EMV Class.
    /// </summary>
    public class EMV : DMTBaseModel
    {
        #region Internal Variables

        private string _approvalCode = string.Empty;
        private DateTime _dateQR = DateTime.MinValue;
        private decimal? _qty = null;

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
                _approvalCode, _dateQR, _qty);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string ApprovalCode
        {
            get { return _approvalCode; }
            set
            {
                if (_approvalCode != value)
                {
                    _approvalCode = value;
                    // Raise event.
                    RaiseChanged("ApprovalCode");
                }
            }
        }

        /// <summary>
        /// Gets or sets Shift Begin Date.
        /// </summary>
        public DateTime DateQR
        {
            get { return _dateQR; }
            set
            {
                if (_dateQR != value)
                {
                    _dateQR = value;
                    // Raise event.
                    RaiseChanged("DateQR");
                    RaiseChanged("DateQRDateString");
                    RaiseChanged("DateQRTimeString");
                }
            }
        }

        /// <summary>
        /// Gets Begin Date String.
        /// </summary>
        [JsonIgnore]
        public string DateQRDateString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiDateTimeString("dd/MM/yyyy  HH:mm:ss");
                return ret;
            }
            set { }
        }

        /// <summary>
        /// Gets Begin Time String.
        /// </summary>
        [JsonIgnore]
        public string DateQRTimeString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        [JsonIgnore]
        public decimal? Qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    // Raise event.
                    RaiseChanged("Qty");
                }
            }
        }
        #endregion
    }

    #endregion

    #region EMVQRCode

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class EMVQRCode : DMTBaseModel
    {
        #region Internal Variables

        private int _laneId = 1;
        private string _staffId = string.Empty;
        private string _type = string.Empty;

        private string _approvalCode = string.Empty;
        private DateTime _dateQR = DateTime.MinValue;
        private decimal? _qty = null;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}_{2}_{3}_{4}_{5}",
                _laneId, _staffId, _type, _approvalCode, _dateQR, _qty);
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
        /// Gets or sets lane id.
        /// </summary>
        public int LaneId
        {
            get { return _laneId; }
            set
            {
                if (_laneId != value)
                {
                    _laneId = value;
                    // Raise event.
                    RaiseChanged("LaneId");
                }
            }
        }
        /// <summary>
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
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
        [JsonIgnore]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    // Raise event.
                    RaiseChanged("Type");
                }
            }
        }
        [JsonIgnore]
        public string ApprovalCode
        {
            get { return _approvalCode; }
            set
            {
                if (_approvalCode != value)
                {
                    _approvalCode = value;
                    // Raise event.
                    RaiseChanged("ApprovalCode");
                }
            }
        }
        /// <summary>
        /// Gets or sets Shift Begin Date.
        /// </summary>
        public DateTime DateQR
        {
            get { return _dateQR; }
            set
            {
                if (_dateQR != value)
                {
                    _dateQR = value;
                    // Raise event.
                    RaiseChanged("DateQR");
                    RaiseChanged("DateQRDateString");
                    RaiseChanged("DateQRTimeString");
                }
            }
        }

        /// <summary>
        /// Gets Begin Date String.
        /// </summary>
        [JsonIgnore]
        public string DateQRDateString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
                return ret;
            }
            set { }
        }

        /// <summary>
        /// Gets Begin Time String.
        /// </summary>
        [JsonIgnore]
        public string DateQRTimeString
        {
            get
            {
                var ret = (this.DateQR == DateTime.MinValue) ? "" : this.DateQR.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        [JsonIgnore]
        public decimal? Qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    // Raise event.
                    RaiseChanged("Qty");
                }
            }
        }
        #endregion
    }

    #endregion

    #region Coupon35

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class Coupon35 : DMTBaseModel
    {
        #region Internal Variables


        private string _couponCode = string.Empty;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}",
                _couponCode);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string CouponCode
        {
            get { return _couponCode; }
            set
            {
                if (_couponCode != value)
                {
                    _couponCode = value;
                    // Raise event.
                    RaiseChanged("CouponCode");
                }
            }
        }

        #endregion
    }

    #endregion

    #region Coupon80

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class Coupon80 : DMTBaseModel
    {
        #region Internal Variables


        private string _couponCode = string.Empty;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}",
                _couponCode);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string CouponCode
        {
            get { return _couponCode; }
            set
            {
                if (_couponCode != value)
                {
                    _couponCode = value;
                    // Raise event.
                    RaiseChanged("CouponCode");
                }
            }
        }

        #endregion
    }

    #endregion

    #region CouponUser35

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class CouponUser35 : DMTBaseModel
    {
        #region Internal Variables


        private string _couponCode = string.Empty;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}",
                _couponCode);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string CouponCode
        {
            get { return _couponCode; }
            set
            {
                if (_couponCode != value)
                {
                    _couponCode = value;
                    // Raise event.
                    RaiseChanged("CouponCode");
                }
            }
        }
       
        #endregion
    }

    #endregion

    #region CouponUser80

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class CouponUser80 : DMTBaseModel
    {
        #region Internal Variables


        private string _couponCode = string.Empty;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}",
                _couponCode);
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
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
        public string CouponCode
        {
            get { return _couponCode; }
            set
            {
                if (_couponCode != value)
                {
                    _couponCode = value;
                    // Raise event.
                    RaiseChanged("CouponCode");
                }
            }
        }

        #endregion
    }

    #endregion

    #region LaneDetail

    /// <summary>
    /// The Lane Class.
    /// </summary>
    public class LaneDetail : DMTBaseModel
    {
        #region Internal Variables

        private int _laneId = 1;
        private string _staffId = string.Empty;
        private string _jobNo = string.Empty;
        private DateTime _begin = DateTime.MinValue;
        private DateTime _end = DateTime.MinValue;
        private DateTime _dateTOD = DateTime.MinValue;
        
        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string result = string.Format(
                "{0}_{1}_{2}_{3}_{4}_{5}",
                _laneId, _staffId, _jobNo, _begin, _end, _dateTOD);
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
        /// Gets or sets lane id.
        /// </summary>
        public int LaneId
        {
            get { return _laneId; }
            set
            {
                if (_laneId != value)
                {
                    _laneId = value;
                    // Raise event.
                    RaiseChanged("LaneId");
                }
            }
        }
        /// <summary>
        /// Gets or sets Staff Id.
        /// </summary>
        [JsonIgnore]
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
        /// Gets or sets JobNo.
        /// </summary>
        [JsonIgnore]
        public string JobNo
        {
            get { return _jobNo; }
            set
            {
                if (_jobNo != value)
                {
                    _jobNo = value;
                    // Raise event.
                    RaiseChanged("JobNo");
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

        public DateTime DateTOD
        {
            get { return _dateTOD; }
            set
            {
                if (_dateTOD != value)
                {
                    _dateTOD = value;
                    // Raise event.
                    RaiseChanged("DateTOD");
                    RaiseChanged("DateTODDateString");
                    RaiseChanged("DateTODTimeString");
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
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
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
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToThaiDateTimeString("dd/MM/yyyy  HH:mm:ss");
                return ret;
            }
            set { }
        }

        [JsonIgnore]
        public string DateTODDateString
        {
            get
            {
                var ret = (this.DateTOD == DateTime.MinValue) ? "" : this.DateTOD.ToThaiDateTimeString("dd/MM/yyyy HH:mm:ss");
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

        [JsonIgnore]
        public string DateTODTimeString
        {
            get
            {
                var ret = (this.DateTOD == DateTime.MinValue) ? "" : this.DateTOD.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        #endregion
    }

    #endregion
}

namespace DMT.Models
{
    #region Revenue Entry

    /// <summary>
    /// The RevenueEntry class.
    /// </summary>
    public class RevenueEntry : DMTBaseModel
    {
        #region Internal Variables

        private string _bagNo = string.Empty;
        private TrafficEntry _traffic = null;
        private OtherEntry _other = null;
        private CouponUsageEntry _couponUsage = null;
        private CouponRevenueEntry _couponRevenue = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Bag Number.
        /// </summary>
        public string BagNo
        {
            get { return _bagNo; }
            set
            {
                if (_bagNo != value)
                {
                    _bagNo = value;
                    // Raise event.
                    RaiseChanged("BagNo");
                }
            }
        }

        public TrafficEntry Traffic
        {
            get
            {
                if (null == _traffic) _traffic = new TrafficEntry();
                return _traffic;
            }
            set
            {
                _traffic = value;
                if (null == _traffic) _traffic = new TrafficEntry();
                // Raise event.
                RaiseChanged("Traffic");
            }
        }

        public OtherEntry Other
        {
            get
            {
                if (null == _other) _other = new OtherEntry();
                return _other;
            }
            set
            {
                _other = value;
                if (null == _other) _other = new OtherEntry();
                // Raise event.
                RaiseChanged("Other");
            }
        }

        public CouponUsageEntry CouponUsage
        {
            get
            {
                if (null == _couponUsage) _couponUsage = new CouponUsageEntry();
                return _couponUsage;
            }
            set
            {
                _couponUsage = value;
                if (null == _couponUsage) _couponUsage = new CouponUsageEntry();
                // Raise event.
                RaiseChanged("CouponUsage");
            }
        }

        public CouponRevenueEntry CouponRevenue
        {
            get
            {
                if (null == _couponRevenue) _couponRevenue = new CouponRevenueEntry();
                return _couponRevenue;
            }
            set
            {
                _couponRevenue = value;
                if (null == _couponRevenue) _couponRevenue = new CouponRevenueEntry();
                // Raise event.
                RaiseChanged("CouponRevenue");
            }
        }

        #endregion
    }

    #endregion

    #region Traffic Entry

    public class TrafficEntry : DMTBaseModel
    {
        #region Internal Variables

        private int _BHT1 = 0;
        private int _BHT2 = 0;
        private int _BHT5 = 0;
        private int _BHT10c = 0;
        private int _BHT10b = 0;
        private int _BHT20 = 0;
        private int _BHT50 = 0;
        private int _BHT100 = 0;
        private int _BHT500 = 0;
        private int _BHT1000 = 0;
        private decimal _BHTTotal = 0;
        private bool _hasRemark = true;
        private string _remark = "";

        #endregion

        #region Private Methods

        private void CalcTotal()
        {
            decimal total = 0;
            total += _BHT1 * 1;
            total += _BHT2 * 2;
            total += _BHT5 * 5;
            total += _BHT10c * 10;
            total += _BHT10b * 10;
            total += _BHT20 * 20;
            total += _BHT50 * 50;
            total += _BHT100 * 100;
            total += _BHT500 * 500;
            total += _BHT1000 * 1000;

            _BHTTotal = total;
            // Raise event.
            RaiseChanged("BHTTotal");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets number of 1 baht coin.
        /// </summary>
        public int BHT1
        {
            get { return _BHT1; }
            set
            {
                if (_BHT1 != value)
                {
                    _BHT1 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT1");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 2 baht coin.
        /// </summary>
        public int BHT2
        {
            get { return _BHT2; }
            set
            {
                if (_BHT2 != value)
                {
                    _BHT2 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT2");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 5 baht coin.
        /// </summary>
        public int BHT5
        {
            get { return _BHT5; }
            set
            {
                if (_BHT5 != value)
                {
                    _BHT5 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT5");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 10 baht coin.
        /// </summary>
        public int BHT10c
        {
            get { return _BHT10c; }
            set
            {
                if (_BHT10c != value)
                {
                    _BHT10c = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT10c");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 10 baht bill.
        /// </summary>
        public int BHT10b
        {
            get { return _BHT10b; }
            set
            {
                if (_BHT10b != value)
                {
                    _BHT10b = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT10b");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 20 baht bill.
        /// </summary>
        public int BHT20
        {
            get { return _BHT20; }
            set
            {
                if (_BHT20 != value)
                {
                    _BHT20 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT20");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 50 baht bill.
        /// </summary>
        public int BHT50
        {
            get { return _BHT50; }
            set
            {
                if (_BHT50 != value)
                {
                    _BHT50 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT50");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 100 baht bill.
        /// </summary>
        public int BHT100
        {
            get { return _BHT100; }
            set
            {
                if (_BHT100 != value)
                {
                    _BHT100 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT100");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 500 baht bill.
        /// </summary>
        public int BHT500
        {
            get { return _BHT500; }
            set
            {
                if (_BHT500 != value)
                {
                    _BHT500 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT500");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 1000 baht bill.
        /// </summary>
        public int BHT1000
        {
            get { return _BHT1000; }
            set
            {
                if (_BHT1000 != value)
                {
                    _BHT1000 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT1000");
                }
            }
        }
        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set { }
        }
        /// <summary>
        /// Gets or sets has remark.
        /// </summary>
        public bool HasRemark
        {
            get { return _hasRemark; }
            set
            {
                if (_hasRemark != value)
                {
                    _hasRemark = value;
                    // Raise event.
                    RaiseChanged("HasRemark");
                    RaiseChanged("RemarkVisibility");
                }
            }
        }
        /// <summary>
        /// Gets or sets Remark.
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    // Raise event.
                    //RaiseChanged("Remark");
                }
            }
        }
        /// <summary>
        /// Gets RemarkVisibility.
        /// </summary>
        public System.Windows.Visibility RemarkVisibility
        {
            get { return (_hasRemark) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }

        #endregion
    }

    #endregion

    #region Other Entry

    public class OtherEntry : DMTBaseModel
    {
        #region Internal Variables

        private decimal _BHTTotal = 0;
        private bool _hasRemark = true;
        private string _remark = "";

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set 
            { 
                if (_BHTTotal != value)
                {
                    _BHTTotal = value;
                    // Raise event.
                    RaiseChanged("BHTTotal");
                }
            }
        }
        /// <summary>
        /// Gets or sets has remark.
        /// </summary>
        public bool HasRemark
        {
            get { return _hasRemark; }
            set
            {
                if (_hasRemark != value)
                {
                    _hasRemark = value;
                    // Raise event.
                    RaiseChanged("HasRemark");
                    RaiseChanged("RemarkVisibility");
                }
            }
        }
        /// <summary>
        /// Gets or sets Remark.
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    // Raise event.
                    //RaiseChanged("Remark");
                }
            }
        }
        /// <summary>
        /// Gets RemarkVisibility.
        /// </summary>
        public System.Windows.Visibility RemarkVisibility
        {
            get { return (_hasRemark) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }

        #endregion
    }

    #endregion

    #region Coupon Usage Entry

    /// <summary>
    /// The CouponUsageEntry class.
    /// </summary>
    public class CouponUsageEntry : DMTBaseModel
    {
        #region Internal Variables

        private int _BHT30 = 0;
        private int _BHT35 = 0;
        private int _BHT75 = 0;
        private int _BHT80 = 0;
        private int _FreePass = 0;
        private decimal _CntTotal = 0;
        private decimal _BHTTotal = 0;

        #endregion

        #region Private Methods

        private void CalcTotal()
        {
            int cnt = 0;
            cnt += _BHT30;
            cnt += _BHT35;
            cnt += _BHT75;
            cnt += _BHT80;
            cnt += _FreePass;
            _CntTotal = cnt;

            // Raise event.
            RaiseChanged("CntTotal");

            decimal total = 0;
            total += _BHT30 * 30;
            total += _BHT35 * 35;
            total += _BHT75 * 75;
            total += _BHT80 * 80;
            total += _FreePass * 0;

            _BHTTotal = total;
            // Raise event.
            RaiseChanged("BHTTotal");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets number of 30 BHT coupon.
        /// </summary>
        public int BHT30
        {
            get { return _BHT30; }
            set
            {
                if (_BHT30 != value)
                {
                    _BHT30 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT30");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 35 BHT coupon.
        /// </summary>
        public int BHT35
        {
            get { return _BHT35; }
            set
            {
                if (_BHT35 != value)
                {
                    _BHT35 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT35");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 75 BHT coupon.
        /// </summary>
        public int BHT75
        {
            get { return _BHT75; }
            set
            {
                if (_BHT75 != value)
                {
                    _BHT75 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT75");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 80 BHT coupon.
        /// </summary>
        public int BHT80
        {
            get { return _BHT80; }
            set
            {
                if (_BHT80 != value)
                {
                    _BHT80 = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT80");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of FreePass.
        /// </summary>
        public int FreePass
        {
            get { return _FreePass; }
            set
            {
                if (_FreePass != value)
                {
                    _FreePass = value;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("FreePass");
                }
            }
        }
        /// <summary>
        /// Gets or sets total coupon count (all type).
        /// </summary>
        public decimal CntTotal
        {
            get { return _CntTotal; }
            set { }
        }
        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set { }
        }

        #endregion
    }

    #endregion

    #region Coupon Revenue Entry

    public class CouponRevenueEntry : DMTBaseModel
    {
        #region Internal Variables

        private int _BHT35 = 0;
        private int _BHT80 = 0;
        private int _BHT35Total = 0;
        private int _BHT80Total = 0;
        private int _BHTTotal = 0;

        #endregion

        #region Private Methods

        private void CalcTotal()
        {
            // Raise event.
            RaiseChanged("CntTotal");

            int total = 0;
            total += _BHT35Total;
            total += _BHT80Total;

            _BHTTotal = total;
            // Raise event.
            RaiseChanged("BHTTotal");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets number of 35 BHT coupon.
        /// </summary>
        public int BHT35
        {
            get { return _BHT35; }
            set
            {
                if (_BHT35 != value)
                {
                    _BHT35 = value;
                    _BHT35Total = _BHT35 * 665;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT35");
                    RaiseChanged("BHT35Total");
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 80 BHT coupon.
        /// </summary>
        public int BHT80
        {
            get { return _BHT80; }
            set
            {
                if (_BHT80 != value)
                {
                    _BHT80 = value;
                    _BHT80Total = _BHT80 * 1520;
                    CalcTotal();
                    // Raise event.
                    RaiseChanged("BHT80");
                    RaiseChanged("BHT80Total");
                }
            }
        }

        public int BHT35Total
        {
            get { return _BHT35Total; }
            set { }
        }

        public int BHT80Total 
        {
            get { return _BHT80Total; }
            set { }
        }
        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set { }
        }

        #endregion
    }

    #endregion

    #region Daily Revenue Slip

    /// <summary>
    /// The DailyRevenueSlip class.
    /// </summary>
    public class DailyRevenueSlip : DMTBaseModel
    {
        #region Internal Variables

        private List<RevenueSlip> _slips = new List<RevenueSlip>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets slips.
        /// </summary>
        public List<RevenueSlip> Slips
        {
            get 
            {
                if (null == _slips) _slips = new List<RevenueSlip>();
                return _slips;
            }
            set
            {
                _slips = value;
                if (null == _slips) _slips = new List<RevenueSlip>();
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets daily slips.
        /// </summary>
        /// <returns>Returns DailyRevenueSlip instance.</returns>
        public static DailyRevenueSlip GetDailySlip()
        {
            DailyRevenueSlip inst = null;
            string _fileName = NJson.LocalFile("daily-revenue.slips.json");
            if (!NJson.Exists(_fileName))
            {
                inst = new DailyRevenueSlip();

                RevenueSlip slip;
                slip = new RevenueSlip();
                slip.BagNo = "013";
                slip.StaffId = "14566";
                slip.StaffName = "นางสาว สุณิสา อีนูน";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "020";
                slip.StaffId = "17081";
                slip.StaffName = "นาย ผจญ สุดศิริ";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "014";
                slip.StaffId = "22503";
                slip.StaffName = "นวย วิรชัย ขำหิรัญ";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "019";
                slip.StaffId = "15097";
                slip.StaffName = "นาง วาสนา ชาญวิเศษ";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "016";
                slip.StaffId = "11045";
                slip.StaffName = "นาย บุญส่ง บุญปลื้ม";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "016";
                slip.StaffId = "11045";
                slip.StaffName = "นาย บุญส่ง บุญปลื้ม";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                slip = new RevenueSlip();
                slip.BagNo = "021";
                slip.StaffId = "16097";
                slip.StaffName = "นาย สมชาย ตุยเอียว";
                slip.RevenueDate = DateTime.Today;
                inst.Slips.Add(slip);

                inst.SaveToFile(_fileName);
            }
            inst = NJson.LoadFromFile<DailyRevenueSlip>(_fileName);
            return inst;
        }

        #endregion
    }

    #endregion

    #region Revenue Slip

    /// <summary>
    /// The RevenueSlip class.
    /// </summary>
    public class RevenueSlip : DMTBaseModel
    {
        #region Internal Variables

        private string _bagNo = string.Empty;
        private string _staffId = string.Empty;
        private string _staffName = string.Empty;
        private DateTime _revDate = DateTime.MinValue;

        #endregion

        #region Overrides

        /// <summary>
        /// GetHashCode overrides.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _bagNo.GetHashCode();
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
        /// Gets or sets Bag Number.
        /// </summary>
        public string BagNo
        {
            get { return _bagNo; }
            set
            {
                if (_bagNo != value)
                {
                    _bagNo = value;
                    // Raise event.
                    RaiseChanged("BagNo");
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

        /// <summary>
        /// Gets Revenue Date.
        /// </summary>
        public DateTime RevenueDate
        {
            get { return _revDate; }
            set
            {
                if (_revDate != value)
                {
                    _revDate = value;
                    // Raise event.
                    RaiseChanged("RevenueDate");
                    RaiseChanged("RevenueDateString");
                }
            }
        }
        /// <summary>
        /// Gets Revenue Date String.
        /// </summary>
        [JsonIgnore]
        public string RevenueDateString
        {
            get
            {
                var ret = (_revDate == DateTime.MinValue) ? "" : _revDate.ToThaiDateTimeString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }

        #endregion
    }

    #endregion
}

namespace DMT.Models
{
    public class Coupon
    {
        public Coupon()
        {
            this.Date = DateTime.MinValue;
        }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public int Lane { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string DateString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiDateString();
                return ret;
            }
            set { }
        }
        public string TimeString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        public int Count80 { get; set; }
    }
}

namespace DMT.Models
{
    #region FundEntry

    /// <summary>
    /// The FundEntry Class.
    /// </summary>
    public class FundEntry : INotifyPropertyChanged
    {
        #region Internal Variables

        private string _bagNo = string.Empty;
        private string _beltNo = string.Empty;
        private string _desc = "";
        private string _descDetail = "";

        private int _BHT1 = 0;
        private int _BHT2 = 0;
        private int _BHT5 = 0;
        private int _BHT10c = 0;
        private int _BHT20 = 0;
        private int _BHT50 = 0;
        private int _BHT100 = 0;
        private int _BHT500 = 0;
        private int _BHT1000 = 0;
        private decimal _BHTTotal = 0;
        private bool _hasRemark = true;
        private string _remark = "";

        private bool _receivedBag = true;

        private string _Side = string.Empty;

        private decimal _EXCHANGE = 0;
        private decimal _BORROW = 0;
        private decimal _REVOLVINGFUNDS = 0;
        private decimal _TOTALAMOUNT = 0;

        private string _list = "";
        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public FundEntry() : base()
        {
            this.Date = DateTime.MinValue;
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~FundEntry() { }

        #endregion

        #region Private Methods

        private void CalcTotal()
        {
            decimal total = 0;
            total += _BHT1;
            total += _BHT2 * 2;
            total += _BHT5 * 5;
            total += _BHT10c * 10;
            total += _BHT20 * 20;
            total += _BHT50 * 50;
            total += _BHT100 * 100;
            total += _BHT500 * 500;
            total += _BHT1000 * 1000;

            _BHTTotal = total;
            // Raise event.
            PropertyChanged.Call(this, new PropertyChangedEventArgs("BHTTotal"));
        }

        private void CalcTotalAmount()
        {
            decimal total = 0;
            total += _EXCHANGE;
            total += _BORROW;
            total += _REVOLVINGFUNDS;

            _TOTALAMOUNT = total;
            // Raise event.
            PropertyChanged.Call(this, new PropertyChangedEventArgs("TOTALAMOUNT"));
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Bag Number.
        /// </summary>
        public string BagNo
        {
            get { return _bagNo; }
            set
            {
                if (_bagNo != value)
                {
                    _bagNo = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BagNo"));
                }
            }
        }

        public string BeltNo
        {
            get { return _beltNo; }
            set
            {
                if (_beltNo != value)
                {
                    _beltNo = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BeltNo"));
                }
            }
        }

        public string Description
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    _desc = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 1 baht coin.
        /// </summary>
        public int BHT1
        {
            get { return _BHT1; }
            set
            {
                if (_BHT1 != value)
                {
                    _BHT1 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 2 baht coin.
        /// </summary>
        public int BHT2
        {
            get { return _BHT2; }
            set
            {
                if (_BHT2 != value)
                {
                    _BHT2 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT2"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 5 baht coin.
        /// </summary>
        public int BHT5
        {
            get { return _BHT5; }
            set
            {
                if (_BHT5 != value)
                {
                    _BHT5 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT5"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 10 baht coin.
        /// </summary>
        public int BHT10c
        {
            get { return _BHT10c; }
            set
            {
                if (_BHT10c != value)
                {
                    _BHT10c = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT10c"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 20 baht bill.
        /// </summary>
        public int BHT20
        {
            get { return _BHT20; }
            set
            {
                if (_BHT20 != value)
                {
                    _BHT20 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT20"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 50 baht bill.
        /// </summary>
        public int BHT50
        {
            get { return _BHT50; }
            set
            {
                if (_BHT50 != value)
                {
                    _BHT50 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT50"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 100 baht bill.
        /// </summary>
        public int BHT100
        {
            get { return _BHT100; }
            set
            {
                if (_BHT100 != value)
                {
                    _BHT100 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT100"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 500 baht bill.
        /// </summary>
        public int BHT500
        {
            get { return _BHT500; }
            set
            {
                if (_BHT500 != value)
                {
                    _BHT500 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT500"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 1000 baht bill.
        /// </summary>
        public int BHT1000
        {
            get { return _BHT1000; }
            set
            {
                if (_BHT1000 != value)
                {
                    _BHT1000 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT1000"));
                }
            }
        }
        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set { }
        }
        /// <summary>
        /// Gets or sets has remark.
        /// </summary>
        public bool HasRemark
        {
            get { return _hasRemark; }
            set
            {
                if (_hasRemark != value)
                {
                    _hasRemark = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("HasRemark"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("RemarkVisibility"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Remark.
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Remark"));
                }
            }
        }
        public System.Windows.Visibility RemarkVisibility
        {
            get { return (_hasRemark) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
        }


        /// <summary>
        /// Gets or sets Is Receive dBag.
        /// </summary>
        public bool ReceivedBag
        {
            get { return _receivedBag; }
            set
            {
                if (_receivedBag != value)
                {
                    _receivedBag = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ReceivedBag"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ReceivedBagColor"));
                }
            }
        }

        public System.Windows.Media.Color ReceivedBagColor
        {
            get { return (_receivedBag) ? System.Windows.Media.Colors.DimGray : System.Windows.Media.Colors.Black; }
        }


        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime Date { get; set; }
        public int Lane { get; set; }
        public string DateString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiDateString();
                return ret;
            }
            set { }
        }
        public string TimeString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        public string Side
        {
            get { return _Side; }
            set
            {
                if (_Side != value)
                {
                    _Side = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Side"));
                }
            }
        }

        public string DescriptionDetail
        {
            get { return _descDetail; }
            set
            {
                if (_descDetail != value)
                {
                    _descDetail = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("DescriptionDetail"));
                }
            }
        }
        public decimal EXCHANGE
        {
            get { return _EXCHANGE; }
            set
            {
                if (_EXCHANGE != value)
                {
                    _EXCHANGE = value;
                    CalcTotalAmount();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("EXCHANGE"));
                }
            }
        }

        public decimal BORROW
        {
            get { return _BORROW; }
            set
            {
                if (_BORROW != value)
                {
                    _BORROW = value;
                    CalcTotalAmount();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BORROW"));
                }
            }
        }

        public decimal REVOLVINGFUNDS
        {
            get { return _REVOLVINGFUNDS; }
            set
            {
                if (_REVOLVINGFUNDS != value)
                {
                    _REVOLVINGFUNDS = value;
                    CalcTotalAmount();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("REVOLVINGFUNDS"));
                }
            }
        }

        public decimal TOTALAMOUNT
        {
            get { return _TOTALAMOUNT; }
            set { }
        }

        public string ListType
        {
            get { return _list; }
            set
            {
                if (_list != value)
                {
                    _list = value;
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("ListType"));
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

    #region CouponEntry

    /// <summary>
    /// The CouponEntry Class.
    /// </summary>
    public class CouponEntry : INotifyPropertyChanged
    {
        #region Internal Variables

        private string _desc = "";
        private int _BHT35 = 0;
        private int _BHT80 = 0;
        private decimal _CntTotal = 0;
        private decimal _BHTTotal = 0;
        private bool _hasRemark = true;
        private string _remark = "";

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public CouponEntry() : base() { }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~CouponEntry() { }

        #endregion

        #region Private Methods

        private void CalcTotal()
        {
            int cnt = 0;
            cnt += _BHT35;
            cnt += _BHT80;
            _CntTotal = cnt;

            // Raise event.
            PropertyChanged.Call(this, new PropertyChangedEventArgs("CntTotal"));

            decimal total = 0;
            total += _BHT35 * 665;
            total += _BHT80 * 1520;

            _BHTTotal = total;
            // Raise event.
            PropertyChanged.Call(this, new PropertyChangedEventArgs("BHTTotal"));
        }

        #endregion

        #region Public Properties

        public string Description
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    _desc = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 35 BHT coupon.
        /// </summary>
        public int BHT35
        {
            get { return _BHT35; }
            set
            {
                if (_BHT35 != value)
                {
                    _BHT35 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT35"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of 80 BHT coupon.
        /// </summary>
        public int BHT80
        {
            get { return _BHT80; }
            set
            {
                if (_BHT80 != value)
                {
                    _BHT80 = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("BHT80"));
                }
            }
        }
        /// <summary>
        /// Gets or sets total coupon count (all type).
        /// </summary>
        public decimal CntTotal
        {
            get { return _CntTotal; }
            set { }
        }
        /// <summary>
        /// Gets or sets total value in baht.
        /// </summary>
        public decimal BHTTotal
        {
            get { return _BHTTotal; }
            set { }
        }
        /// <summary>
        /// Gets or sets has remark.
        /// </summary>
        public bool HasRemark
        {
            get { return _hasRemark; }
            set
            {
                if (_hasRemark != value)
                {
                    _hasRemark = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("HasRemark"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("RemarkVisibility"));
                }
            }
        }
        /// <summary>
        /// Gets or sets Remark.
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Remark"));
                }
            }
        }
        public System.Windows.Visibility RemarkVisibility
        {
            get { return (_hasRemark) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed; }
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

    #region FundExchange

    /// <summary>
    /// The FundExchange class.
    /// </summary>
    public class FundExchange
    {
        #region Internal Variable

        private int _statusId = 0;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public FundExchange() : base()
        {
            this.Date = DateTime.MinValue;
            this.IsEditing = false;
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~FundExchange()
        {
        }

        #endregion

        #region Public Methods

        public void Calculate()
        {
            if (null != Plaza && null != Request && null != Exchange && null != TrueRecive && null != Result)
            {

            }
        }

        #endregion

        #region Public Properties

        public string StaffId { get; set; }
        public string StaffName { get; set; }

        public int StatusId
        {
            get { return _statusId; }
            set
            {
                if (_statusId != value)
                {
                    _statusId = value;
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("StatusId"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Status"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("CanEdit"));
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("CanExchange"));
                }
            }
        }
        public string Status
        {
            get
            {
                var str = "รออนุมัติ";
                if (_statusId > 0) str = "อนุมัติแล้ว";
                return str;
            }
            set { }
        }
        public bool IsEditing { get; set; }
        public bool CanEdit
        {
            get { return (_statusId == 0); }
            set { }
        }
        public bool CanExchange
        {
            get { return (_statusId > 0); }
            set { }
        }
        public DateTime Date { get; set; }

        public FundEntry Plaza { get; set; }
        public FundEntry Request { get; set; }
        public FundEntry Approve { get; set; }
        public FundEntry Exchange { get; set; }
        public FundEntry Result { get; set; }

        public FundEntry TrueRecive { get; set; }

        public string DateString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiDateString();
                return ret;
            }
            set { }
        }
        public string TimeString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        public decimal BHTTotal
        {
            get
            {
                return (null != Request) ? Request.BHTTotal : 0;
            }
            set { }
        }

        public decimal TOTALAMOUNT
        {
            get
            {
                return (null != Request) ? Request.TOTALAMOUNT : 0;
            }
            set { }
        }
        #endregion

        #region Public Events

        /// <summary>
        /// The PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Static Methods

        /// <summary>
        /// Create New Request Exchange Item.
        /// </summary>
        /// <param name="plaza"></param>
        /// <param name="staffId"></param>
        /// <param name="staffName"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public static Models.FundExchange CreateNewRequest(
            Models.FundEntry plaza, string staffId, string staffName, int statusId)
        {
            DateTime dt = DateTime.Now;
            Models.FundExchange obj = new Models.FundExchange();
            obj.StaffId = staffId;
            obj.StaffName = staffName;
            obj.Date = dt;
            obj.StatusId = statusId;

            obj.Plaza = plaza;
            obj.Plaza.Description = "ธนบัตร/เหรียญ ปัจจุบัน";

            obj.Request = new Models.FundEntry();
            obj.Request.Description = "รายการขอแลกเงินจากด่าน";
            obj.Request.StaffId = staffId;
            obj.Request.StaffName = staffName;
            obj.Request.Date = dt;

            obj.Approve = new Models.FundEntry();
            obj.Approve.Description = "รายการอนุมัติจากบัญชี";
            obj.Approve.StaffId = staffId;
            obj.Approve.StaffName = staffName;
            obj.Approve.Date = dt;

            obj.Exchange = new Models.FundEntry();
            obj.Exchange.Description = "จ่ายออก ธนบัตร/เหรียญ";
            obj.Exchange.StaffId = staffId;
            obj.Exchange.StaffName = staffName;
            obj.Exchange.Date = dt;

            obj.Result = new Models.FundEntry();
            obj.Result.Description = "ยอดรวมคงเหลือ";
            obj.Result.StaffId = staffId;
            obj.Result.StaffName = staffName;
            obj.Result.Date = dt;

            obj.TrueRecive = new Models.FundEntry();
            obj.TrueRecive.Description = "เงินที่ได้รับจริง";
            obj.TrueRecive.StaffId = staffId;
            obj.TrueRecive.StaffName = staffName;
            obj.TrueRecive.Date = dt;

            return obj;
        }

        public static Models.FundExchange CreateNewFundRequest(
            Models.FundEntry plaza, string staffId, string staffName, int statusId)
        {
            DateTime dt = DateTime.Now;
            Models.FundExchange obj = new Models.FundExchange();
            obj.StaffId = staffId;
            obj.StaffName = staffName;
            obj.Date = dt;
            obj.StatusId = statusId;

            obj.Plaza = plaza;
            obj.Plaza.Description = "ธนบัตร/เหรียญ ปัจจุบัน";

            obj.Request = new Models.FundEntry();
            obj.Request.Description = "รายการขอยืม/แลกเงินยืมทอน";
            obj.Request.DescriptionDetail = "รายละเอียดเงินยืมทอน";
            obj.Request.StaffId = staffId;
            obj.Request.StaffName = staffName;
            obj.Request.Date = dt;

            obj.Approve = new Models.FundEntry();
            obj.Approve.Description = "รายการอนุมัติจากบัญชี";

            obj.Approve.StaffId = staffId;
            obj.Approve.StaffName = staffName;
            obj.Approve.Date = dt;

            obj.Exchange = new Models.FundEntry();
            obj.Exchange.Description = "จ่ายออก ธนบัตร/เหรียญ";
            obj.Exchange.StaffId = staffId;
            obj.Exchange.StaffName = staffName;
            obj.Exchange.Date = dt;

            obj.Result = new Models.FundEntry();
            obj.Result.Description = "ยอดรวมคงเหลือ";
            obj.Result.StaffId = staffId;
            obj.Result.StaffName = staffName;
            obj.Result.Date = dt;

            obj.TrueRecive = new Models.FundEntry();
            obj.TrueRecive.Description = "เงินที่ได้รับจริง";
            obj.TrueRecive.StaffId = staffId;
            obj.TrueRecive.StaffName = staffName;
            obj.TrueRecive.Date = dt;

            return obj;
        }

        #endregion
    }

    #endregion

    #region LoanMoneyEntry

    /// <summary>
    /// The FundEntry Class.
    /// </summary>
    public class LoanMoneyEntry : INotifyPropertyChanged
    {
        #region Internal Variables

        private string _desc = "";

        private int _revolvingFunds = 0;
        private int _loanMoney = 0;
        private int _loanMoneyCabinet = 0;

        private decimal _totalAmount = 0;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public LoanMoneyEntry() : base()
        {
            this.Date = DateTime.MinValue;
        }
        /// <summary>
        /// Destructor.
        /// </summary>
        ~LoanMoneyEntry() { }

        #endregion


        #region Public Properties

        public string Description
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    _desc = value;
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of RevolvingFunds.
        /// </summary>
        public int RevolvingFunds
        {
            get { return _revolvingFunds; }
            set
            {
                if (_revolvingFunds != value)
                {
                    _revolvingFunds = value;
                    CalcTotal();
                    // Raise event.
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("RevolvingFunds"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of LoanMoney.
        /// </summary>
        public int LoanMoney
        {
            get { return _loanMoney; }
            set
            {
                if (_loanMoney != value)
                {
                    _loanMoney = value;
                    CalcTotal();
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("LoanMoney"));
                }
            }
        }
        /// <summary>
        /// Gets or sets number of LoanMoneyCabinet.
        /// </summary>
        public int LoanMoneyCabinet
        {
            get { return _loanMoneyCabinet; }
            set
            {
                if (_loanMoneyCabinet != value)
                {
                    _loanMoneyCabinet = value;
                    CalcTotal();
                    PropertyChanged.Call(this, new PropertyChangedEventArgs("LoanMoneyCabinet"));
                }
            }
        }
       
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime Date { get; set; }
        public int Lane { get; set; }
        public string DateString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiDateString();
                return ret;
            }
            set { }
        }
        public string TimeString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToThaiTimeString();
                return ret;
            }
            set { }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { }
        }

        #endregion

        #region Private Methods

        private void CalcTotal()
        {

            decimal total = 0;
            total += _revolvingFunds;
            total += _loanMoney;
            total -= _loanMoneyCabinet;
            _totalAmount = total;
            // Raise event.
            PropertyChanged.Call(this, new PropertyChangedEventArgs("TotalAmount"));
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