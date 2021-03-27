using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;

namespace MvcOtopark.Controllers
{
    public class TBLAracMarkaController : Controller
    {
        // GET: TBLArac
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        public ActionResult Index()
        {
            var degerler = db.TBLAracMarka.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMarka()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMarka(TBLAracMarka p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMarka");
            }
            db.TBLAracMarka.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLAracMarka.Find(id);
            db.TBLAracMarka.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaGetir(int id)
        {
            var dgr = db.TBLAracMarka.Find(id);
            return View("MarkaGetir", dgr);
        }
        public ActionResult Guncelle(TBLAracMarka p1)
        {
            var dgrlr = db.TBLAracMarka.Find(p1.ID);
            dgrlr.Marka = p1.Marka;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}