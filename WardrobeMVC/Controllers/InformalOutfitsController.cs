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
    public class InformalOutfitsController : Controller
    {
        private MVCWardrobeEntities db = new MVCWardrobeEntities();

        // GET: InformalOutfits
        public ActionResult Index()
        {
            var informalOutfits = db.InformalOutfits.Include(i => i.InformalAccessory).Include(i => i.InformalBottom).Include(i => i.InformalSho).Include(i => i.InformalTop).Include(i => i.Outfit);
            return View(informalOutfits.ToList());
        }

        // GET: InformalOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalOutfit informalOutfit = db.InformalOutfits.Find(id);
            if (informalOutfit == null)
            {
                return HttpNotFound();
            }
            return View(informalOutfit);
        }

        // GET: InformalOutfits/Create
        public ActionResult Create()
        {
            ViewBag.InformalAccessoryID = new SelectList(db.InformalAccessories, "InformalAccessoryID", "InformalAccessoryName");
            ViewBag.InformalBottomID = new SelectList(db.InformalBottoms, "InformalBottomID", "InformalBottomName");
            ViewBag.InformalShoesID = new SelectList(db.InformalShoes, "InformalShoesID", "InformalShoesName");
            ViewBag.InformalTopID = new SelectList(db.InformalTops, "InformalTopID", "InformalTopName");
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName");
            return View();
        }

        // POST: InformalOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformalOutfitID,MainOutfitID,InformalTopID,InformalBottomID,InformalShoesID,InformalAccessoryID")] InformalOutfit informalOutfit)
        {
            if (ModelState.IsValid)
            {
                db.InformalOutfits.Add(informalOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InformalAccessoryID = new SelectList(db.InformalAccessories, "InformalAccessoryID", "InformalAccessoryName", informalOutfit.InformalAccessoryID);
            ViewBag.InformalBottomID = new SelectList(db.InformalBottoms, "InformalBottomID", "InformalBottomName", informalOutfit.InformalBottomID);
            ViewBag.InformalShoesID = new SelectList(db.InformalShoes, "InformalShoesID", "InformalShoesName", informalOutfit.InformalShoesID);
            ViewBag.InformalTopID = new SelectList(db.InformalTops, "InformalTopID", "InformalTopName", informalOutfit.InformalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", informalOutfit.MainOutfitID);
            return View(informalOutfit);
        }

        // GET: InformalOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalOutfit informalOutfit = db.InformalOutfits.Find(id);
            if (informalOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformalAccessoryID = new SelectList(db.InformalAccessories, "InformalAccessoryID", "InformalAccessoryName", informalOutfit.InformalAccessoryID);
            ViewBag.InformalBottomID = new SelectList(db.InformalBottoms, "InformalBottomID", "InformalBottomName", informalOutfit.InformalBottomID);
            ViewBag.InformalShoesID = new SelectList(db.InformalShoes, "InformalShoesID", "InformalShoesName", informalOutfit.InformalShoesID);
            ViewBag.InformalTopID = new SelectList(db.InformalTops, "InformalTopID", "InformalTopName", informalOutfit.InformalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", informalOutfit.MainOutfitID);
            return View(informalOutfit);
        }

        // POST: InformalOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformalOutfitID,MainOutfitID,InformalTopID,InformalBottomID,InformalShoesID,InformalAccessoryID")] InformalOutfit informalOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informalOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InformalAccessoryID = new SelectList(db.InformalAccessories, "InformalAccessoryID", "InformalAccessoryName", informalOutfit.InformalAccessoryID);
            ViewBag.InformalBottomID = new SelectList(db.InformalBottoms, "InformalBottomID", "InformalBottomName", informalOutfit.InformalBottomID);
            ViewBag.InformalShoesID = new SelectList(db.InformalShoes, "InformalShoesID", "InformalShoesName", informalOutfit.InformalShoesID);
            ViewBag.InformalTopID = new SelectList(db.InformalTops, "InformalTopID", "InformalTopName", informalOutfit.InformalTopID);
            ViewBag.MainOutfitID = new SelectList(db.Outfits, "MainOutfitID", "OutfitName", informalOutfit.MainOutfitID);
            return View(informalOutfit);
        }

        // GET: InformalOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformalOutfit informalOutfit = db.InformalOutfits.Find(id);
            if (informalOutfit == null)
            {
                return HttpNotFound();
            }
            return View(informalOutfit);
        }

        // POST: InformalOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformalOutfit informalOutfit = db.InformalOutfits.Find(id);
            db.InformalOutfits.Remove(informalOutfit);
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
