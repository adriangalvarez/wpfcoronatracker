using Caliburn.Micro;
using BECoronaTracker.Models;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;

namespace WpfCoronaTracker.ViewModels
{
    public class CountryDataViewModel : Conductor<object>
    {
        public ChartValues<State> Results { get; set; }
        public object Mapper { get; set; }
        public Country Country { get; set; }

        public CountryDataViewModel( Country country )
        {
            Country = country;
            BECoronaTracker.Controllers.CountryDataController.GetData( Country );
            DrawData();
        }

        private void DrawData()
        {
            Mapper = Mappers.Xy<State>()
                .X( state => state.DayNumber )
                .Y( state => state.TotalCases );

            var records = Country.States.ToArray();
            Results = records.AsChartValues();
        }
    }
}