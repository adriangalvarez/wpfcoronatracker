using Caliburn.Micro;
using BECoronaTracker.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using System.ComponentModel;

namespace WpfCoronaTracker.ViewModels
{
    public class CountryDataViewModel : Conductor<object>, INotifyPropertyChanged
    {
        public ChartValues<State> Results { get; set; }
        public object Mapper { get; set; }
        public Country Country { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( string propertyName = null )
        {
            if ( PropertyChanged != null )
                PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }

        private double _from;

        public double From
        {
            get{ 
                return _from; 
            }
            set { 
                _from = value;
                OnPropertyChanged( "From" );
            }
        }

        private double _to;

        public double To
        {
            get { 
                return _to; 
            }
            set { 
                _to = value;
                OnPropertyChanged( "To" );
            }
        }




        public CountryDataViewModel( Country country )
        {
            Country = country;
            BECoronaTracker.Controllers.CountryDataController.GetData( Country );
            DrawData();
            From = 1;
            To = Country.CurrentDay > 20 ? 20 : Country.CurrentDay;
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
                To -= 20;
            }
        }

        public void Next()
        {
            if ( To < Country.CurrentDay )
            {
                From += 20;
                To += 20;
            }
        }
    }
}