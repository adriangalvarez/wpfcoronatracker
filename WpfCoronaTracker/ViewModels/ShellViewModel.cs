using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BECoronaTracker.Controllers;
using BECoronaTracker.Models;

namespace WpfCoronaTracker.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private Country _selectedCountry;
        public AllDataModel AllData { get; set; }
        public BindableCollection<Country> Countries { get; set; }

        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set {
                _selectedCountry = value;
                NotifyOfPropertyChange( () => SelectedCountry );
                LoadDataForCountry();

                NotifyOfPropertyChange( () => TotalCasesTitleIsVisible );
                NotifyOfPropertyChange( () => TotalRecoveredTitleIsVisible );
                NotifyOfPropertyChange( () => TotalDeathsTitleIsVisible );
                NotifyOfPropertyChange( () => CurrentDayTitleIsVisible );
                NotifyOfPropertyChange( () => DayOneTitleIsVisible );

                NotifyOfPropertyChange( () => TotalCasesIsVisible );
                NotifyOfPropertyChange( () => TotalRecoveredIsVisible );
                NotifyOfPropertyChange( () => TotalDeathsIsVisible );
                NotifyOfPropertyChange( () => CurrentDayIsVisible );
                NotifyOfPropertyChange( () => DayOneIsVisible );

                NotifyOfPropertyChange( () => TotalCases );
                NotifyOfPropertyChange( () => TotalRecovered );
                NotifyOfPropertyChange( () => TotalDeaths );
                NotifyOfPropertyChange( () => CurrentDay );
                NotifyOfPropertyChange( () => DayOne );
            }
        }

        public bool TotalCasesTitleIsVisible { get; set; }
        public bool TotalRecoveredTitleIsVisible { get; set; }
        public bool TotalDeathsTitleIsVisible { get; set; }

        public int TotalCases { get; set; }
        public int TotalRecovered { get; set; }
        public int TotalDeaths { get; set; }
        public bool TotalCasesIsVisible { get; set; }
        public bool TotalRecoveredIsVisible { get; set; }
        public bool TotalDeathsIsVisible { get; set; }

        public int CurrentDay { get; set; }
        public DateTime DayOne { get; set; }

        public bool CurrentDayTitleIsVisible { get; set; }
        public bool CurrentDayIsVisible { get; set; }
        public bool DayOneTitleIsVisible { get; set; }
        public bool DayOneIsVisible { get; set; }

        public ShellViewModel()
        {
            Countries = CountryListController.LoadCountryList();
            CountryDataController.GetFullData();
        }

        public void LoadDataForCountry()
        {
            if ( SelectedCountry != null )
            {
                TotalCasesIsVisible = TotalRecoveredIsVisible = TotalDeathsIsVisible =
                    CurrentDayIsVisible = DayOneIsVisible =
                    TotalCasesTitleIsVisible = TotalRecoveredTitleIsVisible = TotalDeathsTitleIsVisible = 
                    CurrentDayTitleIsVisible = DayOneTitleIsVisible = true;
                
                CountryDataViewModel currentCountryVM = new CountryDataViewModel( SelectedCountry );
                
                TotalCases = currentCountryVM.Country.CurrentCases;
                TotalDeaths = currentCountryVM.Country.CurrentDeaths;
                TotalRecovered = currentCountryVM.Country.CurrentRecovered;
                CurrentDay = currentCountryVM.Country.CurrentDay;
                DayOne = currentCountryVM.Country.DayOne;

                ActivateItem( currentCountryVM );
            } else
                TotalCasesIsVisible = TotalRecoveredIsVisible = TotalDeathsIsVisible =
                    CurrentDayIsVisible = DayOneIsVisible =
                    TotalCasesTitleIsVisible = TotalRecoveredTitleIsVisible = TotalDeathsTitleIsVisible =
                    CurrentDayTitleIsVisible = DayOneTitleIsVisible = false;
        }
    }
}
