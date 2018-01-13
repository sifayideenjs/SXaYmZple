using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    public class NextEvent : PubSubEvent<NextEventArgs>
    {
    }

    public class NextEventArgs
    {
        public string RegionName { get; set; }
        public string Source { get; set; }
    }
}
