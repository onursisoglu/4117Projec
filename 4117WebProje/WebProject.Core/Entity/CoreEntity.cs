using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity.Enum;

namespace WebProject.Core.Entity
{
   public class CoreEntity
    {
        /*
         // Proje E -ticaret sitesi
         Gerekli olan tablolarım => Category,SubCategory,Product,Order,OrderDetail,User 
         */
        //Bu class tüm tablolarda(classlarda) ortak kullanılacak özellikleri barındıran yerdir. 


        public Guid ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedUserName { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedUserName { get; set; }
        public Status Durumu { get; set; }

    }
}
