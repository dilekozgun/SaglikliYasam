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
    public class TibbiKimliksController : Controller
    {
        private odevContext db = new odevContext();

        // GET: TibbiKimliks
        public ActionResult Index()
        {
            return View(db.kimlikler.ToList());
        }

        // GET: TibbiKimliks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TibbiKimlik tibbiKimlik = db.kimlikler.Find(id);
            if (tibbiKimlik == null)
            {
                return HttpNotFound();
            }
            return View(tibbiKimlik);
        }

        // GET: TibbiKimliks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TibbiKimliks/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Uadi,Usoyadi,Udogumtarih,Ukangrup,Ukilo,Uboy,Uhastalik")] TibbiKimlik tibbiKimlik)
        {
            if (ModelState.IsValid)
            {
                db.kimlikler.Add(tibbiKimlik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tibbiKimlik);
        }

        // GET: TibbiKimliks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TibbiKimlik tibbiKimlik = db.kimlikler.Find(id);
            if (tibbiKimlik == null)
            {
                return HttpNotFound();
            }
            return View(tibbiKimlik);
        }

        // POST: TibbiKimliks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uadi,Usoyadi,Udogumtarih,Ukangrup,Ukilo,Uboy,Uhastalik")] TibbiKimlik tibbiKimlik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tibbiKimlik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tibbiKimlik);
        }

        // GET: TibbiKimliks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TibbiKimlik tibbiKimlik = db.kimlikler.Find(id);
            if (tibbiKimlik == null)
            {
                return HttpNotFound();
            }
            return View(tibbiKimlik);
        }

        // POST: TibbiKimliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TibbiKimlik tibbiKimlik = db.kimlikler.Find(id);
            db.kimlikler.Remove(tibbiKimlik);
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
