using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class User
    {
        public User(string name, string username, string role, string[] formNames)
        {
            Name = name;
            Username = username;
            Role = role;
            FormNames = formNames;
        }
        public string Username
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }

        public string[] FormNames
        {
            get;
            set;
        }
    }
}
