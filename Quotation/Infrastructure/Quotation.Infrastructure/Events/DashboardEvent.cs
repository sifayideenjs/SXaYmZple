using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Events
{
    public class DashboardEvent : PubSubEvent<DashboardEventArgs>
    {
    }

    public class DashboardEventArgs
    {
        //public int Id { get; set; }
        //public string ViewModelName { get; set; }
    }
}
