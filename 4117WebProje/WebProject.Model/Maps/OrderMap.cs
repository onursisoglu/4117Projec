using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Map;
using WebProject.Model.Entities;

namespace WebProject.Model.Maps
{
   public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
        }
    }
}
