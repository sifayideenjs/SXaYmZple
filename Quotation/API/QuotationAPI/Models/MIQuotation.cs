using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class MIQuotation
    {
        public string NRIC { get; set; }
        public string InsuranceQtnNo { get; set; }
        public System.DateTime InsuranceExpiryDate { get; set; }
        public Nullable<System.DateTime> InsuranceRenewalDate { get; set; }
        public System.DateTime RoadTaxExpiryDate { get; set; }
        public Nullable<System.DateTime> RoadTaxRenewalDate { get; set; }
        public string PreviousDealer { get; set; }
        public string Agency { get; set; }
        public string PrevYearPremium { get; set; }
        public string FinanceBank { get; set; }
        public byte InsuranceRenewed { get; set; }
        public byte RoadTaxRenewed { get; set; }
    }
}