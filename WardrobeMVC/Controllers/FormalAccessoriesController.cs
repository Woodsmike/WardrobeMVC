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
    public class FormalAccessoriesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: FormalAccessories
        public ActionResult Index()
        {
            return View(db.FormalAccessories.ToList());
        }

        // GET: FormalAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalAccessory formalAccessory = db.FormalAccessories.Find(id);
            if (formalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(formalAccessory);
        }

        // GET: FormalAccessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormalAccessoryID,FormalAccessoryName,FormalAccessoryPhoto,FormalAccessoryColor,FormalAccessorySeason,FormalAccessoryOccasion,FormalAccessoryType")] FormalAccessory formalAccessory)
        {
            if (ModelState.IsValid)
            {
                formalAccessory.FormalAccessoryPhoto = "~/Content/Images/watchAccessory.jpg";//I had to add this for each controller because I could not get the user to enter it without the program crashing
                formalAccessory.FormalAccessoryType = "Formal";
                db.FormalAccessories.Add(formalAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalAccessory);
        }

        // GET: FormalAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalAccessory formalAccessory = db.FormalAccessories.Find(id);
            if (formalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(formalAccessory);
        }

        // POST: FormalAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormalAccessoryID,FormalAccessoryName,FormalAccessoryPhoto,FormalAccessoryColor,FormalAccessorySeason,FormalAccessoryOccasion,FormalAccessoryType")] FormalAccessory formalAccessory)
        {
            if (ModelState.IsValid)
            {
                formalAccessory.FormalAccessoryPhoto = "~/Content/Images/watchAccessory.jpg";
                formalAccessory.FormalAccessoryType = "Formal";
                db.Entry(formalAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalAccessory);
        }

        // GET: FormalAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalAccessory formalAccessory = db.FormalAccessories.Find(id);
            if (formalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(formalAccessory);
        }

        // POST: FormalAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalAccessory formalAccessory = db.FormalAccessories.Find(id);
            db.FormalAccessories.Remove(formalAccessory);
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
