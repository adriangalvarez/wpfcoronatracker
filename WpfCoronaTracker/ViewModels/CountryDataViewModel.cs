using Caliburn.Micro;
using BECoronaTracker.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using System.ComponentModel;
using System;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace WpfCoronaTracker.ViewModels
{
    public class CountryDataViewModel : Conductor<object>, IHandle<Country>
    {
        private readonly IEventAggregator _events;

        private double _from;
        private double _to;
        private bool _paginate;
        public int MaxDate { get; set; }

        public ChartValues<State> StateValues { get; set; }
        public SeriesCollection Results { get; set; }
        public object Mapper { get; set; }
        
        public List<Country> Countries { get; set; } = new List<Country>();

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

        private void ChangeXLimits( bool pagination )
        {
            From = 1;
            if ( pagination )
                To = MaxDate >= 20 ? 21 : MaxDate + 1;
            else
                To = MaxDate + 1;
        }

        public bool CanPrevious { get => From > 1; }
        public bool CanNext { get => Countries.Count > 0 && To < MaxDate + 1; }

        public CountryDataViewModel( IEventAggregator events )
        {
            _events = events;
            _events.Subscribe( this );
        }

        private void DrawData(Country country)
        {
            Mapper = Mappers.Xy<State>()
                .X( state => state.DayNumber )
                .Y( state => state.TotalCases );

            if ( Results == null )
            {
                Results = new SeriesCollection(Mapper);
                Paginate = true;
            }
            
            var records = country.States.ToArray();

            Results.Add( new LineSeries
            {
                Title = country.Name,
                Values = country.States.ToArray().AsChartValues(),
                Fill = Brushes.Transparent
            } );
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
            From += 20;
            To = To <= MaxDate - 20 ? From + 21 : MaxDate + 1;
        }

        public void Handle( Country message )
        {
            if ( message != null )
            {
                if ( Countries.Contains(message) )
                {
                    Countries.Remove( message );
                    Results.Remove( Results.First( x => x.Title == message.Name ) );
                    MaxDate = Countries.Count == 0 ? 1 : Countries.Max( x => x.CurrentDay );
                } else
                {
                    BECoronaTracker.Controllers.CountryDataController.GetData( message );
                    Countries.Add( message );
                    if ( MaxDate < message.CurrentDay )
                    {
                        MaxDate = message.CurrentDay;
                    }
                    DrawData( message );
                }

                Paginate = false;
            }
        }

        protected override void OnDeactivate( bool close )
        {
            _events.Unsubscribe( this );
            base.OnDeactivate( close );
        }
    }
}