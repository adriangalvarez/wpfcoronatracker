using BECoronaTracker.Models;

namespace BECoronaTracker.DataAccess
{
    internal static class CountryData
    {
        internal static string fullDataUrl = "https://thevirustracker.com/timeline/map-data.json";

        internal static AllDataModel AllData { get; set; }

        internal static AllDataModel GetAllData()
        {
            if ( AllData == null )
            {
                var client = new RestSharp.RestClient( fullDataUrl );
                AllData = client.Execute<AllDataModel>( new RestSharp.RestRequest( RestSharp.Method.GET ) ).Data;
            }
            return AllData;
        }
    }
}
