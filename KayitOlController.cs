using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asim.Models;

namespace Asim.Controllers
{
    public class KayitOlController : Controller
    {
        private odevContext db = new odevContext();

        // GET: KayitOl
        public ActionResult Index()
        {
            return View(db.kayıtlar.ToList());
        }

        // GET: KayitOl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KayitOl kayitOl = db.kayıtlar.Find(id);
            if (kayitOl == null)
            {
                return HttpNotFound();
            }
            return View(kayitOl);
        }

        // GET: KayitOl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KayitOl/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adı,Soyadı,EPosta,Şifre,DoğumTarihi,Kullanıcıadı,Cinsiyet,Telefon")] KayitOl kayitOl)
        {
            if (ModelState.IsValid)
            {
                db.kayıtlar.Add(kayitOl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kayitOl);
        }

        // GET: KayitOl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KayitOl kayitOl = db.kayıtlar.Find(id);
            if (kayitOl == null)
            {
                return HttpNotFound();
            }
            return View(kayitOl);
        }

        // POST: KayitOl/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adı,Soyadı,EPosta,Şifre,DoğumTarihi,Kullanıcıadı,Cinsiyet,Telefon")] KayitOl kayitOl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kayitOl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kayitOl);
        }

        // GET: KayitOl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KayitOl kayitOl = db.kayıtlar.Find(id);
            if (kayitOl == null)
            {
                return HttpNotFound();
            }
            return View(kayitOl);
        }

        // POST: KayitOl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KayitOl kayitOl = db.kayıtlar.Find(id);
            db.kayıtlar.Remove(kayitOl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
