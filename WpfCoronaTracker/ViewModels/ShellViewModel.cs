using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BECoronaTracker.Models;
using BECoronaTracker.DataAccess;

namespace WpfCoronaTracker.ViewModels
{
    public class ShellViewModel : Screen
    {
        private Country _selectedCountry;
        public BindableCollection<Country> Countries { get; set; }

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set {
                _selectedCountry = value;
                NotifyOfPropertyChange( () => SelectedCountry );
            }
        }

        public ShellViewModel()
        {
            Countries = CountryList.LoadCountryList();
        }

        public void LoadDataForCountry()
        {

        }
    }
}
