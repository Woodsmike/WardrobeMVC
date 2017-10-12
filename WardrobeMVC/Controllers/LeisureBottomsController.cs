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
    public class LeisureBottomsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: LeisureBottoms
        public ActionResult Index()
        {
            return View(db.LeisureBottoms.ToList());
        }

        // GET: LeisureBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureBottom leisureBottom = db.LeisureBottoms.Find(id);
            if (leisureBottom == null)
            {
                return HttpNotFound();
            }
            return View(leisureBottom);
        }

        // GET: LeisureBottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeisureBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeisureBottomID,LeisureBottomName,LeisureBottomPhoto,LeisureBottomColor,LeisureBottomSeason,LeisureBottomOccasion,LeisureBottomType")] LeisureBottom leisureBottom)
        {
            if (ModelState.IsValid)
            {
                leisureBottom.LeisureBottomPhoto = "~/Content/Images/athleticbottom.jpg";
                leisureBottom.LeisureBottomType = "Leisure";
                db.LeisureBottoms.Add(leisureBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leisureBottom);
        }

        // GET: LeisureBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureBottom leisureBottom = db.LeisureBottoms.Find(id);
            if (leisureBottom == null)
            {
                return HttpNotFound();
            }
            return View(leisureBottom);
        }

        // POST: LeisureBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeisureBottomID,LeisureBottomName,LeisureBottomPhoto,LeisureBottomColor,LeisureBottomSeason,LeisureBottomOccasion,LeisureBottomType")] LeisureBottom leisureBottom)
        {
            if (ModelState.IsValid)
            {
                leisureBottom.LeisureBottomPhoto = "~/Content/Images/athleticbottom.jpg";
                leisureBottom.LeisureBottomType = "Leisure";
                db.Entry(leisureBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leisureBottom);
        }

        // GET: LeisureBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureBottom leisureBottom = db.LeisureBottoms.Find(id);
            if (leisureBottom == null)
            {
                return HttpNotFound();
            }
            return View(leisureBottom);
        }

        // POST: LeisureBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeisureBottom leisureBottom = db.LeisureBottoms.Find(id);
            db.LeisureBottoms.Remove(leisureBottom);
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
