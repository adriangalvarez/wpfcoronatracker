using BECoronaTracker.Models;
using System.Linq;

namespace BECoronaTracker.Controllers
{
    public static class CountryDataController
    {
        public static EachDataModel[] CountryTimeline { get; set ; }

        public static EachDataModel[] GetFullData()
        {
            AllDataModel result = Newtonsoft.Json.JsonConvert.DeserializeObject<AllDataModel>( DataAccess.CountryData.GetAllData() );
            CountryTimeline = result.data;
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
