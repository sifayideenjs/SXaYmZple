using Prism.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    public class OpenQuotationEvent : PubSubEvent<QuotationEventArgs>
    {
    }

    public class NewQuotationEvent : PubSubEvent<QuotationEventArgs>
    {
    }

    public class QuotationEventArgs
    {
        public string OwnerName { get; set; }
        public string QuotationNumber { get; set; }
        public string NRICNumber { get; set; }
        public DataSet QuotationDataSet { get; set; }
        public string RegionName { get; set; }
        public string Source { get; set; }
    }
}
