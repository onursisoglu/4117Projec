using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Map;
using WebProject.Model.Entities;

namespace WebProject.Model.Maps
{
   public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Description).IsOptional();
        }
    }
}
