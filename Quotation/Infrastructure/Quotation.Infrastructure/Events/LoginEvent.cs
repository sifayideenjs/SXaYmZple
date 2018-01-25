using Prism.Events;
using Quotation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Events
{
    public class LoginEvent : PubSubEvent<LoginEventArgs>
    {
    }

    public class LoginEventArgs
    {
        public string ActionType { get; set; }
        public User User { get; set; }
    }
}
