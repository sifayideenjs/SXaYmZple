using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class User
    {
        public User(string name, string username, string role)
        {
            Name = name;
            Username = username;
            Role = role;
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
    }
}
