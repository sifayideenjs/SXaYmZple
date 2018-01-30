using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(int id, string name, string username, string role, string[] formNames)
        {
            ID = id;
            Name = name;
            UserName = username;
            Role = role;
            FormNames = formNames;
        }

        public int ID { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }
        public string[] FormNames { get; private set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom Authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(UserName); } }
        #endregion
    }
}
