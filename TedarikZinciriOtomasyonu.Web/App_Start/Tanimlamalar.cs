using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TedarikZinciriOtomasyonu.IslemKatmani;
using TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler;
using TedarikZinciriOtomasyonu.VarlikKatmani;

namespace TedarikZinciriOtomasyonu.Web.App_Start
{
    public class Tanimlamalar
    {
        public static TemelIslemler<adres> adresIslemleri = new TemelIslemler<adres>();
        public static TemelIslemler<firma> firmaIslemleri = new TemelIslemler<firma>();
        public static TemelIslemler<firmapersonel> firmaPersonelIslemleri = new TemelIslemler<firmapersonel>();
        public static TemelIslemler<il> ilIslemleri = new TemelIslemler<il>();
        public static TemelIslemler<ilce> ilceIslemleri = new TemelIslemler<ilce>();
        public static TemelIslemler<talep> talepIslemleri = new TemelIslemler<talep>();
        public static TemelIslemler<tedarik> tedarikIslemleri = new TemelIslemler<tedarik>();
        public static TemelIslemler<tesiskategori> tesiskategoriIslemleri = new TemelIslemler<tesiskategori>();
        public static TemelIslemler<urunkategori> urunkategoriIslemleri = new TemelIslemler<urunkategori>();
        public static TemelIslemler<yetki> yetkiIslemleri = new TemelIslemler<yetki>();
        public static KisiIslemleri kisiIslemleri = new KisiIslemleri();
        public static TemelIslemler<kisisifre> kisisifreIslemleri = new TemelIslemler<kisisifre>();
        public static TemelIslemler<urun> urunIslemleri = new TemelIslemler<urun>();
        public static TemelIslemler<uretimtesisi> tesisIslemleri = new TemelIslemler<uretimtesisi>();
    }
}