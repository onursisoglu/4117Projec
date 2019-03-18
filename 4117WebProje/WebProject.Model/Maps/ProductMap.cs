using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Map;
using WebProject.Model.Entities;

namespace WebProject.Model.Maps
{
   public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.Price).IsOptional();
            Property(x => x.UnitsInStock).IsOptional();
            Property(x => x.ImagePath).IsOptional();
        }
    }
}
