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
    public class InformalTopsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: InformalTops
        public ActionResult Index()
        {
            return View(db.InformalTops.ToList());
        }

        // GET: InformalTops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalTop informalTop = db.InformalTops.Find(id);
            if (informalTop == null)
            {
                return HttpNotFound();
            }
            return View(informalTop);
        }

        // GET: InformalTops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalTops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformalTopID,InformalTopName,InformalTopPhoto,InformalTopColor,InformalTopSeason,InformalTopOccasion,InformalTopType")] InformalTop informalTop)
        {
            if (ModelState.IsValid)
            {
                informalTop.InformalTopPhoto = "~/Content/Images/MensInformalShirt.jpg";
                informalTop.InformalTopType = "Informal";
                db.InformalTops.Add(informalTop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalTop);
        }

        // GET: InformalTops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalTop informalTop = db.InformalTops.Find(id);
            if (informalTop == null)
            {
                return HttpNotFound();
            }
            return View(informalTop);
        }

        // POST: InformalTops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformalTopID,InformalTopName,InformalTopPhoto,InformalTopColor,InformalTopSeason,InformalTopOccasion,InformalTopType")] InformalTop informalTop)
        {
            if (ModelState.IsValid)
            {
                informalTop.InformalTopPhoto = "~/Content/Images/MensInformalShirt.jpg";
                informalTop.InformalTopType = "Informal";
                db.Entry(informalTop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalTop);
        }

        // GET: InformalTops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalTop informalTop = db.InformalTops.Find(id);
            if (informalTop == null)
            {
                return HttpNotFound();
            }
            return View(informalTop);
        }

        // POST: InformalTops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalTop informalTop = db.InformalTops.Find(id);
            db.InformalTops.Remove(informalTop);
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
