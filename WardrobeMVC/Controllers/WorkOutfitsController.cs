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
    public class WorkOutfitsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: WorkOutfits
        public ActionResult Index()
        {
            var workOutfits = db.WorkOutfits.Include(w => w.Outfit).Include(w => w.WorkAccessory).Include(w => w.WorkBottom).Include(w => w.WorkSho).Include(w => w.WorkTop);
            return View(workOutfits.ToList());
        }

        // GET: WorkOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutfit workOutfit = db.WorkOutfits.Find(id);
            if (workOutfit == null)
            {
                return HttpNotFound();
            }
            return View(workOutfit);
        }

        // GET: WorkOutfits/Create
        public ActionResult Create()
        {
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName");
            ViewBag.WorkAccessoryID = new SelectList(db.WorkAccessories, "WorkAccessoryID", "WorkAccessoryName");
            ViewBag.WorkBottomID = new SelectList(db.WorkBottoms, "WorkBottomID", "WorkBottomName");
            ViewBag.WorkShoesID = new SelectList(db.WorkShoes, "WorkShoesID", "WorkShoesName");
            ViewBag.WorkTopID = new SelectList(db.WorkTops, "WorkTopID", "WorkTopName");
            return View();
        }

        // POST: WorkOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOutfitID,MainOutfitID,WorkTopID,WorkBottomID,WorkShoesID,WorkAccessoryID")] WorkOutfit workOutfit)
        {
            if (ModelState.IsValid)
            {
                db.WorkOutfits.Add(workOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", workOutfit.MainOutfitID);
            ViewBag.WorkAccessoryID = new SelectList(db.WorkAccessories, "WorkAccessoryID", "WorkAccessoryName", workOutfit.WorkAccessoryID);
            ViewBag.WorkBottomID = new SelectList(db.WorkBottoms, "WorkBottomID", "WorkBottomName", workOutfit.WorkBottomID);
            ViewBag.WorkShoesID = new SelectList(db.WorkShoes, "WorkShoesID", "WorkShoesName", workOutfit.WorkShoesID);
            ViewBag.WorkTopID = new SelectList(db.WorkTops, "WorkTopID", "WorkTopName", workOutfit.WorkTopID);
            return View(workOutfit);
        }

        // GET: WorkOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutfit workOutfit = db.WorkOutfits.Find(id);
            if (workOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", workOutfit.MainOutfitID);
            ViewBag.WorkAccessoryID = new SelectList(db.WorkAccessories, "WorkAccessoryID", "WorkAccessoryName", workOutfit.WorkAccessoryID);
            ViewBag.WorkBottomID = new SelectList(db.WorkBottoms, "WorkBottomID", "WorkBottomName", workOutfit.WorkBottomID);
            ViewBag.WorkShoesID = new SelectList(db.WorkShoes, "WorkShoesID", "WorkShoesName", workOutfit.WorkShoesID);
            ViewBag.WorkTopID = new SelectList(db.WorkTops, "WorkTopID", "WorkTopName", workOutfit.WorkTopID);
            return View(workOutfit);
        }

        // POST: WorkOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOutfitID,MainOutfitID,WorkTopID,WorkBottomID,WorkShoesID,WorkAccessoryID")] WorkOutfit workOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", workOutfit.MainOutfitID);
            ViewBag.WorkAccessoryID = new SelectList(db.WorkAccessories, "WorkAccessoryID", "WorkAccessoryName", workOutfit.WorkAccessoryID);
            ViewBag.WorkBottomID = new SelectList(db.WorkBottoms, "WorkBottomID", "WorkBottomName", workOutfit.WorkBottomID);
            ViewBag.WorkShoesID = new SelectList(db.WorkShoes, "WorkShoesID", "WorkShoesName", workOutfit.WorkShoesID);
            ViewBag.WorkTopID = new SelectList(db.WorkTops, "WorkTopID", "WorkTopName", workOutfit.WorkTopID);
            return View(workOutfit);
        }

        // GET: WorkOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutfit workOutfit = db.WorkOutfits.Find(id);
            if (workOutfit == null)
            {
                return HttpNotFound();
            }
            return View(workOutfit);
        }

        // POST: WorkOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOutfit workOutfit = db.WorkOutfits.Find(id);
            db.WorkOutfits.Remove(workOutfit);
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
