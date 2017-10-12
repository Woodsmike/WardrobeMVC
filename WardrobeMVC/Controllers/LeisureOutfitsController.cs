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
    public class LeisureOutfitsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: LeisureOutfits
        public ActionResult Index()
        {
            var leisureOutfits = db.LeisureOutfits.Include(l => l.LeisureAccessory).Include(l => l.LeisureBottom).Include(l => l.LeisureSho).Include(l => l.LeisureTop).Include(l => l.Outfit);
            return View(leisureOutfits.ToList());
        }

        // GET: LeisureOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureOutfit leisureOutfit = db.LeisureOutfits.Find(id);
            if (leisureOutfit == null)
            {
                return HttpNotFound();
            }
            return View(leisureOutfit);
        }

        // GET: LeisureOutfits/Create
        public ActionResult Create()
        {
            ViewBag.LeisureAccessoryID = new SelectList(db.LeisureAccessories, "LeisureAccessoryID", "LeisureAccessoryName");
            ViewBag.LeisureBottomID = new SelectList(db.LeisureBottoms, "LeisureBottomID", "LeisureBottomName");
            ViewBag.LeisureShoesID = new SelectList(db.LeisureShoes, "LeisureShoesID", "LeisureShoesName");
            ViewBag.LeisureTopID = new SelectList(db.LeisureTops, "LeisureTopID", "LeisureTopName");
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName");
            return View();
        }

        // POST: LeisureOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeisureOutfitID,MainOutfitID,LeisureTopID,LeisureBottomID,LeisureShoesID,LeisureAccessoryID")] LeisureOutfit leisureOutfit)
        {
            if (ModelState.IsValid)
            {
                db.LeisureOutfits.Add(leisureOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeisureAccessoryID = new SelectList(db.LeisureAccessories, "LeisureAccessoryID", "LeisureAccessoryName", leisureOutfit.LeisureAccessoryID);
            ViewBag.LeisureBottomID = new SelectList(db.LeisureBottoms, "LeisureBottomID", "LeisureBottomName", leisureOutfit.LeisureBottomID);
            ViewBag.LeisureShoesID = new SelectList(db.LeisureShoes, "LeisureShoesID", "LeisureShoesName", leisureOutfit.LeisureShoesID);
            ViewBag.LeisureTopID = new SelectList(db.LeisureTops, "LeisureTopID", "LeisureTopName", leisureOutfit.LeisureTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", leisureOutfit.MainOutfitID);
            return View(leisureOutfit);
        }

        // GET: LeisureOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureOutfit leisureOutfit = db.LeisureOutfits.Find(id);
            if (leisureOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeisureAccessoryID = new SelectList(db.LeisureAccessories, "LeisureAccessoryID", "LeisureAccessoryName", leisureOutfit.LeisureAccessoryID);
            ViewBag.LeisureBottomID = new SelectList(db.LeisureBottoms, "LeisureBottomID", "LeisureBottomName", leisureOutfit.LeisureBottomID);
            ViewBag.LeisureShoesID = new SelectList(db.LeisureShoes, "LeisureShoesID", "LeisureShoesName", leisureOutfit.LeisureShoesID);
            ViewBag.LeisureTopID = new SelectList(db.LeisureTops, "LeisureTopID", "LeisureTopName", leisureOutfit.LeisureTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", leisureOutfit.MainOutfitID);
            return View(leisureOutfit);
        }

        // POST: LeisureOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeisureOutfitID,MainOutfitID,LeisureTopID,LeisureBottomID,LeisureShoesID,LeisureAccessoryID")] LeisureOutfit leisureOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leisureOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeisureAccessoryID = new SelectList(db.LeisureAccessories, "LeisureAccessoryID", "LeisureAccessoryName", leisureOutfit.LeisureAccessoryID);
            ViewBag.LeisureBottomID = new SelectList(db.LeisureBottoms, "LeisureBottomID", "LeisureBottomName", leisureOutfit.LeisureBottomID);
            ViewBag.LeisureShoesID = new SelectList(db.LeisureShoes, "LeisureShoesID", "LeisureShoesName", leisureOutfit.LeisureShoesID);
            ViewBag.LeisureTopID = new SelectList(db.LeisureTops, "LeisureTopID", "LeisureTopName", leisureOutfit.LeisureTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", leisureOutfit.MainOutfitID);
            return View(leisureOutfit);
        }

        // GET: LeisureOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeisureOutfit leisureOutfit = db.LeisureOutfits.Find(id);
            if (leisureOutfit == null)
            {
                return HttpNotFound();
            }
            return View(leisureOutfit);
        }

        // POST: LeisureOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeisureOutfit leisureOutfit = db.LeisureOutfits.Find(id);
            db.LeisureOutfits.Remove(leisureOutfit);
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
