using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;

namespace WebProject.Model.Entities
{
   public class Order:CoreEntity
    {
        public bool Confirmed { get; set; }
        public Guid AppUserID { get; set; }

        public virtual AppUser Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
