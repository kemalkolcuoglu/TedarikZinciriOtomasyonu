using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using TedarikZinciriOtomasyonu.VarlikKatmani.EkModel;

namespace TedarikZinciriOtomasyonu.IslemKatmani
{
    public class KisiIslemleri : TemelIslemler<kisi>
    {
        TemelIslemler<kisisifre> kisisifreIslemleri = new TemelIslemler<kisisifre>();
        public IslemKatmaniOgesi<kisi> KullaniciGirisIslemleri(KullaniciGiris kullaniciGiris)
        {
            IslemKatmaniOgesi<kisi> iko = new IslemKatmaniOgesi<kisi>();
            

            string sifreliGiris = kullaniciGiris.Sifre;
            kisi kullanici = Bul(x => x.Telefon == kullaniciGiris.TelefonNo);
            if (kullanici == null)
                iko.Hatalar.Add("Girilen bilgilere ait kullanıcı bulunamadı.");
            else
            {
                kisisifre kisisifre = kisisifreIslemleri.Bul(x => x.KisiID == kullanici.KisiID && x.Sifre == kullaniciGiris.Sifre);

                if (kisisifre == null)
                    iko.Hatalar.Add("Girilen şifre hatalı. Lütfen tekrar deneyiniz.");
                else
                    iko.Varlik = kullanici;
            }

            return iko;
        }
    }
}
