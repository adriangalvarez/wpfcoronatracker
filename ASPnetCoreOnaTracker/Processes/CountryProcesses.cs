using ASPnetCoreOnaTracker.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ASPnetCoreOnaTracker.Processes
{
    /// <summary>
    /// Interface to be injected.
    /// </summary>
    public interface ICountryProcessor
    {
        List<Country> GetCountries();
    }

    /// <summary>
    /// Class instantiated by the framework, so the IMemoryCache object can be injected
    /// and the full timeline of all countries can be saved in the cache, and afterwards
    /// got from there, only going to the server every 2 hours.
    /// </summary>
    public class CountryProcesses : ICountryProcessor
    {
        private readonly IMemoryCache _cache;
        private static List<Country> countries;

        public CountryProcesses( IMemoryCache memoryCache )
        {
            _cache = memoryCache;
        }

        /// <summary>
        /// Get full timeline of all countries.
        /// </summary>
        /// <returns>Full timeline of all countries.</returns>
        public List<Country> GetCountries()
        {
            // Try to get the data from the cache, if not found, look for it in the server.
            TryGetDataFromCache();
            return countries;
        }

        /// <summary>
        /// Get full timeline from cache.  If not found, fetch from server and map to the web model.
        /// </summary>
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

        /// <summary>
        /// Fetch full timeline for all countries.
        /// </summary>
        /// <returns>Full timeline for all countries.</returns>
        private static List<Country> FetchDataFromServer()
        {
            countries = new List<Country>();

            // Get the country list with ISO code, name and population.
            var beCountries = BECoronaTracker.Controllers.CountryListController.GetCountries();

            // Get full timeline of all countries.
            var fulldata = BECoronaTracker.Controllers.CountryDataController.GetFullData();

            // Match the full country list with the full timeline, filling the State property
            // of each country with its timeline, and setting the current state.
            BECoronaTracker.Models.CountryDataModel.MatchData( fulldata, beCountries );

            // Map each country returned from the BE project to the web model.
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
