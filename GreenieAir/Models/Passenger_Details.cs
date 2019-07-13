using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.Models
{
    public class Passenger_Details
    {
        public int Id { get; set; }
        
        public string UsersId { get; set; }
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }
        [Display(Name = "Age")]
        public int Adult_aAge { get; set; }

        [Display(Name = "Name")]
        public string childName { get; set; }

        [Display(Name = "Age")]
        public string child_age { get; set; }

        [Display(Name = "Sex")]
        public Gender childSex { get; set; }
        public Gender adultSex { get; set; }
        public enum Gender
        {
            Male,
            Female
        }

        //[Display(Name = "Sex")]
        //public Gender Sex { get; set; }
        //public enum Gender
        //{
        //    Male,
        //    Female,
        //}
        public ICollection<flight_search> Flight_SearchesNo { get; set; }
        public flight_search Flight_Search { get; set; }
        
        [Display(Name = "Departure Date")]
        public DateTime? PassengerDepartureDate { get; set; }
        
        [Display(Name = "Arrival Date")]
        public DateTime? PassengerArrivalDate { get; set; }
        [Display(Name = "Status")]
        public string PassengerStatus { get; set; }
        [Display(Name = "Class")]
        public PassengerClass Passenger_Class { get; set; }
        [Display(Name = "Type")]
        public PassengerType Passenger_Type { get; set; }

        public enum PassengerType
        {
            A,
            B, C, D
        }
        public enum PassengerClass
        {
            Economy,
            Business,
        }
    }
}