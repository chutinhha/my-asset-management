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
        public int OfficeID { get; set; }
        public DateTime DateBuyed { get; set; }
        public string InputBy { get; set; }
        public string AcceptBy { get; set; }
        public string PriceUnit { get; set; }
        public string Status { get; set; }
        public long SerialNumber { get; set; }
        public DateTime DateExpireMaintenance { get; set; }        
        public virtual Contract Contract { get; set; }
        public virtual Provider Provider { get; set; }
    }
}