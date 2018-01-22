using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class UserAccountEvent : PubSubEvent<UserAccountEventArg>
    {
    }

    public class UserAccountEventArg
    {
        public string ActionType { get; set; }
        public string Username { get; set; }
    }
}
