using ASPnetCoreOnaTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetCoreOnaTracker.Processes
{
    internal static class ContryProcesses
    {
        internal static List<Country> GetCountries()
        {
            var countries = new List<Country>();
            
            var beCountries = BECoronaTracker.Controllers.CountryListController.GetCountries();
            BECoronaTracker.Models.CountryDataModel.MatchData( BECoronaTracker.Controllers.CountryDataController.GetFullData(), beCountries );
            foreach ( var beCountry in beCountries )
            {
                var country = new Country();
                country.Name = beCountry.Name;
                country.Population = beCountry.Population;
                country.CurrentCases = beCountry.CurrentCases;
                country.CurrentDeaths = beCountry.CurrentDeaths;
                country.CurrentRecovered = beCountry.CurrentRecovered;
                country.DayOne = beCountry.DayOne;
                country.CurrentDay = beCountry.CurrentDay;
                countries.Add( country );
            }

            return countries;
        }
    }
}
