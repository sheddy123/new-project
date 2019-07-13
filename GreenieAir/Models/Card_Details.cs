using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.Models
{
    public class Card_Details
    {
        public int Id { get; set; }
        [Display(Name = "Card Name")]
        public string CardName { get; set; }

        public string UserId { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Display(Name = "cvv")]
        public string c_cvv { get; set; }

        [Display(Name = "Card Number")]
        public string CardNum { get; set; }

        [Display(Name = "Card Balanace")]
        public string CardBalance { get; set; }



    }
}