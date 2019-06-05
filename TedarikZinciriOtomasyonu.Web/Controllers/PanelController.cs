using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TedarikZinciriOtomasyonu.IslemKatmani;
using TedarikZinciriOtomasyonu.IslemKatmani.TemelOgeler;
using TedarikZinciriOtomasyonu.VarlikKatmani;
using TedarikZinciriOtomasyonu.VarlikKatmani.EkModel;
using TedarikZinciriOtomasyonu.Web.Models;
using FakeData;
using static TedarikZinciriOtomasyonu.Web.App_Start.Tanimlamalar;

namespace TedarikZinciriOtomasyonu.Web.Controllers
{
    public class PanelController : Controller
    {
        public ActionResult Anasayfa()
        {
            return View(kisiIslemleri.VeriListesi());
        }

        public ActionResult KullaniciGiris()
        {
            if (AnlikOturum.User != null)
                return RedirectToAction("Profil");

            return View();
        }

        [HttpPost]
        public ActionResult KullaniciGiris(KullaniciGiris kullaniciGiris)
        {
            if(ModelState.IsValid)
            {
                IslemKatmaniOgesi<kisi> iko = kisiIslemleri.KullaniciGirisIslemleri(kullaniciGiris);

                if(iko.Hatalar.Count < 1)
                {
                    Session["AnlikKullanici"] = iko.Varlik;
                    return RedirectToAction("Anasayfa");
                }
                else
                    iko.Hatalar.ForEach(x => ModelState.AddModelError("", x));
            }
            return View(kullaniciGiris);
        }

        public ActionResult Profil()
        {
            if (AnlikOturum.User != null)
                return View(AnlikOturum.User);
            else
                return RedirectToAction("KullaniciGiris");
        }

        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Anasayfa");
        }

        public ActionResult Hata()
        {
            return View();
        }

		public JsonResult IleGoreIlceSec(int id)
		{
			List<ilce> result = App_Start.Tanimlamalar.ilceIslemleri.VeriListesi(x => x.IlKodu == id);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult IlIlceGoreAdresSec(int il, int ilce)
		{
			List<adres> result = App_Start.Tanimlamalar.adresIslemleri.VeriListesi(x => x.IlKodu == il && x.IlceKodu == ilce);
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public ActionResult FakeDatalar()
		{
			Random random = new Random();

			List<adres> adresler = new List<adres>();
			for (int i = 0; i < 300; i++)
			{
				int ilKodu = random.Next(1, 81);
				List<ilce> ilce = ilceIslemleri.VeriListesi(x => x.IlKodu == ilKodu);
				int secilenIlce = random.Next(ilce.Count);
				adres adres = new adres()
				{
					IlKodu = ilKodu,
					IlceKodu = ilce[secilenIlce].IlceKodu,
					AdresAciklama = FakeData.PlaceData.GetAddress()
				};
				adresler.Add(adres);
			}
			adresIslemleri.TopluEkle(adresler);

			List<firma> firmalar = new List<firma>();
			for (int i = 0; i < 60; i++)
			{
				int randomAdres = random.Next(adresler.Count);
				firma firma = new firma()
				{
					FirmaAciklama = FakeData.TextData.GetSentence(),
					FirmaAdi = FakeData.NameData.GetCompanyName(),
					AdresID = adresler[randomAdres].AdresID,
					EPosta = FakeData.NetworkData.GetEmail(),
					Etkin = true,
					Fax = FakeData.PhoneNumberData.GetPhoneNumber(),
					Telefon = FakeData.PhoneNumberData.GetPhoneNumber(),
					FirmaTipi = "Müşteri"
				};
				firmalar.Add(firma);
			}
			firmaIslemleri.TopluEkle(firmalar);

			List<kisi> kisiler = new List<kisi>();
			for (int i = 0; i < 100; i++)
			{
				int sayi = random.Next(0, 24);
				kisi kisi = new kisi()
				{
					EPosta = FakeData.NetworkData.GetEmail(),
					Etkin = true,
					Guid = Guid.NewGuid().ToString(),
					Ad = FakeData.NameData.GetFirstName(),
					Soyad = FakeData.NameData.GetSurname(),
					TCKNO = FakeData.TextData.GetNumeric(11),
					Telefon = FakeData.PhoneNumberData.GetPhoneNumber(),
					YetkiID = 4
				};
				kisiler.Add(kisi);
			}
			kisiIslemleri.TopluEkle(kisiler);

			List<kisisifre> kisisifres = new List<kisisifre>();
			foreach (var item in kisiler)
			{
				kisisifre kisisifre = new kisisifre()
				{
					KisiID = item.KisiID,
					Sifre = FakeData.TextData.GetAlphaNumeric(12)
				};
			}
			kisisifreIslemleri.TopluEkle(kisisifres);

			List<urunkategori> urunkategoris = new List<urunkategori>();
			for (int i = 0; i < 25; i++)
			{
				urunkategori urunkategori = new urunkategori()
				{
					UrunKategoriAdi = FakeData.TextData.GetAlphabetical(10),
					UrunKategoriAciklama = FakeData.TextData.GetAlphabetical(50)
				};
				urunkategoris.Add(urunkategori);
			}
			urunkategoriIslemleri.TopluEkle(urunkategoris);

			List<tesiskategori> tesiskategoris = new List<tesiskategori>();
			for (int i = 0; i < 25; i++)
			{
				tesiskategori tesiskategori = new tesiskategori()
				{
					TesisKategoriAdi = FakeData.TextData.GetAlphabetical(10),
					TesisKategoriAciklama = FakeData.TextData.GetAlphabetical(50)
				};
				tesiskategoris.Add(tesiskategori);
			}
			tesiskategoriIslemleri.TopluEkle(tesiskategoris);

			List<uretimtesisi> uretimtesisis = new List<uretimtesisi>();
			for (int i = 0; i < 15; i++)
			{
				int randomAdres = random.Next(adresler.Count);
				int randomKategori = random.Next(tesiskategoris.Count);
				int randomFirma = random.Next(firmalar.Count);
				uretimtesisi uretimtesisi = new uretimtesisi()
				{
					AdresID = adresler[randomAdres].AdresID,
					TesisKategoriID = tesiskategoris[randomKategori].TesisKategoriID,
					TesisAciklama = FakeData.TextData.GetAlphabetical(50),
					UretimKapasitesi = (float)FakeData.NumberData.GetDouble(),
					TesisAdi = FakeData.NameData.GetCompanyName(),
					FirmaID = firmalar[randomFirma].FirmaID
				};
				uretimtesisis.Add(uretimtesisi);
			}
			tesisIslemleri.TopluEkle(uretimtesisis);

			List<urun> urunler = new List<urun>();
			for (int i = 0; i < 100; i++)
			{
				int randomTesis = random.Next(uretimtesisis.Count);
				int randomKategori = random.Next(urunkategoris.Count);
				urun urun = new urun()
				{
					UretimTesisiID = uretimtesisis[randomTesis].UretimTesisiID,
					UrunAdi = FakeData.TextData.GetAlphabetical(10),
					UrunAciklama = FakeData.TextData.GetSentence(),
					UrunBirimi = "Adet",
					UrunFiyati = (float)FakeData.NumberData.GetDouble(),
					Stok = FakeData.NumberData.GetNumber(100, 10000),
					UrunKategoriID = urunkategoris[randomKategori].UrunKategoriID
				};
				urunler.Add(urun);
			}
			urunIslemleri.TopluEkle(urunler);

			List<talep> talepler = new List<talep>();
			for (int i = 0; i < 120; i++)
			{
				int randomFirma = random.Next(firmalar.Count);
				int randomUrun = random.Next(urunler.Count);
				talep talep = new talep()
				{
					TalepMiktari = FakeData.NumberData.GetNumber(300),
					TalepTarihi = FakeData.DateTimeData.GetDatetime(DateTime.Today, DateTime.Today.AddMonths(5)),
					FirmaID = firmalar[randomFirma].FirmaID,
					UrunID = urunler[randomUrun].UrunID,
				};
				talepler.Add(talep);
			}
			talepIslemleri.TopluEkle(talepler);

			return RedirectToAction("Anasayfa");
		}
	}
}