using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class FormalTopsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: FormalTops
        public ActionResult Index()
        {
            return View(db.FormalTops.ToList());
        }

        // GET: FormalTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalTop formalTop = db.FormalTops.Find(id);
            if (formalTop == null)
            {
                return HttpNotFound();
            }
            return View(formalTop);
        }

        // GET: FormalTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormalTopID,FormalTopName,FormalTopPhoto,FormalTopColor,FormalTopSeason,FormalTopOccasion,FormalTopType")] FormalTop formalTop)
        {
            if (ModelState.IsValid)            
            {
                formalTop.FormalTopPhoto = "/Content/Images/TuxedoCoat.jpg";
                formalTop.FormalTopType = "Formal";
                db.FormalTops.Add(formalTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalTop);
        }

        // GET: FormalTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalTop formalTop = db.FormalTops.Find(id);
            if (formalTop == null)
            {
                return HttpNotFound();
            }
            return View(formalTop);
        }

        // POST: FormalTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormalTopID,FormalTopName,FormalTopPhoto,FormalTopColor,FormalTopSeason,FormalTopOccasion,FormalTopType")] FormalTop formalTop)
        {
            if (ModelState.IsValid)
            {
                formalTop.FormalTopPhoto = "~/Content/Images/TuxedoCoat.jpg";
                formalTop.FormalTopType = "Formal";
                db.Entry(formalTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalTop);
        }

        // GET: FormalTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalTop formalTop = db.FormalTops.Find(id);
            if (formalTop == null)
            {
                return HttpNotFound();
            }
            return View(formalTop);
        }

        // POST: FormalTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalTop formalTop = db.FormalTops.Find(id);
            db.FormalTops.Remove(formalTop);
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
