using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPnetCoreOnaTracker.Models;
using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ASPnetCoreOnaTracker.Controllers
{
    public class ChartController : Controller
    {
        /// <summary>
        /// Injected service to get country name by code from cache.
        /// </summary>
        private Processes.ICountryDictionary _countryDictionary;

        public ChartController( Processes.ICountryDictionary countryDictionary )
        {
            _countryDictionary = countryDictionary;
        }

        /// <summary>
        /// Default action, getting the country code as id parameter, by which the name will be fetched.
        /// </summary>
        /// <param name="id">Country code to make the chart.</param>
        /// <returns></returns>
        public IActionResult Index(string id)
        {
            ViewData[ "id" ] = id;
            ViewData[ "countryName" ] = _countryDictionary.GetName( id );
            return View();
        }

        /// <summary>
        /// Function called by Google charts to get the country data.
        /// </summary>
        /// <param name="countryCode">Country code to get the data about.</param>
        /// <returns>Json containing the country timeline to be drawn in the data.</returns>
        public IActionResult GetChartData( string countryCode )
        {
            var country = new BECoronaTracker.Models.Country();
            country.Code = countryCode;

            BECoronaTracker.Controllers.CountryDataController.GetData( country );

            return Json( country.States );
        }
    }
}