using ASPnetCoreOnaTracker.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ASPnetCoreOnaTracker.Processes
{
    public interface ICountryProcessor
    {
        List<Country> GetCountries();
    }

    public class CountryProcesses : ICountryProcessor
    {
        private readonly IMemoryCache _cache;
        private static List<Country> countries;

        public CountryProcesses( IMemoryCache memoryCache )
        {
            _cache = memoryCache;
        }

        public List<Country> GetCountries()
        {
            TryGetDataFromCache();
            return countries;
        }

        private void TryGetDataFromCache()
        {
            List<Country> cacheEntry;

            // Seek "Countries" in cache.
            if ( !_cache.TryGetValue( "Countries", out cacheEntry ) )
            {
                // Not found, then get full list of countries with full timeline from server.
                cacheEntry = FetchDataFromServer();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Go to the server after 2 hours.
                    .SetAbsoluteExpiration( TimeSpan.FromHours( 2 ) );

                // Save data in cache.
                _cache.Set( "Countries", cacheEntry, cacheEntryOptions );
            }

            countries = cacheEntry;
        }

        private static List<Country> FetchDataFromServer()
        {
            countries = new List<Country>();

            var beCountries = BECoronaTracker.Controllers.CountryListController.GetCountries();
            var fulldata = BECoronaTracker.Controllers.CountryDataController.GetFullData();
            BECoronaTracker.Models.CountryDataModel.MatchData( fulldata, beCountries );
            foreach ( var beCountry in beCountries )
            {
                var country = new Country();
                country.CountryCode = beCountry.Code;
                country.Name = beCountry.Name;
                country.Population = beCountry.Population;
                country.CurrentCases = beCountry.CurrentCases;
                country.CurrentDeaths = beCountry.CurrentDeaths;
                country.CurrentRecovered = beCountry.CurrentRecovered;
                country.DayOne = beCountry.DayOne;
                country.CurrentDay = beCountry.CurrentDay;
                country.States = beCountry.States;
                countries.Add( country );
            }

            return countries;
        }
    }
}
