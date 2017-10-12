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
    public class InformalAccessoriesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: InformalAccessories
        public ActionResult Index()
        {
            return View(db.InformalAccessories.ToList());
        }

        // GET: InformalAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalAccessory informalAccessory = db.InformalAccessories.Find(id);
            if (informalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(informalAccessory);
        }

        // GET: InformalAccessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalAccessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformalAccessoryID,InformalAccessoryName,InformalAccessoryPhoto,InformalAccessoryColor,InformalAccessorySeason,InformalAccessoryOccasion,InformalAccessoryType")] InformalAccessory informalAccessory)
        {
            if (ModelState.IsValid)
            {
                informalAccessory.InformalAccessoryPhoto = "~/Content/Images/beltAccessory.jpg";
                informalAccessory.InformalAccessoryType = "Informal";
                db.InformalAccessories.Add(informalAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalAccessory);
        }

        // GET: InformalAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalAccessory informalAccessory = db.InformalAccessories.Find(id);
            if (informalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(informalAccessory);
        }

        // POST: InformalAccessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformalAccessoryID,InformalAccessoryName,InformalAccessoryPhoto,InformalAccessoryColor,InformalAccessorySeason,InformalAccessoryOccasion,InformalAccessoryType")] InformalAccessory informalAccessory)
        {
            if (ModelState.IsValid)
            {
                informalAccessory.InformalAccessoryPhoto = "~/Content/Images/beltAccessory.jpg";
                informalAccessory.InformalAccessoryType = "Informal";
                db.Entry(informalAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalAccessory);
        }

        // GET: InformalAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalAccessory informalAccessory = db.InformalAccessories.Find(id);
            if (informalAccessory == null)
            {
                return HttpNotFound();
            }
            return View(informalAccessory);
        }

        // POST: InformalAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalAccessory informalAccessory = db.InformalAccessories.Find(id);
            db.InformalAccessories.Remove(informalAccessory);
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
