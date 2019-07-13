using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenieAir.Models;

namespace GreenieAir.Models
{
    public class CountryModel
    {
        public List<State> StateModel { get; set; }
        public SelectList FilteredCity { get; set; }
    }
}