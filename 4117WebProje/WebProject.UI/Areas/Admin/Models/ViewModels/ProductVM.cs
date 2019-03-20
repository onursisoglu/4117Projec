using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Model.Entities;

namespace WebProject.UI.Areas.Admin.Models.ViewModels
{
    public class ProductVM
    {
        public List<SubCategory> AltKategoriler { get; set; }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }
        public Guid SubCategoryID { get; set; }

    }
}