using BECoronaTracker.Models;
using System.Linq;

namespace BECoronaTracker.Controllers
{
    public static class CountryDataController
    {
        public static EachDataModel[] countryTimeline;

        public static void GetFullData()
        {
            AllDataModel result = Newtonsoft.Json.JsonConvert.DeserializeObject<AllDataModel>( DataAccess.CountryData.GetAllData() );
            countryTimeline = result.data;
        }

        public static void GetData( Country country )
        {
            var result = from day in countryTimeline
                    where day.countrycode == country.Code
                        && day.cases > 0
                    orderby day.date
                    select day;

            var dayNumber = 0;

            foreach ( EachDataModel day in result )
            {
                country.States.Add(
                    new State
                    {
                        DateOfState = day.date,
                        DayNumber = ++dayNumber,
                        TotalCases = day.cases,
                        TotalDeaths = day.deaths,
                        TotalRecoveries = day.recovered
                    }
                );
            }

            country.CurrentCases = country.States.Max( value => value.TotalCases );
            country.CurrentDeaths = country.States.Max( value => value.TotalDeaths );
            country.CurrentRecovered = country.States.Max( value => value.TotalRecoveries );
            country.CurrentDay = dayNumber;
            country.DayOne = System.DateTime.Now.AddDays( ( -1 ) * dayNumber );
        }
    }
}
