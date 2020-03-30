using BECoronaTracker.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Controllers
{
    public static class CountryListController
    {
        public static List<Country> GetCountries()
        {
            return DataAccess.CountryList.GetAllCountries();
        }
    }
}
