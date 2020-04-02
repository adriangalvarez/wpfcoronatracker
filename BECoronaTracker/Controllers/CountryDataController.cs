using BECoronaTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BECoronaTracker.Controllers
{
    public static class CountryDataController
    {
        /// <summary>
        /// Property holding the complete timeline of all countries.
        /// </summary>
        internal static List<EachDataModel> CountryTimeline { get; set ; }

        /// <summary>
        /// Gets the timeline for all countries.
        /// </summary>
        /// <returns></returns>
        public static List<EachDataModel> GetFullData()
        {
            AllDataModel result = DataAccess.CountryData.GetAllData();
            CountryTimeline = result.Data;
            return CountryTimeline;
        }

        /// <summary>
        /// Populates country's States property with the data corresponding to each date,
        /// removing dates before Day 1, and counting each day.
        /// </summary>
        /// <param name="country"></param>
        public static void GetData( Country country )
        {
            // Filter out dates without cases and order by date.
            var result = from day in CountryTimeline
                    where day.Countrycode == country.Code
                        && day.Cases > 0
                    orderby day.Date
                    select day;

            var dayNumber = 0;

            // Go through all remaining dates and fill country's State list.
            foreach ( EachDataModel day in result )
            {
                country.States.Add(
                    new State
                    {
                        DateOfState = day.Date,
                        DayNumber = ++dayNumber,
                        TotalCases = day.Cases,
                        TotalDeaths = day.Deaths,
                        TotalRecoveries = day.Recovered
                    }
                );
            }
        }
    }
}
