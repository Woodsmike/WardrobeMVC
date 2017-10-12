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
    public class FormalShoesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: FormalShoes
        public ActionResult Index()
        {
            return View(db.FormalShoes.ToList());
        }

        // GET: FormalShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalSho formalSho = db.FormalShoes.Find(id);
            if (formalSho == null)
            {
                return HttpNotFound();
            }
            return View(formalSho);
        }

        // GET: FormalShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormalShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormalShoesID,FormalShoesName,FormalShoesPhoto,FormalShoesColor,FormalShoesSeason,FormalShoesOccasion,FormalShoesType")] FormalSho formalSho)
        {
            if (ModelState.IsValid)
            {
                formalSho.FormalShoesPhoto = "~/Content/Images/TuxedoShoes.jpg";
                formalSho.FormalShoesType = "Formal";
                db.FormalShoes.Add(formalSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formalSho);
        }

        // GET: FormalShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalSho formalSho = db.FormalShoes.Find(id);
            if (formalSho == null)
            {
                return HttpNotFound();
            }
            return View(formalSho);
        }

        // POST: FormalShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormalShoesID,FormalShoesName,FormalShoesPhoto,FormalShoesColor,FormalShoesSeason,FormalShoesOccasion,FormalShoesType")] FormalSho formalSho)
        {
            if (ModelState.IsValid)
            {
                formalSho.FormalShoesPhoto = "~/Content/Images/TuxedoShoes.jpg";
                formalSho.FormalShoesType = "Formal";
                db.Entry(formalSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formalSho);
        }

        // GET: FormalShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalSho formalSho = db.FormalShoes.Find(id);
            if (formalSho == null)
            {
                return HttpNotFound();
            }
            return View(formalSho);
        }

        // POST: FormalShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalSho formalSho = db.FormalShoes.Find(id);
            db.FormalShoes.Remove(formalSho);
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
