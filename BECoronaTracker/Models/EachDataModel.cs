using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class EachDataModel
    {
        /// <summary>
        /// ISO 3166 country code.
        /// </summary>
        public string Countrycode { get; set; }

        /// <summary>
        /// Day for the data.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Total cases at that date.
        /// </summary>
        public int Cases { get; set; }

        /// <summary>
        /// Total deaths at that date.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// Total recovered at that date.
        /// </summary>
        public int Recovered { get; set; }
    }
}
