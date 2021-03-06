﻿using BECoronaTracker.Models;

namespace BECoronaTracker.DataAccess
{
    internal static class CountryData
    {
        /// <summary>
        /// API for full timeline endpoint.
        /// </summary>
        internal static string fullDataUrl = "https://thevirustracker.com/timeline/map-data.json";

        /// <summary>
        /// Property holding full timeline.
        /// </summary>
        internal static AllDataModel AllData { get; set; }

        /// <summary>
        /// Get full timeline through API.
        /// </summary>
        /// <returns>Full timeline.</returns>
        internal static AllDataModel GetAllData()
        {
            if ( AllData == null )
            {
                var client = new RestSharp.RestClient( fullDataUrl );
                var json = client.Execute( new RestSharp.RestRequest( RestSharp.Method.GET ) ).Content.Replace("\": \"\"", "\": \"0\"");
                
                AllData = Newtonsoft.Json.JsonConvert.DeserializeObject<AllDataModel>( json );
            }
            return AllData;
        }
    }
}
