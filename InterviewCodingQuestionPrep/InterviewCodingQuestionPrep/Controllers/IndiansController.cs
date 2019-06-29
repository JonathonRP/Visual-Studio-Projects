using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterviewCodingQuestionPrep.Models;

namespace InterviewCodingQuestionPrep.Controllers
{
    public class IndiansController : Controller
    {
        private DummyDataEntities db = new DummyDataEntities();

        // GET: Indians
        public ActionResult Index()
        {
            var indians = db.Indians.Include( i => i.Cowboys );
            return View(indians.ToList());
        }

        private List<KilledViewModel> GetKills()
        {
            return db.Cowboys.Select( x => new KilledViewModel { Id = x.Id, Name = x.Cowboy_Name } )
                 .ToList();
        }

        private void PopulateAssignedKillData( Indians indian )
        {
            var allCowboys = db.Cowboys;
            var indianKills = new HashSet<int>( indian.Cowboys.Select( c => c.Id ) );
            var kills = new List<KilledViewModel>();

            foreach ( var cowboy in allCowboys )
            {
                kills.Add( new KilledViewModel
                {
                    Id = cowboy.Id,
                    Name = cowboy.Cowboy_Name,
                    IsAssigned = indianKills.Contains( cowboy.Id )
                } );
            }

            ViewBag.Killed = kills;
        }

        private void UpdateIndianKills( string[] selectedCowboys, Indians indianToUpdate )
        {
            if ( selectedCowboys == null )
            {
                indianToUpdate.Cowboys = new List<Cowboys>();
                return;
            }

            var selectedCowboysHS = new HashSet<string>( selectedCowboys );
            var indianKills = new HashSet<int>
                ( indianToUpdate.Cowboys.Select( c => c.Id ) );
            foreach ( var cowboy in db.Cowboys )
            {
                if ( selectedCowboysHS.Contains( cowboy.Id.ToString() ) )
                {
                    if ( !indianKills.Contains( cowboy.Id ) )
                    {
                        indianToUpdate.Cowboys.Add( cowboy );
                    }
                }
                else
                {
                    if ( indianKills.Contains( cowboy.Id ) )
                    {
                        indianToUpdate.Cowboys.Remove( cowboy );
                    }
                }
            }
        }

        // GET: Indians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indians indians = db.Indians.Include( i => i.Cowboys ).Single( i => i.Id == id );
            if (indians == null)
            {
                return HttpNotFound();
            }

            return View(indians);
        }

        // GET: Indians/Create
        public ActionResult Create()
        {
            ViewBag.Killed = GetKills();

            return View();
        }

        // POST: Indians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Indian_Name,Cowboys")] Indians indians, string[] selectedCowboys)
        {
            if (ModelState.IsValid)
            {
                UpdateIndianKills( selectedCowboys, indians );
                db.Indians.Add(indians);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedKillData( indians );
            return View(indians);
        }

        // GET: Indians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indians indians = db.Indians.Include(i => i.Cowboys).Single(i => i.Id == id);
            PopulateAssignedKillData( indians );
            if (indians == null)
            {
                return HttpNotFound();
            }

            return View(indians);
        }

        // POST: Indians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Indian_Name,Cowboys")] Indians indians, string[] selectedCowboys)
        {
            if (ModelState.IsValid)
            {
                //var indian = db.Indians.Include( i => i.Cowboys ).Where( i => i.Id == indians.Id ).Single();
                db.Indians.Attach( indians );
                db.Entry( indians ).Collection( x => x.Cowboys ).Load();
                UpdateIndianKills( selectedCowboys, indians );
                
                db.Entry( indians ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedKillData( indians );
            return View(indians);
        }

        // GET: Indians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indians indians = db.Indians.Include( i => i.Cowboys ).Single( i => i.Id == id );
            if (indians == null)
            {
                return HttpNotFound();
            }

            return View(indians);
        }

        // POST: Indians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indians indians = db.Indians.Include( i => i.Cowboys ).Single( i => i.Id == id );
            db.Indians.Remove(indians);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Count(int? id)
        {
            Stat IndiansStat = new Stat { Label = "Indians" };

            if ( id.HasValue )
            {
                IndiansStat.Label = db.Indians.Include( i => i.Cowboys ).Single( i => i.Id == id ).Indian_Name + " killed";
                IndiansStat.Count = db.Indians.Include( i => i.Cowboys ).Single( i => i.Id == id ).Cowboys.Count;
            }
            else
            {
                IndiansStat.Count = db.Indians.Include( i => i.Cowboys ).Count();
            }

            return Json( IndiansStat, JsonRequestBehavior.AllowGet );
        }

        public ActionResult Stats( int? id )
        {
            Indians indian = db.Indians.Include( c => c.Cowboys ).Single( c => c.Id == id );
            if ( id.HasValue && indian == null )
            {
                return HttpNotFound();
            }

            return View(indian);
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
