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
    public class FormalOutfitsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: FormalOutfits
        public ActionResult Index()
        {
            var formalOutfits = db.FormalOutfits.Include(f => f.FormalAccessory).Include(f => f.FormalBottom).Include(f => f.FormalSho).Include(f => f.FormalTop).Include(f => f.Outfit);
            return View(formalOutfits.ToList());
        }

        // GET: FormalOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalOutfit formalOutfit = db.FormalOutfits.Find(id);
            if (formalOutfit == null)
            {
                return HttpNotFound();
            }
            return View(formalOutfit);
        }

        // GET: FormalOutfits/Create
        public ActionResult Create()
        {
            ViewBag.FormalAccessoryID = new SelectList(db.FormalAccessories, "FormalAccessoryID", "FormalAccessoryName");
            ViewBag.FormalBottomID = new SelectList(db.FormalBottoms, "FormalBottomID", "FormalBottomName");
            ViewBag.FormalShoesID = new SelectList(db.FormalShoes, "FormalShoesID", "FormalShoesName");
            ViewBag.FormalTopID = new SelectList(db.FormalTops, "FormalTopID", "FormalTopName");
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName");
            return View();
        }

        // POST: FormalOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormalOutfitID,MainOutfitID,FormalTopID,FormalBottomID,FormalShoesID,FormalAccessoryID")] FormalOutfit formalOutfit)
        {
            if (ModelState.IsValid)
            {
                db.FormalOutfits.Add(formalOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormalAccessoryID = new SelectList(db.FormalAccessories, "FormalAccessoryID", "FormalAccessoryName", formalOutfit.FormalAccessoryID);
            ViewBag.FormalBottomID = new SelectList(db.FormalBottoms, "FormalBottomID", "FormalBottomName", formalOutfit.FormalBottomID);
            ViewBag.FormalShoesID = new SelectList(db.FormalShoes, "FormalShoesID", "FormalShoesName", formalOutfit.FormalShoesID);
            ViewBag.FormalTopID = new SelectList(db.FormalTops, "FormalTopID", "FormalTopName", formalOutfit.FormalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", formalOutfit.MainOutfitID);
            return View(formalOutfit);
        }

        // GET: FormalOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalOutfit formalOutfit = db.FormalOutfits.Find(id);
            if (formalOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormalAccessoryID = new SelectList(db.FormalAccessories, "FormalAccessoryID", "FormalAccessoryName", formalOutfit.FormalAccessoryID);
            ViewBag.FormalBottomID = new SelectList(db.FormalBottoms, "FormalBottomID", "FormalBottomName", formalOutfit.FormalBottomID);
            ViewBag.FormalShoesID = new SelectList(db.FormalShoes, "FormalShoesID", "FormalShoesName", formalOutfit.FormalShoesID);
            ViewBag.FormalTopID = new SelectList(db.FormalTops, "FormalTopID", "FormalTopName", formalOutfit.FormalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", formalOutfit.MainOutfitID);
            return View(formalOutfit);
        }

        // POST: FormalOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormalOutfitID,MainOutfitID,FormalTopID,FormalBottomID,FormalShoesID,FormalAccessoryID")] FormalOutfit formalOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formalOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormalAccessoryID = new SelectList(db.FormalAccessories, "FormalAccessoryID", "FormalAccessoryName", formalOutfit.FormalAccessoryID);
            ViewBag.FormalBottomID = new SelectList(db.FormalBottoms, "FormalBottomID", "FormalBottomName", formalOutfit.FormalBottomID);
            ViewBag.FormalShoesID = new SelectList(db.FormalShoes, "FormalShoesID", "FormalShoesName", formalOutfit.FormalShoesID);
            ViewBag.FormalTopID = new SelectList(db.FormalTops, "FormalTopID", "FormalTopName", formalOutfit.FormalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", formalOutfit.MainOutfitID);
            return View(formalOutfit);
        }

        // GET: FormalOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormalOutfit formalOutfit = db.FormalOutfits.Find(id);
            if (formalOutfit == null)
            {
                return HttpNotFound();
            }
            return View(formalOutfit);
        }

        // POST: FormalOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormalOutfit formalOutfit = db.FormalOutfits.Find(id);
            db.FormalOutfits.Remove(formalOutfit);
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
