using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Models
{
    public class Staff
    {
        public Staff() : base() { }
        ~Staff() { }
        public string CardID { get; set; }
        public string Name { get; set; }
        public string Rule { get; set; }
    }

    public class Supervisor : Staff
    {
        public Supervisor() : base()
        {
            this.Rule = "Supervisor";
        }
        ~Supervisor() { }


        public static List<Supervisor> GetSupervisors()
        {
            List<Supervisor> results = new List<Supervisor>();

            results.Add(new Supervisor()
            {
                CardID = "1400000101",
                Name = ""
            });
            results.Add(new Supervisor()
            {
                CardID = "1400000102",
                Name = "นาง"
            });
            results.Add(new Supervisor()
            {
                CardID = "1400000104",
                Name = "นาย ภักดี อมรรุ่งโรจน์"
            });

            return results;
        }
    }

    public class Collector : Staff
    {
        public Collector() : base()
        {
            this.Rule = "Collector";
        }
        ~Collector() { }

        public static List<Collector> GetCollectors()
        {
            List<Collector> results = new List<Collector>();

            results.Add(new Collector()
            {
                CardID = "14321",
                Name = "นาย สุเทพ เหมัน"
            });
            results.Add(new Collector()
            {
                CardID = "11559",
                Name = "นางวิภา สวัสดิวัฒน์"
            });
            results.Add(new Collector()
            {
                CardID = "13201",
                Name = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์"
            });
            results.Add(new Collector()
            {
                CardID = "12866",
                Name = "นาย ภักดี อมรรุ่งโรจน์"
            });

            return results;
        }
    }

    public class Shift
    {
        private Job _job;
        public Shift(Job job)
        {
            _job = job;
            this.Begin = DateTime.MinValue;
            this.End = DateTime.MinValue;
        }
        ~Shift() { }
        /// <summary>
        /// Gets or sets shift number.
        /// </summary>
        public int No { get; set; }

        public string StaffId 
        {
            get 
            {
                if (null != _job && null != _job.Staff) 
                    return _job.Staff.CardID;
                return string.Empty;
            }
        }

        public int Lane { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public string BeginDateString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }
        public string EndDateString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }
        public string BeginTimeString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToString("HH:mm:ss.fff");
                return ret;
            }
            set { }
        }
        public string EndTimeString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToString("HH:mm:ss.fff");
                return ret;
            }
            set { }
        }
    }

    public class Job
    {
        public Job() : base()
        {
            this.Shifts = new List<Shift>();
            this.Begin = DateTime.MinValue;
            this.End = DateTime.MinValue;
        }
        ~Job() { }
        /// <summary>
        /// Gets or sets shift number.
        /// </summary>
        public int No { get; set; }
        public Staff Staff { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public string BeginDateString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }
        public string EndDateString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }
        public string BeginTimeString
        {
            get
            {
                var ret = (this.Begin == DateTime.MinValue) ? "" : this.Begin.ToString("HH:mm:ss.fff");
                return ret;
            }
            set { }
        }
        public string EndTimeString
        {
            get
            {
                var ret = (this.End == DateTime.MinValue) ? "" : this.End.ToString("HH:mm:ss.fff");
                return ret;
            }
            set { }
        }
        public List<Shift> Shifts;
    }

    #region Plaza

    /// <summary>
    /// The Plaza class.
    /// </summary>
    public class Plaza
    {
        #region Internal Variables

        private List<Collector> _collectors = null;

        #endregion

        #region Constructor and Destructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public Plaza() 
        {
            _collectors = new List<Collector>();
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~Plaza() 
        {
            if (null != _collectors) _collectors.Clear();
            _collectors = null;
        }

        #endregion

        #region Public Methods

        public void ChangeShift(Supervisor supervisor)
        {
            // update supvervisor
            this.Supervisor = supervisor;
            this.Begin = DateTime.Now; // setup start of shift.
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Plaza Id,
        /// </summary>
        string PlazaId { get; set; }
        /// <summary>
        /// Gets or sets Plaza Name,
        /// </summary>
        string PlazaName { get; set; }
        /// <summary>
        /// Gets or sets supervisor.
        /// </summary>
        Supervisor Supervisor { get; set; }
        /// <summary>
        /// Gets or sets shift start datetime.
        /// </summary>
        DateTime Begin { get; set; }
        /// <summary>
        /// Gets List of all avaliable collectors at current time.
        /// </summary>
        List<Collector> Collectors { get { return _collectors;  } }

        #endregion
    }

    #endregion

    public class Coupon
    {
        public Coupon()
        {
            this.Date = DateTime.MinValue;
        }
        public string StaffId { get; set; }
        public int Lane { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string DateString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToString("dd/MM/yyyy");
                return ret;
            }
            set { }
        }
        public string TimeString
        {
            get
            {
                var ret = (this.Date == DateTime.MinValue) ? "" : this.Date.ToString("HH:mm:ss.fff");
                return ret;
            }
            set { }
        }
    }
}
