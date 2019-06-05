using System;
using System.Web.Mvc;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using TedarikZinciriOtomasyonu.Web.Models;
using TedarikZinciriOtomasyonu.Web.Models.ModelView;
using static TedarikZinciriOtomasyonu.Web.App_Start.Tanimlamalar;

namespace TedarikZinciriOtomasyonu.Web.Controllers
{
    public class DegerlerController : Controller
    {
        #region UretimTesisiIslemleri

        public ActionResult Tesisler()
        {
            return View(tesisIslemleri.VeriListesi());
        }

        public ActionResult TesisEkle()
        {
            ViewData["TesisKategorisi"] = SelectListOlusturma.TesisKategoriListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Firma"] = SelectListOlusturma.FirmaListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("TesisIslemleri");
        }

        [HttpPost]
        public ActionResult TesisEkle(TesisAdresMV tesis)
        {
            if (ModelState.IsValid)
            {
                tesis.UretimTesisi.AdresID = tesis.Adres.AdresID;
                tesisIslemleri.Ekle(tesis.UretimTesisi);
                return RedirectToAction("Tesisler");
            }
            return View("TesisIslemleri", tesis);
        }

        public ActionResult TesisDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Tesisler");

            uretimtesisi tesis = tesisIslemleri.Bul(x => x.UretimTesisiID == id);

            if (tesis == null)
                return HttpNotFound();

            adres adres = adresIslemleri.Bul(x => x.AdresID == tesis.AdresID);

            if (adres == null)
                return HttpNotFound();

            ViewData["TesisKategorisi"] = SelectListOlusturma.TesisKategoriListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Firma"] = SelectListOlusturma.FirmaListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            TesisAdresMV tesisAdresMV = new TesisAdresMV()
            {
                Adres = adres,
                UretimTesisi = tesis
            };

            return View("TesisIslemleri", tesisAdresMV);
        }

        [HttpPost]
        public ActionResult TesisDuzenle(int id, TesisAdresMV yeniTesis)
        {
            if (ModelState.IsValid)
            {
                uretimtesisi tesis = tesisIslemleri.Bul(x => x.UretimTesisiID == id);

                tesis.AdresID = yeniTesis.Adres.AdresID;
                tesis.TesisKategoriID = yeniTesis.UretimTesisi.TesisKategoriID;
                tesis.FirmaID = yeniTesis.UretimTesisi.FirmaID;
                tesis.UretimKapasitesi = yeniTesis.UretimTesisi.UretimKapasitesi;

                tesisIslemleri.Guncelle(tesis);
                return RedirectToAction("Tesisler");
            }
            ViewData["TesisKategorisi"] = SelectListOlusturma.TesisKategoriListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Firma"] = SelectListOlusturma.FirmaListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("TesisIslemleri", yeniTesis);
        }

        public ActionResult TesisKategoriSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Tesisler");

            uretimtesisi tesis = tesisIslemleri.Bul(x => x.UretimTesisiID == id);

            if (tesis == null)
                return HttpNotFound();

            return View(tesis);
        }

        [HttpPost]
        public ActionResult TesisKategoriSil(int id, uretimtesisi tesis)
        {
            tesisIslemleri.Sil(tesis);
            return RedirectToAction("Tesisler");
        }

        #endregion

        #region UrunIslemleri

        public ActionResult Urunler()
        {
            return View(urunIslemleri.VeriListesi());
        }

        public ActionResult UrunEkle()
        {
            ViewData["Tesis"] = SelectListOlusturma.TesisListele();
            ViewData["UrunKategori"] = SelectListOlusturma.UrunKategoriListele();
            return View("UrunIslemleri");
        }

        [HttpPost]
        public ActionResult UrunEkle(urun urun)
        {
            if (ModelState.IsValid)
            {
                urunIslemleri.Ekle(urun);
                return RedirectToAction("Urunler");
            }
            ViewData["Tesis"] = SelectListOlusturma.TesisListele();
            ViewData["UrunKategori"] = SelectListOlusturma.UrunKategoriListele();

            return View("UrunIslemleri", urun);
        }

        public ActionResult UrunDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Urunler");

            urun urun = urunIslemleri.Bul(x => x.UrunID == id);

            if (urun == null)
                return HttpNotFound();

            ViewData["Tesis"] = SelectListOlusturma.TesisListele();
            ViewData["UrunKategori"] = SelectListOlusturma.UrunKategoriListele();

            return View("UrunIslemleri", urun);
        }

        [HttpPost]
        public ActionResult UrunDuzenle(int id, urun yeniUrun)
        {
            if (ModelState.IsValid)
            {
                urun urun = urunIslemleri.Bul(x => x.UrunID == id);

                urun.UretimTesisiID = yeniUrun.UretimTesisiID;
                urun.UrunAciklama = yeniUrun.UrunAciklama;
                urun.UrunAdi = yeniUrun.UrunAdi;
                urun.UrunBirimi = yeniUrun.UrunBirimi;
                urun.UrunKategoriID = yeniUrun.UrunKategoriID;
                urun.UrunBirimi = yeniUrun.UrunBirimi;
                urun.Stok = yeniUrun.Stok;

                urunIslemleri.Guncelle(urun);
                return RedirectToAction("Urunler");
            }
            ViewData["Tesis"] = SelectListOlusturma.TesisListele();
            ViewData["UrunKategori"] = SelectListOlusturma.UrunKategoriListele();
            return View("UrunIslemleri", yeniUrun);
        }

        public ActionResult UrunSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Urunler");

            urun urun = urunIslemleri.Bul(x => x.UrunID == id);

            if (urun == null)
                return HttpNotFound();

            return View(urun);
        }

        [HttpPost]
        public ActionResult UrunSil(int id, urun urun)
        {
            urunIslemleri.Sil(urun);
            return RedirectToAction("Urunler");
        }

        #endregion

        #region KisiIslemleri

        public ActionResult Kisiler()
        {
            return View(kisiIslemleri.VeriListesi());
        }

        public ActionResult KisiEkle()
        {
            ViewData["Yetki"] = SelectListOlusturma.YetkiListele();

            KisiKisiSifreMV sifre = new KisiKisiSifreMV()
            {
                Kisi = new kisi(),
                KisiSifre = new kisisifre()
            };
            return View("KisiIslemleri");
        }

        [HttpPost]
        public ActionResult KisiEkle(kisi kisi, string sifre)
        {
            if (ModelState.IsValid)
            {
                kisi.Guid = Guid.NewGuid().ToString();
                kisiIslemleri.Ekle(kisi);
				kisisifre sifreGelen = new kisisifre()
				{
					KisiID = kisi.KisiID,
					Sifre = sifre,
					kisi = kisi
				};
                kisisifreIslemleri.Ekle(sifreGelen);
                return RedirectToAction("Kisiler");
            }
            ViewData["Yetki"] = SelectListOlusturma.YetkiListele();

            return View("KisiIslemleri", kisi);
        }

        public ActionResult KisiDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Kisiler");

            kisi kisi = kisiIslemleri.Bul(x => x.KisiID == id);

            if (kisi == null)
                return HttpNotFound();

            ViewData["Yetki"] = SelectListOlusturma.YetkiListele();

            kisisifre kisisifre = kisisifreIslemleri.Bul(x => x.KisiID == id);

            KisiKisiSifreMV kisiKisiSifreMV = new KisiKisiSifreMV()
            {
                Kisi = kisi,
                KisiSifre = kisisifre
            };

            return View("KisiIslemleri", kisi);
        }

        [HttpPost]
        public ActionResult KisiDuzenle(int id, KisiKisiSifreMV yeniKisi)
        {
            if (ModelState.IsValid)
            {
                kisi kisi = kisiIslemleri.Bul(x => x.KisiID == id);
                kisisifre kisisifre = kisisifreIslemleri.Bul(x => x.KisiID == id);

                kisi.EPosta = yeniKisi.Kisi.EPosta;
                kisi.Etkin = yeniKisi.Kisi.Etkin;
                kisi.Ad = yeniKisi.Kisi.Ad;
                kisi.Soyad = yeniKisi.Kisi.Soyad;
                kisi.TCKNO = yeniKisi.Kisi.TCKNO;
                kisi.Telefon = yeniKisi.Kisi.Telefon;
                kisi.YetkiID = yeniKisi.Kisi.YetkiID;
                kisisifre.Sifre = yeniKisi.KisiSifre.Sifre;

                kisiIslemleri.Guncelle(kisi);
                kisisifreIslemleri.Guncelle(kisisifre);

                return RedirectToAction("Kisiler");
            }
            ViewData["Yetki"] = SelectListOlusturma.YetkiListele();
            return View("KisiIslemleri", yeniKisi);
        }

        public ActionResult KisiSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Kisiler");

            kisi kisi = kisiIslemleri.Bul(x => x.KisiID == id);

            if (kisi == null)
                return HttpNotFound();

            return View(kisi);
        }

        [HttpPost]
        public ActionResult KisiSil(int id, kisi kisi)
        {
            kisiIslemleri.Sil(kisiIslemleri.Bul(x => x.KisiID == id));
            kisisifreIslemleri.Sil(kisisifreIslemleri.Bul(x => x.KisiID == id));
            return RedirectToAction("Kisiler");
        }

        #endregion

        #region FirmaIslemleri

        public ActionResult Firmalar()
        {
            return View(firmaIslemleri.VeriListesi());
        }

        public ActionResult FirmaEkle()
        {
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("FirmaIslemleri");
        }

        [HttpPost]
        public ActionResult FirmaEkle(firma firma)
        {
            if (ModelState.IsValid)
            {
                firmaIslemleri.Ekle(firma);
                return RedirectToAction("Firmalar");
            }
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();
            return View("FirmaIslemleri", firma);
        }

        public ActionResult FirmaDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Firmalar");

            firma firma = firmaIslemleri.Bul(x => x.FirmaID == id);

            if (firma == null)
                return HttpNotFound();

            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            FirmaAdresMV firmaAdresMV = new FirmaAdresMV()
            {
                firma = firma,
                adres = firma.adres
            };

            return View("FirmaIslemleri", firma);
        }

        [HttpPost]
        public ActionResult FirmaDuzenle(int id, FirmaAdresMV yeniFirma)
        {
            if (ModelState.IsValid)
            {
                firma firma = firmaIslemleri.Bul(x => x.FirmaID == id);

                firma.FirmaAciklama = yeniFirma.firma.FirmaAciklama;
                firma.FirmaAdi = yeniFirma.firma.FirmaAdi;
                firma.AdresID = yeniFirma.firma.AdresID;
                firma.Telefon = yeniFirma.firma.Telefon;
                firma.Fax = yeniFirma.firma.Fax;
                firma.Etkin = yeniFirma.firma.Etkin;
                firma.FirmaTipi = yeniFirma.firma.FirmaTipi;

                firmaIslemleri.Guncelle(firma);
                return RedirectToAction("Firmalar");
            }
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("FirmaIslemleri", yeniFirma);
        }

        public ActionResult FirmaSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Firmalar");

            firma firma = firmaIslemleri.Bul(x => x.FirmaID == id);

            if (firma == null)
                return HttpNotFound();

            return View(firma);
        }

        [HttpPost]
        public ActionResult FirmaSil(int id, firma firma)
        {
            firmaIslemleri.Sil(firmaIslemleri.Bul(x => x.FirmaID == id));
            return RedirectToAction("Firmalar");
        }

		#endregion
	}
}