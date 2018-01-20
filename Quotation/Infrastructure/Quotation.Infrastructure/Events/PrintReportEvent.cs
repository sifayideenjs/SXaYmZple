using Prism.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Events
{
    public class PrintReportEvent : PubSubEvent<PrintReportEventArgs>
    {
    }

    public class PrintReportEventArgs
    {
        public DataSet PrintDataSet { get; set; }
    }
}
