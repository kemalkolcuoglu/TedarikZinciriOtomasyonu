using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using TedarikZinciriOtomasyonu.Web.Models;
using TedarikZinciriOtomasyonu.Web.Models.ModelView;
using static TedarikZinciriOtomasyonu.Web.App_Start.Tanimlamalar;

namespace TedarikZinciriOtomasyonu.Web.Controllers
{
    public class TedarikController : Controller
    {

        #region TalepIslemleri

        public ActionResult Talepler()
        {
            return View(talepIslemleri.VeriListesi());
        }

        public ActionResult TalepEkle()
        {
            ViewData["Urun"] = SelectListOlusturma.UrunListele();
            ViewData["Musteri"] = SelectListOlusturma.FirmaListele();
            
            return View("TalepIslemleri");
        }

        [HttpPost]
        public ActionResult TalepEkle(talep talep)
        {
            if(ModelState.IsValid)
            {
                talepIslemleri.Ekle(talep);
                return RedirectToAction("Talepler");
            }
            ViewData["Urun"] = SelectListOlusturma.UrunListele();
            ViewData["Musteri"] = SelectListOlusturma.FirmaListele();

            return View("TalepIslemleri", talep);
        }

        public ActionResult TalepDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Talepler");

            talep talep = talepIslemleri.Bul(x => x.TalepID == id);

            if (talep == null)
                return HttpNotFound();

            ViewData["Urun"] = SelectListOlusturma.UrunListele();
            ViewData["Musteri"] = SelectListOlusturma.FirmaListele();

            return View("TalepIslemleri", talep);
        }

        [HttpPost]
        public ActionResult TalepDuzenle(int id, talep yeniTalep)
        {
            if(ModelState.IsValid)
            {
                talep talep = talepIslemleri.Bul(x => x.TalepID == id);

                talep.FirmaID = yeniTalep.FirmaID;
                talep.TalepMiktari = yeniTalep.TalepMiktari;
                talep.UrunID = yeniTalep.UrunID;

                talepIslemleri.Guncelle(talep);
                return RedirectToAction("Talepler");
            }
            ViewData["Urun"] = SelectListOlusturma.UrunListele();
            ViewData["Musteri"] = SelectListOlusturma.FirmaListele();

            return View("TalepIslemleri", yeniTalep);
        }

        public ActionResult TalepSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Talepler");

            talep talep = talepIslemleri.Bul(x => x.TalepID == id);

            if (talep == null)
                return HttpNotFound();

            return View(talep);
        }

        [HttpPost]
        public ActionResult TalepSil(int id, talep talep)
        {
            talepIslemleri.Sil(talep);
            return RedirectToAction(nameof(Talepler));
        }

        #endregion

        #region TedarikIslemleri

        public ActionResult Tedarikler()
        {
            return View(tedarikIslemleri.VeriListesi());
        }

        public ActionResult TedarikEkle()
        {
            ViewData["Talep"] = SelectListOlusturma.TalepListele();
            ViewData["Tedarikci"] = SelectListOlusturma.KisiListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View();
        }

        [HttpPost]
        public ActionResult TedarikEkle(TedarikAdresMV tedarik)
        {
            if (ModelState.IsValid)
            {
                tedarikIslemleri.Ekle(tedarik.Tedarik);
                return RedirectToAction("Tedarikler");
            }
            ViewData["Talep"] = SelectListOlusturma.TalepListele();
            ViewData["Tedarikci"] = SelectListOlusturma.KisiListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("TedarikIslemleri", tedarik);
        }

        public ActionResult TedarikDuzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Tedarikler");

            tedarik tedarik = tedarikIslemleri.Bul(x => x.TedarikID == id);

            if (tedarik == null)
                return HttpNotFound();

            ViewData["Talep"] = SelectListOlusturma.TalepListele();
            ViewData["Tedarikci"] = SelectListOlusturma.KisiListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("TedarikIslemleri", tedarik);
        }

        [HttpPost]
        public ActionResult TedarikDuzenle(int id, TedarikAdresMV yeniTedarik)
        {
            if (ModelState.IsValid)
            {
                tedarik tedarik = tedarikIslemleri.Bul(x => x.TedarikID == id);

                tedarik.CikisAdresiID = yeniTedarik.Tedarik.CikisAdresiID;
                tedarik.KisiID = yeniTedarik.Tedarik.KisiID;
                tedarik.TeslimAdresiID = yeniTedarik.Tedarik.TeslimAdresiID;
                tedarik.TeslimTarihi = yeniTedarik.Tedarik.TeslimTarihi;
                tedarik.Durum = yeniTedarik.Tedarik.Durum;
                tedarik.TedarikUcreti = yeniTedarik.Tedarik.TedarikUcreti;

                tedarikIslemleri.Guncelle(tedarik);
                return RedirectToAction("Tedarikler");
            }
            ViewData["Talep"] = SelectListOlusturma.TalepListele();
            ViewData["Tedarikci"] = SelectListOlusturma.KisiListele();
            ViewData["Il"] = SelectListOlusturma.IlListele();
            ViewData["Ilce"] = SelectListOlusturma.IlceListele();
            ViewData["Adres"] = SelectListOlusturma.AdresListele();

            return View("TedarikIslemleri", yeniTedarik);
        }

        public ActionResult TedarikSil(int? id)
        {
            if (id == null)
                return RedirectToAction("Tedarikler");

            tedarik tedarik = tedarikIslemleri.Bul(x => x.TedarikID == id);

            if (tedarik == null)
                return HttpNotFound();

            return View(tedarik);
        }

        [HttpPost]
        public ActionResult TedarikSil(int id, tedarik tedarik)
        {
            tedarikIslemleri.Sil(tedarikIslemleri.Bul(x => x.TedarikID == id));
            return RedirectToAction("Tedarikler");
        }

        #endregion
    }
}