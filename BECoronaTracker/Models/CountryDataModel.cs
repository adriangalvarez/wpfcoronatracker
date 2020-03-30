using System.Collections.Generic;
using System.Linq;

namespace BECoronaTracker.Models
{
    public static class CountryDataModel
    {
        public static void MatchData( List<EachDataModel> allData, List<Country> countries )
        {
            List<Country> countriesWithoutData = new List<Country>();

            foreach ( var country in countries )
            {
                var results = from each in allData
                              where each.Countrycode == country.Code
                                && each.Cases > 0
                              orderby each.Date
                              select each;

                if ( results.Any() )
                {
                    country.CurrentCases = results.Last().Cases;
                    country.CurrentDeaths = results.Last().Deaths;
                    country.CurrentRecovered = results.Last().Recovered;
                    country.DayOne = results.First().Date;
                    country.CurrentDay = (int) ( results.Last().Date - results.First().Date ).TotalDays;
                } else
                {
                    countriesWithoutData.Add(country);
                }
            }

            foreach ( var country in countriesWithoutData )
            {
                countries.Remove( country );
            }
        }
    }
}
