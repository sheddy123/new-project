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
    public class booking_detailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: booking_details
        public ActionResult Index()
        {
            var booking_Details = db.Booking_Details.Include(b => b.Card_Details).Include(b => b.flight_Search);
            return View(booking_Details.ToList());
        }

        // GET: booking_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_details booking_details = db.Booking_Details.Find(id);
            if (booking_details == null)
            {
                return HttpNotFound();
            }
            return View(booking_details);
        }

        // GET: booking_details/Create
        public ActionResult Create()
        {
            ViewBag.Card_DetailsID = new SelectList(db.CardDetails, "Id", "CardName");
            ViewBag.flight_SearchId = new SelectList(db.FlightSearchs, "Id", "FlightNo");
            return View();
        }

        // POST: booking_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsersId,flight_SearchId,booking_Child,booking_Adults,booking_total,booking_status,Card_DetailsID")] booking_details booking_details)
        {
            if (ModelState.IsValid)
            {
                db.Booking_Details.Add(booking_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Card_DetailsID = new SelectList(db.CardDetails, "Id", "CardName", booking_details.Card_DetailsID);
            ViewBag.flight_SearchId = new SelectList(db.FlightSearchs, "Id", "FlightNo", booking_details.flight_SearchId);
            return View(booking_details);
        }

        // GET: booking_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_details booking_details = db.Booking_Details.Find(id);
            if (booking_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Card_DetailsID = new SelectList(db.CardDetails, "Id", "CardName", booking_details.Card_DetailsID);
            ViewBag.flight_SearchId = new SelectList(db.FlightSearchs, "Id", "FlightNo", booking_details.flight_SearchId);
            return View(booking_details);
        }

        // POST: booking_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsersId,flight_SearchId,booking_Child,booking_Adults,booking_total,booking_status,Card_DetailsID")] booking_details booking_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Card_DetailsID = new SelectList(db.CardDetails, "Id", "CardName", booking_details.Card_DetailsID);
            ViewBag.flight_SearchId = new SelectList(db.FlightSearchs, "Id", "FlightNo", booking_details.flight_SearchId);
            return View(booking_details);
        }

        // GET: booking_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking_details booking_details = db.Booking_Details.Find(id);
            if (booking_details == null)
            {
                return HttpNotFound();
            }
            return View(booking_details);
        }

        // POST: booking_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking_details booking_details = db.Booking_Details.Find(id);
            db.Booking_Details.Remove(booking_details);
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
