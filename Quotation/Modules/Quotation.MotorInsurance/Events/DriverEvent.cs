using Prism.Events;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.MotorInsuranceModule.Events
{
    class AddDriverEvent : PubSubEvent<DriverEventArgs>
    {
    }

    class EditDriverEvent : PubSubEvent<DriverEventArgs>
    {
    }

    class DeleteDriverEvent : PubSubEvent<DriverEventArgs>
    {
    }

    class SaveDriverEvent : PubSubEvent<DriverEventArgs>
    {
    }

    public class DriverEventArgs
    {
        public List<DriverDetail> DriverDetails { get; set; }
        public string RegionName { get; set; }
        public string Source { get; set; }
    }
}
