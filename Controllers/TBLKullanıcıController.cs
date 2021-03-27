using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;

namespace MvcOtopark.Controllers
{
    public class TBLKullanıcıController : Controller
    {
        // GET: TBLKullanıcı
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7(); 
        [Authorize]
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLKullanıcılar select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.KullanıcıAdi.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLKullanıcılar.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKullanıcı()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKullanıcı(TBLKullanıcılar p1)
        {
            db.TBLKullanıcılar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TBLKullanıcılar.Find(id);
            db.TBLKullanıcılar.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KullanıcıGetir(int id)
        {
            var dgr = db.TBLKullanıcılar.Find(id);
            return View("KullanıcıGetir", dgr);
        }
        public ActionResult Guncelle(TBLKullanıcılar p1)
        {
            var dgrlr = db.TBLKullanıcılar.Find(p1.KullanıcıID);
            dgrlr.KullanıcıAdi = p1.KullanıcıAdi;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

            }
        }

 
