using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MGO.Models;

namespace MGO.Controllers
{
    [Authorize(Roles = "manager, employee")]
    public class PurchaseItemsController : Controller
    {
        private MGO_Entities db = new MGO_Entities();
        private string Name = "Purchased Product";

        // GET: PurchaseItems
        public ActionResult Index()
        {
            var purchaseItems = db.PurchaseItems.Include(p => p.Item).Include(p => p.Purchase);
            return View(purchaseItems.ToList());
        }

        // GET: PurchaseItems/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "For";
            ViewBag.Controller = Name;
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Create
        public ActionResult Create()
        {
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description");
            ViewBag.PO_Num = new SelectList(db.Purchases, "PO_Num", "PO_Num");
            ViewBag.Title = "New";
            ViewBag.Controller = Name;
            return View();
        }

        // POST: PurchaseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PO_Num,PI_Qty,SKU")] PurchaseItem purchaseItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseItems.Add(purchaseItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", purchaseItem.SKU);
            ViewBag.PO_Num = new SelectList(db.Purchases, "PO_Num", "PO_Num", purchaseItem.PO_Num);
            ViewBag.Controller = Name;
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", purchaseItem.SKU);
            ViewBag.PO_Num = new SelectList(db.Purchases, "PO_Num", "PO_Num", purchaseItem.PO_Num);
            ViewBag.Controller = Name;
            return View(purchaseItem);
        }

        // POST: PurchaseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PO_Num,PI_Qty,SKU")] PurchaseItem purchaseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", purchaseItem.SKU);
            ViewBag.PO_Num = new SelectList(db.Purchases, "PO_Num", "PO_Num", purchaseItem.PO_Num);
            ViewBag.Controller = Name;
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            if (purchaseItem == null)
            {
                return HttpNotFound();
            }

            ViewBag.Controller = Name;
            return View(purchaseItem);
        }

        // POST: PurchaseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PurchaseItem purchaseItem = db.PurchaseItems.Find(id);
            db.PurchaseItems.Remove(purchaseItem);
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
