using Caliburn.Micro;
using System.Collections.Generic;
using BECoronaTracker.Controllers;
using BECoronaTracker.Models;

namespace WpfCoronaTracker.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Country _selectedCountry;

        /// <summary>
        /// List of all countries with data.
        /// </summary>
        public List<Country> Countries { get; set; }

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set {
                _selectedCountry = value;
                NotifyOfPropertyChange( () => SelectedCountry );
                LoadDataForCountry();
            }
        }

        public ShellViewModel()
        {
            // Get a list of all countries.
            Countries = CountryListController.GetCountries();

            // Fill data for each country.
            CountryDataModel.MatchData( CountryDataController.GetFullData(), Countries );
        }

        public void LoadDataForCountry()
        {
            if ( SelectedCountry != null )
            {
                ActivateItem( new CountryDataViewModel( SelectedCountry ) );
            }
        }
    }
}
