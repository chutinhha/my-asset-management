using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asset_Management.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public string ContractNumber { get; set; }
        public string Title { get; set; }
        public DateTime DateSigned { get; set; }
        public string SignedBy { get; set; }
        public decimal PriceContract { get; set; }
        public DateTime InputDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Provider Provider { get; set; }
    }
}