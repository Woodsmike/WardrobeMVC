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
    public class LeisureAccessoriesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: LeisureAccessories
        public ActionResult Index()
        {
            return View(db.LeisureAccessories.ToList());
        }

        // GET: LeisureAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureAccessory leisureAccessory = db.LeisureAccessories.Find(id);
            if (leisureAccessory == null)
            {
                return HttpNotFound();
            }
            return View(leisureAccessory);
        }

        // GET: LeisureAccessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeisureAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeisureAccessoryID,LeisureAccessoryName,LeisureAccessoryPhoto,LeisureAccessoryColor,LeisureAccessorySeason,LeisureAccessoryOccasion,LeisureAccessoryType")] LeisureAccessory leisureAccessory)
        {
            if (ModelState.IsValid)
            {
                leisureAccessory.LeisureAccessoryPhoto = "~/Content/Images/SunglassesAccessory.jpg";
                leisureAccessory.LeisureAccessoryType = "Leisure";
                db.LeisureAccessories.Add(leisureAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leisureAccessory);
        }

        // GET: LeisureAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureAccessory leisureAccessory = db.LeisureAccessories.Find(id);
            if (leisureAccessory == null)
            {
                return HttpNotFound();
            }
            return View(leisureAccessory);
        }

        // POST: LeisureAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeisureAccessoryID,LeisureAccessoryName,LeisureAccessoryPhoto,LeisureAccessoryColor,LeisureAccessorySeason,LeisureAccessoryOccasion,LeisureAccessoryType")] LeisureAccessory leisureAccessory)
        {
            if (ModelState.IsValid)
            {
                leisureAccessory.LeisureAccessoryPhoto = "~/Content/Images/SunglassesAccessory.jpg";
                leisureAccessory.LeisureAccessoryType = "Leisure";
                db.Entry(leisureAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leisureAccessory);
        }

        // GET: LeisureAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureAccessory leisureAccessory = db.LeisureAccessories.Find(id);
            if (leisureAccessory == null)
            {
                return HttpNotFound();
            }
            return View(leisureAccessory);
        }

        // POST: LeisureAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeisureAccessory leisureAccessory = db.LeisureAccessories.Find(id);
            db.LeisureAccessories.Remove(leisureAccessory);
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
