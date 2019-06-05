using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TedarikZinciriOtomasyonu.IslemKatmani;
using TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using static TedarikZinciriOtomasyonu.Web.App_Start.Tanimlamalar;

namespace TedarikZinciriOtomasyonu.Web.Models
{
    public static class SelectListOlusturma
    {
        public static SelectList TesisKategoriListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Tesis Kategorisi Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
            foreach (var items in tesiskategoriIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.TesisKategoriAdi,
                    Value = items.TesisKategoriID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList UrunKategoriListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Ürün Kategorisi Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in urunkategoriIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.UrunKategoriAdi,
                    Value = items.UrunKategoriID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList YetkiListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Yetki Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in yetkiIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.YetkiAdi,
                    Value = items.YetkiID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList KisiListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Kişi Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in kisiIslemleri.VeriListesi(x => x.Etkin))
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.Ad + " " + items.Soyad,
                    Value = items.KisiID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList AdresListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Adres Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in adresIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.AdresAciklama,
                    Value = items.AdresID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList UrunListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Ürün Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in urunIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.UrunAdi,
                    Value = items.UrunID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList TesisListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Üretim Tesisi Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in tesisIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.adres.il.IlAdi + "/" + items.adres.ilce.IlceAdi + " - " + items.TesisAdi,
                    Value = items.UretimTesisiID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList IlListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen İl Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in ilIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.IlAdi,
                    Value = items.IlKodu.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList IlceListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen İlçe Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in ilceIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.IlceAdi,
                    Value = items.IlceKodu.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList FirmaListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Firma Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in firmaIslemleri.VeriListesi(x => x.Etkin))
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = items.FirmaAdi,
                    Value = items.FirmaID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }

        public static SelectList TalepListele()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
			SelectListItem ilk = new SelectListItem()
			{
				Text = "Lütfen Talep Seçiniz",
				Value = "-1"
			};
			liste.Add(ilk);
			foreach (var items in talepIslemleri.VeriListesi())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = "#" + items.TalepID.ToString() + " - " + items.urun.UrunAdi + "(" + items.TalepMiktari + ")",
                    Value = items.TalepID.ToString()
                };
                liste.Add(sli);
            }
            return new SelectList(liste, "Value", "Text");
        }
    }
}
