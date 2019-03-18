using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Model.Entities;
using WebProject.Model.Maps;

namespace WebProject.Model.Context
{
    /* Bu class veri tabanı ile iletişim kurduğumuz yerdir. Code firstte hangi class(lar)ın veritabanında tablo olacağını belirttiğimiz yerdir.
  Bu iletişimi sağlamak için EntityFramework kütüphanesi ile ilgili katmanda c#'ın sunduğu DbContext classını miras alarak yapmalıyız.*/

   public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
           /* Database.Connection.ConnectionString = "Server=.;Database=4117DB;uid=sa;pwd=123"; */// sql server authentication ile bağlanıyorsak
            Database.Connection.ConnectionString = "Server=.;Database=4117DB;Trusted_Connection=true"; // windowsserver authentication ile bağlanıyorsak 
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        //Yaptığımız map işlemlerinin Sql'e gönderilmesi dbcontext classının OnModelCreating metodunu ezerek gerçekleşebilir.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1. yol (tek tek ekleyebilir Map sınıflarımız)
            //modelBuilder.Configurations.Add(new AppUserMap());
            //modelBuilder.Configurations.Add(new CategoryMap());
            //modelBuilder.Configurations.Add(new SubCategoryMap());
            //modelBuilder.Configurations.Add(new ProductMap());
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new OrderDetailMap());

            //2.yol (projede IMappingMarker neredeyse bulunduğu dosya mantığını  bir kütüphane olarak algılayıp direk yükleme olayı.) 
            modelBuilder.Configurations.AddFromAssembly(typeof(IMappingMarker).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
