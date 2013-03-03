using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asset_Management.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string OfficeID { get; set; }
        public DateTime DateBuyed { get; set; }
        public string InputBy { get; set; }
        public string AcceptBy { get; set; }
        public string PriceUnit { get; set; }
        public string Status { get; set; }
        public DateTime DateExpireMaintance { get; set; }        
        public virtual Contract Contract { get; set; }
    }
}