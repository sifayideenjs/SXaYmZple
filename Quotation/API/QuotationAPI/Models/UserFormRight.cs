﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotationAPI.Models
{
    public class UserFormRight
    {
        public int UserID { get; set; }
        public int FormID { get; set; }
        public string Options { get; set; }
    }
}