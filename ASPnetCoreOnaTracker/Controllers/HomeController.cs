using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPnetCoreOnaTracker.Models;

namespace ASPnetCoreOnaTracker.Controllers
{
    public class HomeController : Controller
    {
        private Processes.ICountryProcessor _countryProcessor;

        public HomeController( Processes.ICountryProcessor countryProcessor )
        {
            _countryProcessor = countryProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CountryListSummary()
        {
            ViewData[ "Countries" ] = _countryProcessor.GetCountries();
            return View();
        }

        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error()
        {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}
