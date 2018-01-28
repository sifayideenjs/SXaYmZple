using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class UserDetail
    {
        public UserDetail()
        {
            //this.UserFormRights = new HashSet<UserFormRight>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }

    }
}
