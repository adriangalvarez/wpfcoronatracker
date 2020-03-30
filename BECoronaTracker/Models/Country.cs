using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class Country
    {
        /// <summary>
        /// Country Code (two letters) used as parameter for querystring
        /// </summary>
        [DeserializeAs( Name = "alpha2Code" )]
        public string Code { get; set; }

        /// <summary>
        /// Name of the country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of updated data for each day
        /// </summary>
        public List<State> States { get; set; } = new List<State>();

        public int CurrentCases { get; set; }
        public int CurrentDeaths { get; set; }
        public int CurrentRecovered { get; set; }
        public DateTime DayOne { get; set; }
        public int CurrentDay { get; set; }

        public int Population { get; set; }

        /// <summary>
        /// Parameterless Constructor needed by RestSharp to get a list of countries from API
        /// </summary>
        public Country() { }
    }
}
