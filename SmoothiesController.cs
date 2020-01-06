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
    public class SmoothiesController : Controller
    {
        private odevContext db = new odevContext();

        // GET: Smoothies
        public ActionResult Index()
        {
            return View(db.icecekler.ToList());
        }

        // GET: Smoothies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoothie smoothie = db.icecekler.Find(id);
            if (smoothie == null)
            {
                return HttpNotFound();
            }
            return View(smoothie);
        }

        // GET: Smoothies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Smoothies/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SmoothieAdi,Malzemeler,Hazirlanisi,Resim")] Smoothie smoothie)
        {
            if (ModelState.IsValid)
            {
                db.icecekler.Add(smoothie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smoothie);
        }

        // GET: Smoothies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoothie smoothie = db.icecekler.Find(id);
            if (smoothie == null)
            {
                return HttpNotFound();
            }
            return View(smoothie);
        }

        // POST: Smoothies/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SmoothieAdi,Malzemeler,Hazirlanisi,Resim")] Smoothie smoothie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smoothie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smoothie);
        }

        // GET: Smoothies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smoothie smoothie = db.icecekler.Find(id);
            if (smoothie == null)
            {
                return HttpNotFound();
            }
            return View(smoothie);
        }

        // POST: Smoothies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smoothie smoothie = db.icecekler.Find(id);
            db.icecekler.Remove(smoothie);
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
