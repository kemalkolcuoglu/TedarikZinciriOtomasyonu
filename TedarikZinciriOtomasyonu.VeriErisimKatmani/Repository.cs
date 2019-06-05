using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TedarikZinciriOtomasyonu.VeriErisimKatmani
{
    public class Repository<T> where T : class
    {
        private TedarikZinciriOtomasyonu.VarlikKatmani.TedarikZinciriContext db = RepositorySingleton.DbContextOlustur();
        private DbSet<T> dbSet;

        public Repository()
        {
            dbSet = db.Set<T>();
        }

        public int Kaydet()
        {
            return db.SaveChanges();
        }

        public int VeriSayisi()
        {
            return dbSet.Count();
        }

        public T Bul(Expression<Func<T, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public List<T> VeriListesi()
        {
            return dbSet.ToList();
        }

        public IQueryable<T> Sorgu()
        {
            return dbSet.AsQueryable<T>();
        }

        public List<T> VeriListesi(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public int Ekle(T obj)
        {
            dbSet.Add(obj);
            return db.SaveChanges();
        }

		public int TopluEkle(List<T> obj)
		{
			dbSet.AddRange(obj);
			return db.SaveChanges();
		}

		public int Guncelle(T obj)
        {
            return db.SaveChanges();
        }

        public int Sil(T obj)
        {
            dbSet.Remove(obj);
            return db.SaveChanges();
        }
    }
}
