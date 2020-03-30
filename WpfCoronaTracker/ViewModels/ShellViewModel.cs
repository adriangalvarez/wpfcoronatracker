using Caliburn.Micro;
using System.Collections.Generic;
using BECoronaTracker.Controllers;
using BECoronaTracker.Models;

namespace WpfCoronaTracker.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Country _selectedCountry;
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
            Countries = CountryListController.GetCountries();
            Models.CountryDataModel.MatchData( CountryDataController.GetFullData(), Countries );
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
