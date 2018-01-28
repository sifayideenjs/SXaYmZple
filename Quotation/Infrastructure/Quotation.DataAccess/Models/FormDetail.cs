using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.DataAccess.Models
{
    public class FormDetail
    {
        public FormDetail()
        {
        }
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string CustomeText { get; set; }
    }
}
