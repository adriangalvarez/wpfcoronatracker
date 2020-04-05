using System.Linq;

namespace ASPnetCoreOnaTracker.Processes
{
    /// <summary>
    /// Interface to be injected.
    /// </summary>
    public interface ICountryDictionary
    {
        string GetName( string countryCode );
    }

    /// <summary>
    /// Class instantiated by the framework when the interface is injected.
    /// It is responsible for filtering out the full country list and grab
    /// the country name of the sent country code.
    /// </summary>
    public class CountryDictionary : ICountryDictionary
    {
        private readonly ICountryProcessor _countryProcessor;

        public CountryDictionary( ICountryProcessor countryProcessor )
        {
            _countryProcessor = countryProcessor;
        }

        /// <summary>
        /// Get the contry name corresponding to the country code.
        /// </summary>
        /// <param name="countryCode">Country code to seek the name of.</param>
        /// <returns>Country name corresponding to the country code.</returns>
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
