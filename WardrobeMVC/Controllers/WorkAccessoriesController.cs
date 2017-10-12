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
    public class WorkAccessoriesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: WorkAccessories
        public ActionResult Index()
        {
            return View(db.WorkAccessories.ToList());
        }

        // GET: WorkAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkAccessory workAccessory = db.WorkAccessories.Find(id);
            if (workAccessory == null)
            {
                return HttpNotFound();
            }
            return View(workAccessory);
        }

        // GET: WorkAccessories/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: WorkAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkAccessoryID,WorkAccessoryName,WorkAccessoryPhoto,WorkAccessoryColor,WorkAccessorySeason,WorkAccessoryOccasion,WorkAccessoryType")] WorkAccessory workAccessory)
        {
            if (ModelState.IsValid)
            {
                workAccessory.WorkAccessoryPhoto = "~/Content/Images/beltAccessory.jpg";
                workAccessory.WorkAccessoryType = "Work";
                db.WorkAccessories.Add(workAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workAccessory);
        }

        // GET: WorkAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkAccessory workAccessory = db.WorkAccessories.Find(id);
            if (workAccessory == null)
            {
                return HttpNotFound();
            }
            return View(workAccessory);
        }

        // POST: WorkAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkAccessoryID,WorkAccessoryName,WorkAccessoryPhoto,WorkAccessoryColor,WorkAccessorySeason,WorkAccessoryOccasion,WorkAccessoryType")] WorkAccessory workAccessory)
        {
            if (ModelState.IsValid)
            {
                workAccessory.WorkAccessoryPhoto = "~/Content/Images/beltAccessory.jpg";
                workAccessory.WorkAccessoryType = "Work";
                db.Entry(workAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workAccessory);
        }

        // GET: WorkAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkAccessory workAccessory = db.WorkAccessories.Find(id);
            if (workAccessory == null)
            {
                return HttpNotFound();
            }
            return View(workAccessory);
        }

        // POST: WorkAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkAccessory workAccessory = db.WorkAccessories.Find(id);
            db.WorkAccessories.Remove(workAccessory);
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
