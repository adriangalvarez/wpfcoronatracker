using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCoronaTracker.ViewModels
{
    public class CountryStateTooltipControlViewModel : Screen, IChartTooltip
    {
        private TooltipData _data;
        public event PropertyChangedEventHandler PropertyChanged;

        public CountryStateTooltipControlViewModel()
        {
        }

        public TooltipData Data
        {
            get => _data;
            set {
                _data = value;
                OnPropertyChanged();
            }
        }

        public TooltipSelectionMode? SelectionMode { get; set; }

        protected virtual void OnPropertyChanged( string propertyName = null )
        {
            if ( PropertyChanged != null )
                PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
