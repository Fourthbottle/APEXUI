using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APEXUI.Models
{
    public static class ApexConfig
    {
        public const string RegisterNewUserUri = "api/Registration/Register";
        public const string AddEmployeeDetails = "api/Employee/AddEmployeeInfo";
        public const string GetEmployeeDetails = "api/employee/GetEmployeeDetails/";
        public const string UdpateEmployeeDetails = "api/Employee/GetEmployeeDetails/";
        public const string CheckUser = "api/login/login";
        public const string AddWorkHistory = "api/WorkHistory/InsertWorkHistory";
        public const string AddSkills = "/api/Skills/";
        public const string GetWorkHistory = "/api/WorkHistory/GetWorkHistory/";
        public const string GetSkills = "/api/Skills/";
        public const string UdpateWorkHistory = "api/WorkHistory/updateWorkHistory/";
        public const string DeleteWorkHistory = "api/WorkHistory/deleteWorkHistory";
        public const string InsertEmployerDetails = "api/Employer/InsertEmployerDetails/";

    }
}