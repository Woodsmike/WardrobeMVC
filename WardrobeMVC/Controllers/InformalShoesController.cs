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
    public class InformalShoesController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: InformalShoes
        public ActionResult Index()
        {
            return View(db.InformalShoes.ToList());
        }

        // GET: InformalShoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalSho informalSho = db.InformalShoes.Find(id);
            if (informalSho == null)
            {
                return HttpNotFound();
            }
            return View(informalSho);
        }

        // GET: InformalShoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformalShoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformalShoesID,InformalShoesName,InformalShoesPhoto,InformalShoesColor,InformalShoesSeason,InformalShoesOccasion,InformalShoesType")] InformalSho informalSho)
        {
            if (ModelState.IsValid)
            {
                informalSho.InformalShoesPhoto = "~/Content/Images/boots.jpg";
                informalSho.InformalShoesType = "Informal";
                db.InformalShoes.Add(informalSho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informalSho);
        }

        // GET: InformalShoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalSho informalSho = db.InformalShoes.Find(id);
            if (informalSho == null)
            {
                return HttpNotFound();
            }
            return View(informalSho);
        }

        // POST: InformalShoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformalShoesID,InformalShoesName,InformalShoesPhoto,InformalShoesColor,InformalShoesSeason,InformalShoesOccasion,InformalShoesType")] InformalSho informalSho)
        {
            if (ModelState.IsValid)
            {
                informalSho.InformalShoesPhoto = "~/Content/Images/boots.jpg";
                informalSho.InformalShoesType = "Informal";
                db.Entry(informalSho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informalSho);
        }

        // GET: InformalShoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalSho informalSho = db.InformalShoes.Find(id);
            if (informalSho == null)
            {
                return HttpNotFound();
            }
            return View(informalSho);
        }

        // POST: InformalShoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalSho informalSho = db.InformalShoes.Find(id);
            db.InformalShoes.Remove(informalSho);
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
