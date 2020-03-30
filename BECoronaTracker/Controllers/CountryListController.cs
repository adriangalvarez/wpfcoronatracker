using BECoronaTracker.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Controllers
{
    public static class CountryListController
    {
        /// <summary>
        /// Get a list of all countries with name, population and ISO code.
        /// </summary>
        /// <returns></returns>
        public static List<Country> GetCountries()
        {
            return DataAccess.CountryList.GetAllCountries();
        }
    }
}
