using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Models
{
    public class User
    {
        public User(string name, string username, string[] roles)
        {
            Name = name;
            Username = username;
            Roles = roles;
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

        public string[] Roles
        {
            get;
            set;
        }
    }
}
