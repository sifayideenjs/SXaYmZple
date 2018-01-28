using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class DriverDetail
    {
        public string NRIC { get; set; }
        public string InsuredName { get; set; }
        public string InsuredNRIC { get; set; }
        public string BizRegNo { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public string Industry { get; set; }
        public Nullable<System.DateTime> LicenseDate { get; set; }
    }
}
