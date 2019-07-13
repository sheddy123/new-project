using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenieAir.Models;

namespace GreenieAir.Controllers
{
    public class flight_searchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: flight_search
        public ActionResult Index()
        {
            var flightSearchs = db.FlightSearchs.Include(f => f.States);
            return View(flightSearchs.ToList());
        }

        // GET: flight_search/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight_search flight_search = db.FlightSearchs.Find(id);
            if (flight_search == null)
            {
                return HttpNotFound();
            }
            return View(flight_search);
        }

        // GET: flight_search/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", "");
            return View();
        }

        // POST: flight_search/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FlightNo,From_City,To_City,DepartureDate,ArrivalDate,DepartureTime,ArrivalTime,SeatsLeft,e_price,b_price,Passenger_DetailsID")] flight_search flight_search)
        {
            if (ModelState.IsValid)
            {
                db.FlightSearchs.Add(flight_search);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", flight_search.StateId);
            return View(flight_search);
        }

        // GET: flight_search/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight_search flight_search = db.FlightSearchs.Find(id);
            if (flight_search == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", flight_search.StateId);
            return View(flight_search);
        }

        // POST: flight_search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FlightNo,From_City,To_City,DepartureDate,ArrivalDate,DepartureTime,ArrivalTime,SeatsLeft,e_price,b_price,Passenger_DetailsID")] flight_search flight_search)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight_search).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", flight_search.StateId);
            return View(flight_search);
        }

        // GET: flight_search/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flight_search flight_search = db.FlightSearchs.Find(id);
            if (flight_search == null)
            {
                return HttpNotFound();
            }
            return View(flight_search);
        }

        // POST: flight_search/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            flight_search flight_search = db.FlightSearchs.Find(id);
            db.FlightSearchs.Remove(flight_search);
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
