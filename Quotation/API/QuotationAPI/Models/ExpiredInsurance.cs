using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class ExpiredInsurance
    {
        public ExpiredInsurance()
        {
        }

        public string Name { get; set; }
        public string NRIC { get; set; }
        public System.DateTime LicenseDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string InsuranceQtnNo { get; set; }
        public System.DateTime InsuranceExpiryDate { get; set; }
        public System.DateTime RoadTaxExpiryDate { get; set; }
    }
}