using Prism.Events;
using Quotation.LoginModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.Events
{
    public enum GroupAccountAction
    {
        GroupAdded = 0,
        GroupDeleted,
        GroupEdited,
        OperationFailed
    }

    public class GroupAccountEvent : PubSubEvent<GroupAccountEventArg>
    {
    }

    public class GroupAccountEventArg
    {
        public GroupAccountAction ActionType { get; set; }
        public GroupViewModel Group { get; set; }
    }
}
