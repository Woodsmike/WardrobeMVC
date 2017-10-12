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
    public class FormalBottomsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: FormalBottoms
        public ActionResult Index()
        {
            return View(db.FormalBottoms.ToList());
        }

        // GET: FormalBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBottom formalBottom = db.FormalBottoms.Find(id);
            if (formalBottom == null)
            {
                return HttpNotFound();
            }
            return View(formalBottom);
        }

        // GET: FormalBottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormalBottomID,FormalBottomName,FormalBottomPhoto,FormalBottomColor,FormalBottomSeason,FormalBottomOccasion,FormalBottomType")] FormalBottom formalBottom)
        {
            if (ModelState.IsValid)
            {
                formalBottom.FormalBottomPhoto = "~/Content/Images/TuxedoSlacks.jpg";
                formalBottom.FormalBottomType = "Formal";
                db.FormalBottoms.Add(formalBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalBottom);
        }

        // GET: FormalBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBottom formalBottom = db.FormalBottoms.Find(id);
            if (formalBottom == null)
            {
                return HttpNotFound();
            }
            return View(formalBottom);
        }

        // POST: FormalBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormalBottomID,FormalBottomName,FormalBottomPhoto,FormalBottomColor,FormalBottomSeason,FormalBottomOccasion,FormalBottomType")] FormalBottom formalBottom)
        {
            if (ModelState.IsValid)
            {
                formalBottom.FormalBottomPhoto = "~/Content/Images/TuxedoSlacks.jpg";
                formalBottom.FormalBottomType = "Formal";
                db.Entry(formalBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalBottom);
        }

        // GET: FormalBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalBottom formalBottom = db.FormalBottoms.Find(id);
            if (formalBottom == null)
            {
                return HttpNotFound();
            }
            return View(formalBottom);
        }

        // POST: FormalBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalBottom formalBottom = db.FormalBottoms.Find(id);
            db.FormalBottoms.Remove(formalBottom);
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
