using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.Models
{
    public class booking_details
    {
        public int Id { get; set; }
        [Display(Name = "UsersId")]
        public string UsersId { get; set; }
        public int? flight_SearchId { get; set; }
        public flight_search flight_Search { get; set; }
        [Display(Name = "Booking Child")]
        public int? booking_Child { get; set; }
        [Display(Name = "Booking Adults")]
        public int? booking_Adults { get; set; }
        [Display(Name = "Booking Total")]
        public string booking_total { get; set; }
        [Display(Name = "Booking Status")]
        public string booking_status { get; set; }
        
        public int Card_DetailsID { get; set; }
        public Card_Details Card_Details { get; set; }
    }
}