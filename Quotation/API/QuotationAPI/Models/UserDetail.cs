using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class UserDetail
    {
        public UserDetail()
        {
            //this.UserFormRights = new HashSet<UserFormRight>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        //public virtual ICollection<UserFormRight> UserFormRights { get; set; }
    }
}