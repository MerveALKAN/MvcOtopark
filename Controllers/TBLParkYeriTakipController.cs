using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcOtopark.Controllers
{
    public class TBLParkYeriTakipController : Controller
    {
        // GET: TBLParkYeriTakip
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLParkYeriTakip.ToList();
            var degerler = db.TBLParkYeriTakip.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniGiris()
        {
            List<SelectListItem> degerler = (from m in db.TBLParkYeriTakip.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = m.ParkYeriDurum,
                                                 Value = m.ParkYeriDurum.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
      
        
        [HttpPost]
        public ActionResult YeniGiris(TBLParkYeriTakip p1)
        {
   
            db.TBLParkYeriTakip.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLParkYeriTakip.Find(id);
            db.TBLParkYeriTakip.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ParkYeriGetir(int id)
        {
            var dgr = db.TBLParkYeriTakip.Find(id);
            return View("ParkYeriGetir", dgr);
        }
        public ActionResult Guncelle(TBLParkYeriTakip p1)
        {
            var dgrlr = db.TBLParkYeriTakip.Find(p1.ID);
            List<SelectListItem> degerler = (from i in db.TBLParkYeriTakip.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ParkYerleri,
                                                 Value = i.ID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            dgrlr.ParkYerleri = p1.ParkYerleri;
            dgrlr.ParkYeriDurum = p1.ParkYeriDurum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult List()
        {
            var listeler = new List<TBLParkYeriTakip>();
            using (DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7())
            {
                listeler = db.TBLParkYeriTakip.ToList();
            }
            return View(listeler);
        }
    }
}