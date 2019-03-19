using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;

namespace WebProject.Core.Service
{
  public  interface ICoreService<T> where T:CoreEntity
    {
       void Add(T item);

        void Update(T item);

        bool Remove(T item);

        bool Remove(Guid id);

        List<T> GetAll(); // Bu metot  T tipine gelen tablodaki tüm verileri getirir.

        List<T> GetActive(); // Bu metot T tipine gelen tablodaki durum property'si active olanları getirir.

        List<T> GetDefault(Expression<Func<T,bool>> exp); //parametre olarak lambda sorgusu alır.

        T GetByID(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);

        int Save(); 
       

        

    }
}
