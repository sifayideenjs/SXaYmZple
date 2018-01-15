using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class VehicleDetail
    {
        public string NRIC { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Capacity { get; set; }
        public Nullable<System.DateTime> DateOfRegistered { get; set; }
        public string YearMade { get; set; }
        public string RegNo { get; set; }
        public Nullable<byte> ParallelImport { get; set; }
        public Nullable<byte> OffPeakVehicle { get; set; }
        public string NCD { get; set; }
        public string ExistingInsurer { get; set; }
        public string PreviousRegNo { get; set; }
        public string Claims { get; set; }
    }
}