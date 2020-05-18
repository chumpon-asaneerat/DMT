using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Services
{
    public class SmartCardManager
    {
        public static string UserId = string.Empty;
        public static string UserName = string.Empty;

        public static void SignIn()
        {
            UserId = "14755";
            UserName = "นาย สมบูรณ์ สบายดี";
        }

        public static void SignOut()
        {
            UserId = string.Empty;
            UserName = string.Empty;
        }
    }
}
