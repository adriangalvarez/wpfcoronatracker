using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaTracker.Models
{
    public class CountryList
    {
        public static BindableCollection<Country> LoadCountryList()
        {
            BindableCollection<Country> countries = new BindableCollection<Country>();
            string line = string.Empty;

            try
            {
                string countryListFile = "files/CountryCodesForCorona.txt";
                string rootPath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().CodeBase );
                string fullPath = Path.Combine( rootPath, countryListFile );
                string filePath = new Uri( fullPath ).LocalPath;

                using ( StreamReader reader = new StreamReader( new FileStream( filePath, FileMode.Open, FileAccess.Read ) ) )
                {
                    while ( ( line = reader.ReadLine() ) != null )
                    {
                        string[] infoCountry = line.Split( ':' );
                        Country country = new Country( infoCountry[ 0 ], infoCountry[ 1 ] );
                        countries.Add( country );
                    }
                }

            } catch ( Exception ex )
            {
                throw ex;
            }

            return countries;
        }
    }
}
