using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class UserGroupDetail
    {
        public UserGroupDetail()
        {
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }
    }
}
