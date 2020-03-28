using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class State
    {
        public DateTime DateOfState { get; set; }
        public int DayNumber { get; set; }
        public int TotalCases { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecoveries { get; set; }
        internal int NewDailyCases { get; set; }
        internal int NewDailyDeaths { get; set; }
    }
}
