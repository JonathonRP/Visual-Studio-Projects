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
    public class SaleItemsController : Controller
    {
        private MGO_Entities db = new MGO_Entities();

        // GET: SaleItems
        public ActionResult Index()
        {
            var saleItems = db.SaleItems.Include(s => s.Item).Include(s => s.Sale);
            return View(saleItems.ToList());
        }

        // GET: SaleItems/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }
            return View(saleItem);
        }

        // GET: SaleItems/Create
        public ActionResult Create()
        {
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description");
            ViewBag.Sale_Num = new SelectList(db.Sales, "Sale_Num", "Sale_Num");
            return View();
        }

        // POST: SaleItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sale_Num,SI_Qty_Sold,SKU")] SaleItem saleItem)
        {
            if (ModelState.IsValid)
            {
                db.SaleItems.Add(saleItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", saleItem.SKU);
            ViewBag.Sale_Num = new SelectList(db.Sales, "Sale_Num", "Sale_Num", saleItem.Sale_Num);
            return View(saleItem);
        }

        // GET: SaleItems/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", saleItem.SKU);
            ViewBag.Sale_Num = new SelectList(db.Sales, "Sale_Num", "Sale_Num", saleItem.Sale_Num);
            return View(saleItem);
        }

        // POST: SaleItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sale_Num,SI_Qty_Sold,SKU")] SaleItem saleItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SKU = new SelectList(db.Items, "SKU", "Item_Description", saleItem.SKU);
            ViewBag.Sale_Num = new SelectList(db.Sales, "Sale_Num", "Sale_Num", saleItem.Sale_Num);
            return View(saleItem);
        }

        // GET: SaleItems/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleItem saleItem = db.SaleItems.Find(id);
            if (saleItem == null)
            {
                return HttpNotFound();
            }
            return View(saleItem);
        }

        // POST: SaleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            SaleItem saleItem = db.SaleItems.Find(id);
            db.SaleItems.Remove(saleItem);
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
