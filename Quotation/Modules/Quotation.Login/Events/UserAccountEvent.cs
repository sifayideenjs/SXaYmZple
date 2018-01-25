using Prism.Events;
using Quotation.LoginModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.Events
{
    public enum UserAccountAction
    {
        UserAdded = 0,
        UserDeleted,
        UserEdited,
        OperationFailed
    }

    public class UserAccountEvent : PubSubEvent<UserAccountEventArg>
    {
    }

    public class UserAccountEventArg
    {
        public UserAccountAction ActionType { get; set; }
        public UserViewModel User { get; set; }
    }
}
