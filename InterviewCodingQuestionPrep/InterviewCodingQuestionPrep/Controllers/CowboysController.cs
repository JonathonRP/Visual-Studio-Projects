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
    public class CowboysController : Controller
    {
        private DummyDataEntities db = new DummyDataEntities();

        // GET: Cowboys
        public ActionResult Index()
        {
            var cowboys = db.Cowboys.Include( c => c.Indians );
            return View(cowboys.ToList());
        }

        private List<KilledViewModel> GetKills()
        {
            return db.Cowboys.Select( x => new KilledViewModel { Id = x.Id, Name = x.Cowboy_Name } )
                 .ToList();
        }

        private void PopulateAssignedKillData( Cowboys cowboy )
        {
            var allIndians = db.Indians;
            var indianKills = new HashSet<int>( cowboy.Indians.Select( i => i.Id ) );
            var kills = new List<KilledViewModel>();

            foreach ( var indian in allIndians )
            {
                kills.Add( new KilledViewModel
                {
                    Id = indian.Id,
                    Name = indian.Indian_Name,
                    IsAssigned = indianKills.Contains( indian.Id )
                } );
            }

            ViewBag.Killed = kills;
        }

        private void UpdateCowboyKills( string[] selectedIndians, Cowboys cowboyToUpdate )
        {
            if ( selectedIndians == null )
            {
                cowboyToUpdate.Indians = new List<Indians>();
                return;
            }

            var selectedCowboysHS = new HashSet<string>( selectedIndians );
            var indianKills = new HashSet<int>
                ( cowboyToUpdate.Indians.Select( i => i.Id ) );
            foreach ( var indian in db.Indians )
            {
                if ( selectedCowboysHS.Contains( indian.Id.ToString() ) )
                {
                    if ( !indianKills.Contains( indian.Id ) )
                    {
                        cowboyToUpdate.Indians.Add( indian );
                    }
                }
                else
                {
                    if ( indianKills.Contains( indian.Id ) )
                    {
                        cowboyToUpdate.Indians.Remove( indian );
                    }
                }
            }
        }

        // GET: Cowboys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cowboys cowboys = db.Cowboys.Include( c => c.Indians ).Single( c => c.Id == id );
            if (cowboys == null)
            {
                return HttpNotFound();
            }

            return View(cowboys);
        }

        // GET: Cowboys/Create
        public ActionResult Create()
        {
            ViewBag.Killed = GetKills();

            return View();
        }

        // POST: Cowboys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cowboy_Name,Indians")] Cowboys cowboys, string[] selectedIndians)
        {
            if (ModelState.IsValid)
            {
                UpdateCowboyKills( selectedIndians, cowboys );
                db.Cowboys.Add(cowboys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedKillData( cowboys );
            return View(cowboys);
        }

        // GET: Cowboys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cowboys cowboys = db.Cowboys.Include( c => c.Indians ).Single( c => c.Id == id );
            PopulateAssignedKillData( cowboys );
            if (cowboys == null)
            {
                return HttpNotFound();
            }
            
            return View(cowboys);
        }

        // POST: Cowboys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cowboy_Name,Indians")] Cowboys cowboys, string[] selectedIndians)
        {
            if (ModelState.IsValid)
            {
                //var cowboy = db.Cowboys.Include( c => c.Indians ).Single( c => c.Id == cowboys.Id );
                db.Cowboys.Attach( cowboys );
                db.Entry( cowboys ).Collection( x => x.Indians ).Load();
                UpdateCowboyKills( selectedIndians, cowboys );

                db.Entry(cowboys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateAssignedKillData( cowboys );
            return View(cowboys);
        }

        // GET: Cowboys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cowboys cowboys = db.Cowboys.Include( c => c.Indians ).Single( c => c.Id == id );
            if (cowboys == null)
            {
                return HttpNotFound();
            }

            return View(cowboys);
        }

        // POST: Cowboys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cowboys cowboys = db.Cowboys.Include( c => c.Indians ).Single( c => c.Id == id );
            db.Cowboys.Remove(cowboys);
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
