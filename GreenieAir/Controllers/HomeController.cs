using GreenieAir.Models;
using GreenieAir.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenieAir.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ApplicationUser CurrentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(
      System.Web.HttpContext.Current.User.Identity.GetUserId());
        public ActionResult Index()
        {
            ViewBag.Message = TempData["info"];
            ViewBag.Flights = TempData["flights"];
            if (ViewBag.Message == null && ViewBag.Flights == null)
            {
                ViewBag.NoFlights = "No Flights available";
            }
            else if(ViewBag.Message.Count == 0 || ViewBag.Flights.Count > 0)
            {
                ViewBag.NoFlights = "No Flights available" + TempData["City"];
            }
            else if (ViewBag.Message.Count == 0 && ViewBag.Flights.Count == 0)
            {
                ViewBag.NoFlights = "No Flights available";
            }
            return View();
        }

        public ActionResult FlightDetails(flight_search search, booking_details booking_Details, string chk)
        {
            if (chk == "one way" || chk == null)
            {
                var Specificflights = db.FlightSearchs.Where(x => x.From_City.Equals(search.From_City) && x.To_City.Equals(search.To_City)).ToList();
                TempData["info"] = Specificflights;
                TempData["City"] = " from " + search.From_City + " to " + search.To_City;

                var flights = db.FlightSearchs.Where(x => x.From_City.Equals(search.From_City)).ToList();
                TempData["flights"] = flights;
            }
            else if(chk =="round trip")
            {
                var Specificflights = db.FlightSearchs.Where(x => x.From_City.Equals(search.From_City) && x.To_City.Equals(search.To_City)).ToList();
                TempData["info"] = Specificflights;
                TempData["City"] = " from " + search.From_City + " to " + search.To_City;

                var flights = db.FlightSearchs.Where(x => x.From_City.Equals(search.From_City)).ToList();
                TempData["flights"] = flights;
                var returnFlights = db.FlightSearchs.Where(x => x.From_City.Equals(search.To_City) && x.To_City.Equals(search.From_City)).FirstOrDefault();                
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PassengerBook(booking_details booking_Details, string selectedFlight)
        {
            if (Request.IsAuthenticated)
            {
                string selec = selectedFlight.ToString();

                var selectedFlights = db.FlightSearchs.Where(x => x.FlightNo.Equals(selectedFlight)).FirstOrDefault();
                TempData["Flights"] = "Your flight from " + selectedFlights.From_City + " to " + selectedFlights.To_City;

                var passengerDetails = db.PassngerDetails.Where(x => x.UsersId.Equals(CurrentUser.Id)).Select(c => c.UsersId).FirstOrDefault();

                var passDetails = db.Users.Find(passengerDetails);

                var model = new UserViewModel
                {
                    FirstName = passDetails.FirstName,
                    LastName = passDetails.LastName,
                    Phone = passDetails.Phone,
                    Address = passDetails.Address,
                    Email = passDetails.Email,

                };

                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PassengerBook(string[] selectedFlight)
        {
            if (Request.IsAuthenticated)
            {

            }
            else
            {
                RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}