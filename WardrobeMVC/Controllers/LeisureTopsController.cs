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
    public class LeisureTopsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: LeisureTops
        public ActionResult Index()
        {
            return View(db.LeisureTops.ToList());
        }

        // GET: LeisureTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureTop leisureTop = db.LeisureTops.Find(id);
            if (leisureTop == null)
            {
                return HttpNotFound();
            }
            return View(leisureTop);
        }

        // GET: LeisureTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeisureTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeisureTopID,LeisureTopName,LeisureTopPhoto,LeisureTopColor,LeisureTopSeason,LeisureTopOccasion,LeisureTopType")] LeisureTop leisureTop)
        {
            if (ModelState.IsValid)
            {
                leisureTop.LeisureTopPhoto = "~/Content/Images/Athletictop.jpg";
                leisureTop.LeisureTopType = "Leisure";
                db.LeisureTops.Add(leisureTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leisureTop);
        }

        // GET: LeisureTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureTop leisureTop = db.LeisureTops.Find(id);
            if (leisureTop == null)
            {
                return HttpNotFound();
            }
            return View(leisureTop);
        }

        // POST: LeisureTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeisureTopID,LeisureTopName,LeisureTopPhoto,LeisureTopColor,LeisureTopSeason,LeisureTopOccasion,LeisureTopType")] LeisureTop leisureTop)
        {
            if (ModelState.IsValid)
            {
                leisureTop.LeisureTopPhoto = "~/Content/Images/Athletictop.jpg";
                leisureTop.LeisureTopType = "Leisure";
                db.Entry(leisureTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leisureTop);
        }

        // GET: LeisureTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureTop leisureTop = db.LeisureTops.Find(id);
            if (leisureTop == null)
            {
                return HttpNotFound();
            }
            return View(leisureTop);
        }

        // POST: LeisureTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeisureTop leisureTop = db.LeisureTops.Find(id);
            db.LeisureTops.Remove(leisureTop);
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
