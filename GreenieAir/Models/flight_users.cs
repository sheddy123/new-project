using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.Models
{
    public class flight_users
    {
        public int Id { get; set; }
        [Display(Name = "UsersId")]
        public string UsersId { get; set; }
       
    }
}