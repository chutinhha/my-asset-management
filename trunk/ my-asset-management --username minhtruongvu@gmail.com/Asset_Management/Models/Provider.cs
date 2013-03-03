using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asset_Management.Models
{
    public class Provider
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Manager { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}