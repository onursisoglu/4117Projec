using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Model.Entities;

namespace WebProject.UI.Areas.Admin.Models.ViewModels
{
    public class SubCategoryVM
    {
        public List<Category> KatListesi{ get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }

    }
}