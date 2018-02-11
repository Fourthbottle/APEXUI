using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APEXUI.Models
{
    public class LoginBO
    {
        public int id { get; set; }
        public string email { get; set; }
        public bool isEmailVerified { get; set; }
        public string password { get; set; }
        public string VerificationCode { get; set; }
        public int Empid { get; set; }

    }
}