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
        private Processes.ICountryDictionary _countryDictionary;

        public ChartController( Processes.ICountryDictionary countryDictionary )
        {
            _countryDictionary = countryDictionary;
        }

        public IActionResult Index(string id)
        {
            ViewData[ "id" ] = id;
            ViewData[ "countryName" ] = _countryDictionary.GetName( id );
            return View();
        }

        public IActionResult GetChartData( string countryCode )
        {
            var country = new BECoronaTracker.Models.Country();
            country.Code = countryCode;

            BECoronaTracker.Controllers.CountryDataController.GetData( country );

            return Json( country.States );
        }
    }
}