using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;

namespace MvcOtopark.Controllers
{

    public class TBLParkBilgileriController : Controller

    {

        // GET: TBLParkBilgileri
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLParkBilgileri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Ad.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLParkBilgileri.ToList();
            //return View(degerler);

            
        }
        [HttpGet]
        public ActionResult YeniBilgi()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult YeniBilgi(TBLParkBilgileri p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniBilgi");
            }

            db.TBLParkBilgileri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public ActionResult Sil(int? id)
        {

          

            var deger = db.TBLParkBilgileri.Find(id);
            db.TBLParkBilgileri.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        
        public ActionResult BilgiGetir(int? id)
        {
            var dgr = db.TBLParkBilgileri.Find(id);
          

            List<SelectListItem> degerler = (from i in db.TBLAracMarka.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Marka,
                                                 Value = i.ID.ToString(),
                                                


                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("BilgiGetir", dgr);


        }
        public ActionResult Guncelle(TBLParkBilgileri p1)
        {
            var dgrlr = db.TBLParkBilgileri.Find(p1.ID);
            dgrlr.Ad = p1.Ad;
            dgrlr.Soyad = p1.Soyad;
            dgrlr.Telefon = p1.Telefon;
            dgrlr.MarkaID = p1.MarkaID;
            dgrlr.SeriID = p1.SeriID;
            dgrlr.Model = p1.Model;
            dgrlr.Renk = p1.Renk;
            dgrlr.Plaka = p1.Plaka;
            dgrlr.Yil = p1.Yil;
            dgrlr.ParkYeriID = p1.ParkYeriID;
            dgrlr.GirisTarihi = p1.GirisTarihi;
            dgrlr.CikisTarihi = p1.CikisTarihi;
            //var dgrler = db.TBLAracMarka.Where(m => m.ID == p1.TBLAracMarka.ID).FirstOrDefault();
            //dgrlr.MarkaID = dgrler.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}