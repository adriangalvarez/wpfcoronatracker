namespace BECoronaTracker.DataAccess
{
    internal static class CountryData
    {
        internal static string baseUrl = "https://thevirustracker.com/timeline/map-data.json";

        internal static string AllData { get; set; }

        //internal static List<Models.State> GetData( string countryCode )
        //{
        //    var client = new RestSharp.RestClient( "https://thevirustracker.com/free-api" );
        //    var countryParam = new RestSharp.Parameter( "countryTimeline", countryCode, RestSharp.ParameterType.QueryString );
        //    var response = client.Execute<List<Models.State>>( new RestSharp.RestRequest().AddParameter( countryParam ) );

        //    return null;
        //}

        internal static string GetAllData()
        {
            if ( string.IsNullOrWhiteSpace(AllData) )
            {
                var client = new RestSharp.RestClient( baseUrl );
                AllData = client.Execute( new RestSharp.RestRequest( RestSharp.Method.GET ) ).Content;
            }
            return AllData;
        }
    }
}
