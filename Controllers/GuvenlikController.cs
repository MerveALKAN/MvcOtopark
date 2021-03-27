using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOtopark.Models.Entity;
using System.Web.Security;

namespace MvcOtopark.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        DbOtoparkTakipEntities7 db = new DbOtoparkTakipEntities7();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLKullanıcılar t)
        {
            var bilgiler = db.TBLKullanıcılar.FirstOrDefault(x => x.KullanıcıAdi == t.KullanıcıAdi && x.Sifre == t.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAdi,false);
                return RedirectToAction("Index", "TBLMusteri");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(TBLKullanıcılar k)
        {
            db.TBLKullanıcılar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index", "TBLKullanıcı");
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



    }
}