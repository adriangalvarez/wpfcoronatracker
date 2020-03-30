using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class EachDataModel
    {
        public string Countrycode { get; set; }
        public DateTime Date { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
