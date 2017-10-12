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
    public class WorkTopsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: WorkTops
        public ActionResult Index()
        {
            return View(db.WorkTops.ToList());
        }

        // GET: WorkTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTop workTop = db.WorkTops.Find(id);
            if (workTop == null)
            {
                return HttpNotFound();
            }
            return View(workTop);
        }

        // GET: WorkTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkTopID,WorkTopName,WorkTopPhoto,WorkTopColor,WorkTopSeason,WorkTopOccasion,WorkTopType")] WorkTop workTop)
        {
            if (ModelState.IsValid)
            {
                workTop.WorkTopPhoto = "~/Content/Images/MensInformalShirt.jpg";
                workTop.WorkTopType = "Work";
                db.WorkTops.Add(workTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workTop);
        }

        // GET: WorkTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTop workTop = db.WorkTops.Find(id);
            if (workTop == null)
            {
                return HttpNotFound();
            }
            return View(workTop);
        }

        // POST: WorkTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkTopID,WorkTopName,WorkTopPhoto,WorkTopColor,WorkTopSeason,WorkTopOccasion,WorkTopType")] WorkTop workTop)
        {
            if (ModelState.IsValid)
            {
                workTop.WorkTopPhoto = "~/Content/Images/SuitCoat.jpg";
                workTop.WorkTopType = "Work";
                db.Entry(workTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workTop);
        }

        // GET: WorkTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTop workTop = db.WorkTops.Find(id);
            if (workTop == null)
            {
                return HttpNotFound();
            }
            return View(workTop);
        }

        // POST: WorkTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTop workTop = db.WorkTops.Find(id);
            db.WorkTops.Remove(workTop);
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
