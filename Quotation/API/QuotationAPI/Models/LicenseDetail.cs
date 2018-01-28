using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class LicenseDetail
    {
        public int SlNo { get; set; }
        public string LicenseDetails { get; set; }
        public System.DateTime ImportedDate { get; set; }
        public string UserID { get; set; }
    }
}