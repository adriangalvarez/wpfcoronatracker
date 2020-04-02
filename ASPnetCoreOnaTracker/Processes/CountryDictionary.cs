using System.Linq;

namespace ASPnetCoreOnaTracker.Processes
{
    public interface ICountryDictionary
    {
        string GetName( string countryCode );
    }

    public class CountryDictionary : ICountryDictionary
    {
        private readonly ICountryProcessor _countryProcessor;

        public CountryDictionary( ICountryProcessor countryProcessor )
        {
            _countryProcessor = countryProcessor;
        }

        public string GetName( string countryCode )
        {
            var countryList = _countryProcessor.GetCountries();
            return countryList.Where( 
                    ( country ) => country.CountryCode == countryCode 
                )
                .First()
                .Name;
        }
    }
}
