using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;

namespace MvcOtopark.Controllers
{
    public class TBLAracSeriController : Controller
    {
        // GET: TBLAracSeri
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        public ActionResult Index()
        {
            var degerler = db.TBLAracSeri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSeri(TBLAracSeri p1)
        {
            db.TBLAracSeri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLAracSeri.Find(id);
            db.TBLAracSeri.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}