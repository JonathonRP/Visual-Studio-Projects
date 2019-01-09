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
    public class SalesController : Controller
    {
        private MGO_Entities db = new MGO_Entities();
        private string Name = "Sale";

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Customer).Include(s => s.Employee);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "For";
            ViewBag.Controller = Name;
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_FName");
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_FName");
            ViewBag.Title = "New";
            ViewBag.Controller = Name;
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sale_Num,S_Date,S_Time,Emp_ID,Cust_ID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_FName", sale.Cust_ID);
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_FName", sale.Emp_ID);
            ViewBag.Controller = Name;
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_FName", sale.Cust_ID);
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_FName", sale.Emp_ID);
            ViewBag.Controller = Name;
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sale_Num,S_Date,S_Time,Emp_ID,Cust_ID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_FName", sale.Cust_ID);
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_FName", sale.Emp_ID);
            ViewBag.Controller = Name;
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            ViewBag.Controller = Name;
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
