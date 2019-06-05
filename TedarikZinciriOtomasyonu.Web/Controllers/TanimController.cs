using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TedarikZinciriOtomasyonu.Web.App_Start.Tanimlamalar;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using TedarikZinciriOtomasyonu.Web.Models;

namespace TedarikZinciriOtomasyonu.Web.Controllers
{
    public class TanimController : Controller
    {

        #region TesisKategoriIslemleri

        public ActionResult TesisKategorileri()
        {
            return View(tesiskategoriIslemleri.VeriListesi());
        }

        public ActionResult TesisKategorisiEkle()
        {
            return View("TesisKategoriIslemleri");
        }

        [HttpPost]
        public ActionResult TesisKategorisiEkle(tesiskategori kategori)
        {
            if(ModelState.IsValid)
            {
                tesiskategoriIslemleri.Ekle(kategori);
                return RedirectToAction("TesisKategorileri");
            }
            return View("TesisKategoriIslemleri", kategori);
        }

        public ActionResult TesisKategorisiDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("TesisKategorileri");

            tesiskategori kategori = tesiskategoriIslemleri.Bul(x => x.TesisKategoriID == id);

            if (kategori == null)
                return HttpNotFound();

            return View("TesisKategoriIslemleri", kategori);
        }

        [HttpPost]
        public ActionResult TesisKategorisiDuzenle(int id, tesiskategori yeniKategori)
        {
            if(ModelState.IsValid)
            {
                tesiskategori kategori = tesiskategoriIslemleri.Bul(x => x.TesisKategoriID == id);

                kategori.TesisKategoriAciklama = yeniKategori.TesisKategoriAciklama;
                kategori.TesisKategoriAdi = yeniKategori.TesisKategoriAdi;

                tesiskategoriIslemleri.Guncelle(kategori);
                return RedirectToAction("TesisKategorileri");
            }
            return View("TesisKategoriIslemleri", yeniKategori);
        }

        public ActionResult TesisKategoriSil(int? id)
        {
            if (id == null)
                return RedirectToAction("TesisKategorileri");

            tesiskategori kategori = tesiskategoriIslemleri.Bul(x => x.TesisKategoriID == id);

            if (kategori == null)
                return HttpNotFound();

            return View(kategori);
        }

        [HttpPost]
        public ActionResult TesisKategoriSil(int id, tesiskategori kategori)
        {
            tesiskategoriIslemleri.Sil(tesiskategoriIslemleri.Bul(x => x.TesisKategoriID == id));
            return RedirectToAction("TesisKategorileri");
        }

        #endregion

        #region UrunKategoriIslemleri

        public ActionResult UrunKategorileri()
        {
            return View(urunkategoriIslemleri.VeriListesi());
        }

        public ActionResult UrunKategorisiEkle()
        {
            return View("UrunKategoriIslemleri");
        }

        [HttpPost]
        public ActionResult UrunKategorisiEkle(urunkategori kategori)
        {
            if (ModelState.IsValid)
            {
                urunkategoriIslemleri.Ekle(kategori);
                return RedirectToAction("UrunKategorileri");
            }
            return View("UrunKategoriIslemleri", kategori);
        }

        public ActionResult UrunKategorisiDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("UrunKategorileri");

            urunkategori kategori = urunkategoriIslemleri.Bul(x => x.UrunKategoriID == id);

            if (kategori == null)
                return HttpNotFound();

            return View("UrunKategoriIslemleri", kategori);
        }

        [HttpPost]
        public ActionResult UrunKategorisiDuzenle(int id, urunkategori yeniKategori)
        {
            if (ModelState.IsValid)
            {
                urunkategori kategori = urunkategoriIslemleri.Bul(x => x.UrunKategoriID == id);

                kategori.UrunKategoriAciklama = yeniKategori.UrunKategoriAciklama;
                kategori.UrunKategoriAdi = yeniKategori.UrunKategoriAdi;

                urunkategoriIslemleri.Guncelle(kategori);
                return RedirectToAction("UrunKategorileri");
            }
            return View("UrunKategoriIslemleri", yeniKategori);
        }

        public ActionResult UrunKategoriSil(int? id)
        {
            if (id == null)
                return RedirectToAction("UrunKategorileri");

            urunkategori kategori = urunkategoriIslemleri.Bul(x => x.UrunKategoriID == id);

            if (kategori == null)
                return HttpNotFound();

            return View(kategori);
        }

        [HttpPost]
        public ActionResult UrunKategoriSil(int id, urunkategori kategori)
        {
            urunkategoriIslemleri.Sil(urunkategoriIslemleri.Bul(x => x.UrunKategoriID == id));
            return RedirectToAction("UrunKategorileri");
        }

        #endregion

        #region YetkiIslemleri

        public ActionResult Yetkiler()
        {
            return View(yetkiIslemleri.VeriListesi());
        }

        public ActionResult YetkiEkle()
        {
            return View("YetkiIslemleri");
        }

        [HttpPost]
        public ActionResult YetkiEkle(yetki yetki)
        {
            if (ModelState.IsValid)
            {
                yetkiIslemleri.Ekle(yetki);
                return RedirectToAction("Yetkiler");
            }
            return View("YetkiIslemleri", yetki);
        }

        public ActionResult YetkiDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Yetkiler");

            yetki yetki = yetkiIslemleri.Bul(x => x.YetkiID == id);

            if (yetki == null)
                return HttpNotFound();

            return View("YetkiIslemleri", yetki);
        }

        [HttpPost]
        public ActionResult YetkiDuzenle(int id, yetki yeniYetki)
        {
            if (ModelState.IsValid)
            {
                yetki yetki = yetkiIslemleri.Bul(x => x.YetkiID == id);

                yetki.YetkiAciklama = yeniYetki.YetkiAciklama;
                yetki.YetkiAdi = yeniYetki.YetkiAdi;

                yetkiIslemleri.Guncelle(yetki);
                return RedirectToAction("Yetkiler");
            }
            return View("YetkiIslemleri", yeniYetki);
        }

        public ActionResult YetkiSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Yetkiler");

            yetki yetki = yetkiIslemleri.Bul(x => x.YetkiID == id);

            if (yetki == null)
                return HttpNotFound();

            return View(yetki);
        }

        [HttpPost]
        public ActionResult YetkiSil(int id, yetki yetki)
        {
            yetkiIslemleri.Sil(yetkiIslemleri.Bul(x => x.YetkiID == id));
            return RedirectToAction("Yetkiler");
        }

		#endregion

		#region AdresIslemleri

		public ActionResult Adresler()
		{
			return View(adresIslemleri.VeriListesi());
		}

		public ActionResult AdresEkle()
		{
			ViewData["Il"] = SelectListOlusturma.IlListele();
			ViewData["Ilce"] = SelectListOlusturma.IlceListele();

			return View("AdresIslemleri");
		}

		[HttpPost]
		public ActionResult AdresEkle(adres adres)
		{
			if (ModelState.IsValid)
			{
				adresIslemleri.Ekle(adres);
				return RedirectToAction(nameof(Adresler));
			}
			ViewData["Il"] = SelectListOlusturma.IlListele();
			ViewData["Ilce"] = SelectListOlusturma.IlceListele();
			return View("AdresIslemleri", adres);
		}

		public ActionResult AdresDuzenle(int? id)
		{
			if (id == null)
				return RedirectToAction(nameof(Adresler));

			adres adres = adresIslemleri.Bul(x => x.AdresID == id);

			if (adres == null)
				return HttpNotFound();

			ViewData["Il"] = SelectListOlusturma.IlListele();
			ViewData["Ilce"] = SelectListOlusturma.IlceListele();

			return View("AdresIslemleri", adres);
		}

		[HttpPost]
		public ActionResult AdresDuzenle(int id, adres yeniAdres)
		{
			if (ModelState.IsValid)
			{
				adres adres = adresIslemleri.Bul(x => x.AdresID == id);
				adres.AdresAciklama = yeniAdres.AdresAciklama;
				adresIslemleri.Guncelle(adres);
				return RedirectToAction(nameof(Adresler));
			}
			ViewData["Il"] = SelectListOlusturma.IlListele();
			ViewData["Ilce"] = SelectListOlusturma.IlceListele();

			return View("AdresIslemleri", yeniAdres);
		}

		public ActionResult AdresSil(int? id)
		{
			if (id == null)
				return RedirectToAction(nameof(Adresler));

			adres adres = adresIslemleri.Bul(x => x.AdresID == id);

			if (adres == null)
				return HttpNotFound();

			return View(adres);
		}

		[HttpPost]
		public ActionResult AdresSil(int id, adres adres)
		{
			adresIslemleri.Sil(adresIslemleri.Bul(x => x.AdresID == id));
			return RedirectToAction(nameof(Adresler));
		}

		#endregion
	}
}