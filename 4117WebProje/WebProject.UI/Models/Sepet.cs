using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Models
{
    public class Sepet
    {
        public Guid ID { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyati { get; set; }
        public int Adet { get; set; }
        public string ImagePath { get; set; }
    }
}