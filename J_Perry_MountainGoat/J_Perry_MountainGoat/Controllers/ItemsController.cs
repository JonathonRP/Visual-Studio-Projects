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
    public class ItemsController : Controller
    {
        private MGO_Entities db = new MGO_Entities();
        private string Name = "Product";

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "For";
            ViewBag.Controller = Name;
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.Cat_Num = new SelectList(db.Categories, "Cat_Num", "Cat_Description");

            ViewBag.Title = "New";
            ViewBag.Controller = Name;
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SKU,Item_Description,Item_Price,Cat_Num")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_Num = new SelectList(db.Categories, "Cat_Num", "Cat_Description", item.Cat_Num);
            ViewBag.Controller = Name;
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.Cat_Num = new SelectList(db.Categories, "Cat_Num", "Cat_Description", item.Cat_Num);
            ViewBag.Controller = Name;
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SKU,Item_Description,Item_Price,Cat_Num")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_Num = new SelectList(db.Categories, "Cat_Num", "Cat_Description", item.Cat_Num);
            ViewBag.Controller = Name;
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.Controller = Name;
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
