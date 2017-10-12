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
    public class WorkShoesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: WorkShoes
        public ActionResult Index()
        {
            return View(db.WorkShoes.ToList());
        }

        // GET: WorkShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSho workSho = db.WorkShoes.Find(id);
            if (workSho == null)
            {
                return HttpNotFound();
            }
            return View(workSho);
        }

        // GET: WorkShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkShoesID,WorkShoesName,WorkShoesPhoto,WorkShoesColor,WorkShoesSeason,WorkShoesOccasion,WorkShoesType")] WorkSho workSho)
        {
            if (ModelState.IsValid)
            {
                workSho.WorkShoesPhoto = "~/Content/Images/MensDressShoes.jpg";
                workSho.WorkShoesType = "Work";
                db.WorkShoes.Add(workSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workSho);
        }

        // GET: WorkShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSho workSho = db.WorkShoes.Find(id);
            if (workSho == null)
            {
                return HttpNotFound();
            }
            return View(workSho);
        }

        // POST: WorkShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkShoesID,WorkShoesName,WorkShoesPhoto,WorkShoesColor,WorkShoesSeason,WorkShoesOccasion,WorkShoesType")] WorkSho workSho)
        {
            if (ModelState.IsValid)
            {
                workSho.WorkShoesPhoto = "~/Content/Images/MensDressShoes.jpg";
                workSho.WorkShoesType = "Work";
                db.Entry(workSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workSho);
        }

        // GET: WorkShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSho workSho = db.WorkShoes.Find(id);
            if (workSho == null)
            {
                return HttpNotFound();
            }
            return View(workSho);
        }

        // POST: WorkShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkSho workSho = db.WorkShoes.Find(id);
            db.WorkShoes.Remove(workSho);
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
