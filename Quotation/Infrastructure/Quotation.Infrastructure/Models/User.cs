using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Infrastructure.Models
{
    public class User
    {
        public User(string username, string[] roles)
        {
            Username = username;
            Roles = roles;
        }
        public string Username
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
