using Caliburn.Micro;
using BECoronaTracker.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using System.ComponentModel;
using System;
using LiveCharts.Wpf;

namespace WpfCoronaTracker.ViewModels
{
    public class CountryDataViewModel : Conductor<object>
    {
        private double _from;
        private double _to;
        private bool _paginate;

        public ChartValues<State> Results { get; set; }
        public object Mapper { get; set; }
        public Country Country { get; set; }
        public double From
        {
            get{ 
                return _from; 
            }
            set { 
                _from = value;
                NotifyOfPropertyChange( () => From );
                NotifyOfPropertyChange( () => CanPrevious );
            }
        }

        public double To
        {
            get { 
                return _to; 
            }
            set { 
                _to = value;
                NotifyOfPropertyChange( () => To );
                NotifyOfPropertyChange( () => CanNext );
            }
        }

        public bool Paginate
        {
            get { return _paginate; }
            set { 
                _paginate = value;
                ChangeXLimits( value );

                NotifyOfPropertyChange( () => Paginate );
                NotifyOfPropertyChange( () => From );
                NotifyOfPropertyChange( () => To );
                NotifyOfPropertyChange( () => CanPrevious );
                NotifyOfPropertyChange( () => CanNext );
            }
        }

        private void ChangeXLimits( bool value )
        {
            From = 1;
            if ( value )
                To = Country.CurrentDay >= 20 ? 21 : Country.CurrentDay + 1;
            else
                To = Country.CurrentDay + 1;
        }

        public bool CanPrevious { get => From > 1; }
        public bool CanNext { get => To < Country.CurrentDay + 1; }

        public CountryDataViewModel( Country country )
        {
            Country = country;
            BECoronaTracker.Controllers.CountryDataController.GetData( Country );
            DrawData();
            Paginate = true;
        }

        private void DrawData()
        {
            Mapper = Mappers.Xy<State>()
                .X( state => state.DayNumber )
                .Y( state => state.TotalCases );

            var records = Country.States.ToArray();
            Results = records.AsChartValues();
        }

        public void Previous()
        {
            if ( From > 1 )
            {
                From -= 20;
                To = From + 20;
            }
        }

        public void Next()
        {
            if ( To < Country.CurrentDay + 1 )
            {
                From += 20;
                To = To <= Country.CurrentDay - 20 ? From + 21 : Country.CurrentDay + 1;
            }
        }
    }
}