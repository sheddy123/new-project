using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.Models
{
    public class flight_search
    {
        public int Id { get; set; }
        [Display(Name = "Flight No")]
        public string FlightNo { get; set; }
        [Display(Name = "From City")]
        public string From_City { get; set; }
        public int? StateId { get; set; }
        public State States { get; set; }
        [Display(Name = "To City")]
        public string To_City { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:tt}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:tt}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Seats Left")]
        public int SeatsLeft { get; set; }
        [Display(Name = "e Price")]
        public int e_price { get; set; }
        [Display(Name = "b Price")]
        public int b_price { get; set; }
        public int Passenger_DetailsID { get; set; }
        public Passenger_Details PassengerDet { get; set; }
    }
}