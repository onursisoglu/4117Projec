using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Map;
using WebProject.Model.Entities;

namespace WebProject.Model.Maps
{
   public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("Users");

            Property(x => x.Name).HasMaxLength(40).IsRequired();
            Property(x => x.LastName ).HasMaxLength(40).IsRequired();
            Property(x => x.UserName).HasMaxLength(40).IsRequired();
            Property(x => x.Password).HasMaxLength(20).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsRequired();
           
        }
    }
}
