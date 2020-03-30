using System.Collections.Generic;
using System.Linq;

namespace BECoronaTracker.Models
{
    public static class CountryDataModel
    {
        /// <summary>
        /// Populates the list of countries with current status
        /// and removes countries without data from the list.
        /// </summary>
        /// <param name="allData">All countries' timeline.</param>
        /// <param name="countries">List of all countries.</param>
        public static void MatchData( List<EachDataModel> allData, List<Country> countries )
        {
            List<Country> countriesWithoutData = new List<Country>();

            // Go through all data, filtering out dates without cases
            foreach ( var country in countries )
            {
                var results = from each in allData
                              where each.Countrycode == country.Code
                                && each.Cases > 0
                              orderby each.Date
                              select each;

                // If there is at least one day with a case,
                // populate the current status with data from the last day.
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

            // Removes all countries without data from list of countries.
            foreach ( var country in countriesWithoutData )
            {
                countries.Remove( country );
            }
        }
    }
}
