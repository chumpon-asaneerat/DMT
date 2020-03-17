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

    public class Shift
    {
        public Shift() { }
        ~Shift() { }
        /// <summary>
        /// Gets or sets shift number.
        /// </summary>
        public int No { get; set; }
    }

    public class Staff
    {
        public Staff() : base() { }
        ~Staff() { }
        public string CardID { get; set; }
        public string Name { get; set; }
    }

    public class Supervisor : Staff
    {
        public Supervisor() : base() { }
        ~Supervisor() { }


        public static List<Supervisor> GetSupervisors()
        {
            List<Supervisor> results = new List<Supervisor>();

            results.Add(new Supervisor() { 
                CardID = "1400000101", 
                Name = "" 
            });
            results.Add(new Supervisor() { 
                CardID = "1400000102", 
                Name = "นาง" 
            });
            results.Add(new Supervisor() { 
                CardID = "1400000104", 
                Name = "นาย ภักดี อมรรุ่งโรจน์" 
            });

            return results;
        }
    }

    public class Collector : Staff
    {
        public Collector() : base() { }
        ~Collector() { }

        public static List<Collector> GetCollectors()
        {
            List<Collector> results = new List<Collector>();

            results.Add(new Collector() { 
                CardID = "1400000001", 
                Name = "นายเอนก หอมจรูง" 
            });
            results.Add(new Collector() 
            { 
                CardID = "1400000002", 
                Name = "นางวิภา สวัสดิวัฒน์" 
            });
            results.Add(new Collector() { 
                CardID = "1400000003", 
                Name = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์" 
            });
            results.Add(new Collector() { 
                CardID = "1400000004", 
                Name = "นาย ภักดี อมรรุ่งโรจน์" 
            });

            return results;
        }
    }
}
