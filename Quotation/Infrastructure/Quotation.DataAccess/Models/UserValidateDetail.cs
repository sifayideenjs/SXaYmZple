using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class UserValidateDetail
    {
        public UserValidateDetail()
        {
            Code = -1;
        }
        public int Code { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
