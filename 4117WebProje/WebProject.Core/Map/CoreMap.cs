using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Map
{
    // Fluent Api (classlari(tabloları ) veritabanına gönderirken hangi şekilde gidecek , orada tipi ne olacak , kaç karakter uzunluğuna sahip olacak gibi özelliklerini Data.Annotations Attribute'lerini kullanmadan bir metod aracılığıyla daha temiz kod yazarak halletmemizi sağlayacak kavramdır.)
    // Gene bunu kullanmak için System.ComponentModel.DataAnnotations.Schema dll (kütüphanesi) dahil edilmelidir. Ve EntityTypeConfiguration class'ını miras almak gerekir.
    //Kütüphane gelmezse Entity Framework'u Nuget'tan yüklememiz gereklidir.

   public class CoreMap<T>: EntityTypeConfiguration<T> where T:CoreEntity
    {

        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Durumu).HasColumnName("Statu").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedUserName).IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").IsOptional();


            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedUserName).IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").IsOptional();

        }



    }
}
