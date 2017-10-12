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
    public class LeisureShoesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: LeisureShoes
        public ActionResult Index()
        {
            return View(db.LeisureShoes.ToList());
        }

        // GET: LeisureShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureSho leisureSho = db.LeisureShoes.Find(id);
            if (leisureSho == null)
            {
                return HttpNotFound();
            }
            return View(leisureSho);
        }

        // GET: LeisureShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeisureShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeisureShoesID,LeisureShoesName,LeisureShoesPhoto,LeisureShoesColor,LeisureShoesSeason,LeisureShoesOccasion,LeisureShoesType")] LeisureSho leisureSho)
        {
            if (ModelState.IsValid)
            {
                leisureSho.LeisureShoesPhoto = "~/Content/Images/tennisshoes.jpg";
                leisureSho.LeisureShoesType = "Leisure";
                db.LeisureShoes.Add(leisureSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leisureSho);
        }

        // GET: LeisureShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureSho leisureSho = db.LeisureShoes.Find(id);
            if (leisureSho == null)
            {
                return HttpNotFound();
            }
            return View(leisureSho);
        }

        // POST: LeisureShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeisureShoesID,LeisureShoesName,LeisureShoesPhoto,LeisureShoesColor,LeisureShoesSeason,LeisureShoesOccasion,LeisureShoesType")] LeisureSho leisureSho)
        {
            if (ModelState.IsValid)
            {
                leisureSho.LeisureShoesPhoto = "~/Content/Images/tennisshoes.jpg";
                leisureSho.LeisureShoesType = "Leisure";
                db.Entry(leisureSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leisureSho);
        }

        // GET: LeisureShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureSho leisureSho = db.LeisureShoes.Find(id);
            if (leisureSho == null)
            {
                return HttpNotFound();
            }
            return View(leisureSho);
        }

        // POST: LeisureShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeisureSho leisureSho = db.LeisureShoes.Find(id);
            db.LeisureShoes.Remove(leisureSho);
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
