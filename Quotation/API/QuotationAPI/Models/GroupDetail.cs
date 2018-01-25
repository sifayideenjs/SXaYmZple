using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class GroupDetail
    {
        public GroupDetail()
        {
            //this.UserFormRights = new HashSet<UserFormRight>();
        }

        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    }
}