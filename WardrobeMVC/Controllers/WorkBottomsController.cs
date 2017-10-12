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
    public class WorkBottomsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: WorkBottoms
        public ActionResult Index()
        {
            return View(db.WorkBottoms.ToList());
        }

        // GET: WorkBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkBottom workBottom = db.WorkBottoms.Find(id);
            if (workBottom == null)
            {
                return HttpNotFound();
            }
            return View(workBottom);
        }

        // GET: WorkBottoms/Create
        public ActionResult Create()
        {
            return View();           
        }

        // POST: WorkBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkBottomID,WorkBottomName,WorkBottomPhoto,WorkBottomColor,WorkBottomSeason,WorkBottomOccasion,WorkBottomType")] WorkBottom workBottom)
        {
            if (ModelState.IsValid)
            {
                workBottom.WorkBottomPhoto = "~/Content/Images/slacks.jpg";
                workBottom.WorkBottomType = "Work";
                db.WorkBottoms.Add(workBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
           
            return View(workBottom);
        }

        // GET: WorkBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkBottom workBottom = db.WorkBottoms.Find(id);
            if (workBottom == null)
            {
                return HttpNotFound();
            }
            return View(workBottom);
        }

        // POST: WorkBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkBottomID,WorkBottomName,WorkBottomPhoto,WorkBottomColor,WorkBottomSeason,WorkBottomOccasion,WorkBottomType")] WorkBottom workBottom)
        {
            if (ModelState.IsValid)
            {
                workBottom.WorkBottomPhoto = "~/Content/Images/slacks.jpg";
                workBottom.WorkBottomType = "Work";
                db.Entry(workBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workBottom);
        }

        // GET: WorkBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkBottom workBottom = db.WorkBottoms.Find(id);
            if (workBottom == null)
            {
                return HttpNotFound();
            }
            return View(workBottom);
        }

        // POST: WorkBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkBottom workBottom = db.WorkBottoms.Find(id);
            db.WorkBottoms.Remove(workBottom);
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
