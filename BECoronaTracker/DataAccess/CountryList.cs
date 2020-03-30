using BECoronaTracker.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BECoronaTracker.DataAccess
{
    internal class CountryList
    {
        internal static List<Country> GetAllCountries()
        {
            var client = new RestSharp.RestClient( "https://restcountries.eu/rest/v2/all" );
            var allCountriesParam = new RestSharp.Parameter( "fields", "name;population;alpha2Code", RestSharp.ParameterType.QueryString );
            var response = client.Execute<List<Country>>( new RestSharp.RestRequest().AddParameter( allCountriesParam ) );

            return response.Data;
        }
    }
}
