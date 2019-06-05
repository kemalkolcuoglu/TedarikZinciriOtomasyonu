using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TedarikZinciriOtomasyonu.VeriErisimKatmani;

namespace TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler
{
	public class TemelIslemler<T> where T : class
	{
		private Repository<T> repo = new Repository<T>();

		public virtual T Bul(Expression<Func<T, bool>> where)
		{
			return repo.Bul(where);
		}

		public virtual int Ekle(T obj)
		{
			return repo.Ekle(obj);
		}

		public virtual int TopluEkle(List<T> obj)
		{
			return repo.TopluEkle(obj);
		}

        public virtual List<T> VeriListesi(Expression<Func<T, bool>> where)
        {
            return repo.VeriListesi(where);
        }

        public virtual int Guncelle(T obj)
        {
            return repo.Guncelle(obj);
        }

        public virtual int Kaydet()
        {
            return repo.Kaydet();
        }

        public virtual int Sil(T obj)
        {
            return repo.Sil(obj);
        }

        public virtual List<T> VeriListesi()
        {
            return repo.VeriListesi();
        }

        public virtual int VeriSayisi()
        {
            return repo.VeriSayisi();
        }

        public virtual IQueryable<T> Sorgu()
        {
            return repo.Sorgu();
        }

        public bool SmsGonder(string telNo, string mesaj)
        {
            mesaj = mesaj.Replace(" ", "%20");
            return HttpGet("https://api.netgsm.com.tr/sms/send/get/?usercode=08508400021&password=8801260&gsmno=" + telNo + "&message=" + mesaj + "&msgheader=MITRATUR&dil=TR");
        }

        private bool HttpGet(string url)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            if (html == string.Empty)
                return false;

            return true;
        }

        public bool TopluSms(List<string> TelNo, string mesaj)
        {
            string numaralar = String.Join(",", TelNo.ToArray());

            return SmsGonder(numaralar, mesaj);
        }
    }
}
