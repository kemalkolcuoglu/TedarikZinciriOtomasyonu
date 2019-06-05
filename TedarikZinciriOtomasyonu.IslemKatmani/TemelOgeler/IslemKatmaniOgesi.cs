using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler
{
    public class IslemKatmaniOgesi<T> where T : class
    {
        public T Varlik { get; set; }
        public List<string> Hatalar{ get; set; }
        public List<string> Mesajlar{ get; set; }

        public IslemKatmaniOgesi()
        {
            Hatalar = new List<string>();
            Mesajlar = new List<string>();
        }
    }
}
