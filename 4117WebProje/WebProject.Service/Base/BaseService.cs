using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core.Entity;
using WebProject.Core.Service;
using WebProject.Model.Context;

namespace WebProject.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        ProjectContext db;
        public BaseService()
        {
            db = new ProjectContext();
        }

        //db.Set<T> ilgili tabloyu işaret eder.
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Durumu == Core.Entity.Enum.Status.Active).ToList();
        }

        public List<T> GetAll()
        {
          return  db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            var bulunanNesne = db.Set<T>().FirstOrDefault(exp);
            return bulunanNesne;
        }

        public T GetByID(Guid id)
        {
            var bulunanNesne = db.Set<T>().Find(id);
            return bulunanNesne;
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
           return db.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            if (item != null)
            {
                item.Durumu = Core.Entity.Enum.Status.Passive;
                Save();
                return true;
            }

            return false;
        }

        public bool Remove(Guid id)
        {
            try
            {
                var bulunanNesne = GetByID(id);
                bulunanNesne.Durumu = Core.Entity.Enum.Status.Passive;
                Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public int Save()
        {
            return db.SaveChanges();
        }

     
        public void Update(T item)
        {
            DbEntityEntry orjinalNesne = db.Entry(item);   //Veritabanında  verileri izlmeye ve kontrol etmeye yardımcı bir classtır. metoduna parametre olarak verilen nesneyi ele alır.
            orjinalNesne.CurrentValues.SetValues(item);// CurrentValues : şimdiki değerleri  SetValues : şimdiki değerlerin yerine parametredeki yeni değerleri ata.
            Save();

        }
    }
}
