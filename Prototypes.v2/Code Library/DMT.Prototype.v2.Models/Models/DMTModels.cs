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
                _laneId, _staffId, _staffName, _begin, _end);
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

namespace DMT.Models
{

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
                var ret = (_revDate == DateTime.MinValue) ? "" : _revDate.ToThaiDateTimeString("yyyy-MM-dd");
                return ret;
            }
            set { }
        }

        #endregion
    }

    #endregion
}