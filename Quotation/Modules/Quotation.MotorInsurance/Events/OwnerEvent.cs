using Prism.Events;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    public class AddOwnerEvent : PubSubEvent<OwnerEventArgs>
    {
    }

    public class OwnerEventArgs
    {
        public OwnerDetail OwnerDetail { get; set; }
        public string RegionName { get; set; }
        public string Source { get; set; }
    }
}
