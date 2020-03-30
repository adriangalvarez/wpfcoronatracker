using BECoronaTracker.Models;

namespace BECoronaTracker.DataAccess
{
    internal static class CountryData
    {
        internal static string fullDataUrl = "https://thevirustracker.com/timeline/map-data.json";

        internal static string AllData { get; set; }

        internal static string GetAllData()
        {
            if ( string.IsNullOrWhiteSpace(AllData) )
            {
                var client = new RestSharp.RestClient( fullDataUrl );
                AllData = client.Execute( new RestSharp.RestRequest( RestSharp.Method.GET ) ).Content;
            }
            return AllData;
        }
    }
}
