using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;

namespace WebProject.Model.Entities
{
   public class OrderDetail:CoreEntity
    {
        public decimal? UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Guid ProductID { get; set; }

        public virtual Product Urun { get; set; }
        public virtual  Order Siparis { get; set; }
     
    }
}
