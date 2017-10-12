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
    public class InformalBottomsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: InformalBottoms
        public ActionResult Index()
        {
            return View(db.InformalBottoms.ToList());
        }

        // GET: InformalBottoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBottom informalBottom = db.InformalBottoms.Find(id);
            if (informalBottom == null)
            {
                return HttpNotFound();
            }
            return View(informalBottom);
        }

        // GET: InformalBottoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalBottoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformalBottomID,InformalBottomName,InformalBottomPhoto,InformalBottomColor,InformalBottomSeason,InformalBottomOccasion,InformalBottomType")] InformalBottom informalBottom)
        {
            if (ModelState.IsValid)
            {
                informalBottom.InformalBottomPhoto = "~/Content/Images/jeans.jpg";
                informalBottom.InformalBottomType = "Informal";
                db.InformalBottoms.Add(informalBottom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalBottom);
        }

        // GET: InformalBottoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBottom informalBottom = db.InformalBottoms.Find(id);
            if (informalBottom == null)
            {
                return HttpNotFound();
            }
            return View(informalBottom);
        }

        // POST: InformalBottoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformalBottomID,InformalBottomName,InformalBottomPhoto,InformalBottomColor,InformalBottomSeason,InformalBottomOccasion,InformalBottomType")] InformalBottom informalBottom)
        {
            if (ModelState.IsValid)
            {
                informalBottom.InformalBottomPhoto = "~/Content/Images/jeans.jpg";
                informalBottom.InformalBottomType = "Informal";
                db.Entry(informalBottom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalBottom);
        }

        // GET: InformalBottoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalBottom informalBottom = db.InformalBottoms.Find(id);
            if (informalBottom == null)
            {
                return HttpNotFound();
            }
            return View(informalBottom);
        }

        // POST: InformalBottoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalBottom informalBottom = db.InformalBottoms.Find(id);
            db.InformalBottoms.Remove(informalBottom);
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
