using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asset_Management.Models
{
    public class Maintenance
    {
        public int MaintenanceID { get; set; }
        public string PriceMaintenance { get; set; }
        public DateTime DateMaintenance { get; set; }
        public DateTime NextDateMaintenance { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Contract Contract { get; set; }
    }
}