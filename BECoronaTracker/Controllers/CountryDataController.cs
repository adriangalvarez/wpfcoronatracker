using BECoronaTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace BECoronaTracker.Controllers
{
    public static class CountryDataController
    {
        public static List<EachDataModel> CountryTimeline { get; set ; }

        public static List<EachDataModel> GetFullData()
        {
            AllDataModel result = DataAccess.CountryData.GetAllData();
            CountryTimeline = result.Data;
            return CountryTimeline;
        }

        public static void GetData( Country country )
        {
            var result = from day in CountryTimeline
                    where day.Countrycode == country.Code
                        && day.Cases > 0
                    orderby day.Date
                    select day;

            var dayNumber = 0;

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
