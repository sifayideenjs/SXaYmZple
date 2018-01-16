using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class DriverDetail
    {
        public string Name { get; set; }
        public string NRIC { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public Nullable<System.DateTime> LicenseDate { get; set; }
    }
}