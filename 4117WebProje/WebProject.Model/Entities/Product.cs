using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;

namespace WebProject.Model.Entities
{
   public class Product:CoreEntity
    {
        public string Name { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }
        public Guid SubCategoryID { get; set; }

        public virtual SubCategory AltKategori { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
