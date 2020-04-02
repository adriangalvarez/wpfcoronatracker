using BECoronaTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetCoreOnaTracker.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }

        [Display( Name = "Cases" )]
        public int CurrentCases { get; set; }

        [Display( Name = "Deaths" )]
        public int CurrentDeaths { get; set; }

        [Display( Name = "Recovered" )]
        public int CurrentRecovered { get; set; }

        /// <summary>
        /// First day with a case.
        /// </summary>
        [DisplayFormat( DataFormatString = "{0:d}" )]
        [Display( Name = "Day 1" )]
        public DateTime DayOne { get; set; }

        // Number of days since the first day with a case.
        [Display( Name = "Day Nr" )]
        public int CurrentDay { get; set; }

        [DisplayFormat( DataFormatString = "{0:n0}" )]
        public int Population { get; set; }

        public List<State> States { get; set; } = new List<State>();
    }
}
