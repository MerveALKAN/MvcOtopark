using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;


namespace MvcOtopark.Controllers
{
    public class TBLMusteriController : Controller
    {
        // GET: TBLMusteri
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMusteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAdi.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMusteriler.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMusteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMusteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLMusteriler.Find(id);
            db.TBLMusteriler.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var dgr = db.TBLMusteriler.Find(id);
            return View("MusteriGetir", dgr);
        }
        public ActionResult Guncelle(TBLMusteriler p1)
        {
            var dgrlr = db.TBLMusteriler.Find(p1.ID);
            dgrlr.MusteriAdi = p1.MusteriAdi;
            dgrlr.MusteriSoyadi = p1.MusteriSoyadi;
            dgrlr.MusteriTc = p1.MusteriTc;
            dgrlr.MusteriTel = p1.MusteriTel;
            dgrlr.MusteriAdresi = p1.MusteriAdresi;
            dgrlr.MusteriMail = p1.MusteriMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}