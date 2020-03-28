using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class Country {
        /// <summary>
        /// Country Code (two letters) used as parameter for querystring
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of updated data for each day
        /// </summary>
        public List<State> States { get; set; }

        public int CurrentCases { get; set; }
        public int CurrentDeaths { get; set; }
        public int CurrentRecovered { get; set; }
        public DateTime DayOne { get; set; }
        public int CurrentDay { get; set; }

        internal Country( string code, string name )
        {
            Code = code;
            Name = name;
            States = new List<State>();
        }
    }
}
