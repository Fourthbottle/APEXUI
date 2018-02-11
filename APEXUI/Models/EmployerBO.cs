using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APEXUI.Models
{
    public class EmployerBO
    {
        public EmployerBO()
        {
            WorkAdd = new EmployerAddress();
        }
        public int Userid { get; set; }
        public string CompName { get; set; }
        public string DUNSNumber { get; set; }
        public DateTime SysDate { get; set; }
        public string Description { get; set; }

        public EmployerAddress WorkAdd { get; set; }
        public  int RevenueAmount  { get; set; }
        public string Currency { get; set; }

    }
    public class EmployerAddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string Zipcode { get; set; }
        public string fromdate { get; set; }
        public string Todate { get; set; }
        
    }
}