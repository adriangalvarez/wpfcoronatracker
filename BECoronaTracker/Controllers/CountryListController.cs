using BECoronaTracker.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Controllers
{
    public static class CountryListController
    {
        public static BindableCollection<Country> LoadCountryList()
        {
            return DataAccess.CountryList.LoadCountryList();
        }
    }
}
