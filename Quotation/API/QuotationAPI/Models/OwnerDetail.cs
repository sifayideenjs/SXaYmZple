using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class OwnerDetail
    {
        public OwnerDetail()
        {
        }

        public string Name { get; set; }
        public string NRIC { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public System.DateTime LicenseDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public short RenewalRemindDays { get; set; }
    }
}