using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class OwnerDetail
    {
        public string Name { get; set; }
        public string NRIC { get; set; }
        public string Contact { get; set; }
        public string BizRegNo { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public string Industry { get; set; }
        public Nullable<System.DateTime> LicenseDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<short> RenewalRemindDays { get; set; }
    }
}
