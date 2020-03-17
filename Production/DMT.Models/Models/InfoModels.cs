using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Models
{
    public class Plaza
    {
        public Plaza() { }
        ~Plaza() { }

        string PlazaName { get; set; }
    }

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
                CardID = "1400000001",
                Name = "นายเอนก หอมจรูง"
            });
            results.Add(new Collector()
            {
                CardID = "1400000002",
                Name = "นางวิภา สวัสดิวัฒน์"
            });
            results.Add(new Collector()
            {
                CardID = "1400000003",
                Name = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์"
            });
            results.Add(new Collector()
            {
                CardID = "1400000004",
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
}
