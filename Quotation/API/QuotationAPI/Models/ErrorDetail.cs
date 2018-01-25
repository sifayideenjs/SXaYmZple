using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class ErrorDetail
    {
        public ErrorDetail()
        {
            Code = -1;
        }
        public int Code { get; set; }
        public string Info { get; set; }
    }
}