using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TedarikZinciriOtomasyonu.VeriErisimKatmani
{
    public static class RepositorySingleton
    {
        private static TedarikZinciriOtomasyonu.VarlikKatmani.TedarikZinciriContext db;
        private static object obj = new object();

        public static TedarikZinciriOtomasyonu.VarlikKatmani.TedarikZinciriContext DbContextOlustur()
        {
            lock (obj)
            {
                if (db == null)
                    db = new TedarikZinciriOtomasyonu.VarlikKatmani.TedarikZinciriContext();

                return db;
            }
        }
    }
}
