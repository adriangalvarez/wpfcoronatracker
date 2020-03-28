using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Windows.Controls;

namespace WpfCoronaTracker.Views
{
    /// <summary>
    /// Interaction logic for CountryStateTooltipControl.xaml
    /// </summary>
    public partial class CountryStateTooltipControl : UserControl, IChartTooltip
    {
        private TooltipData _data;
        public event PropertyChangedEventHandler PropertyChanged;
        public TooltipSelectionMode? SelectionMode { get; set; }

        public CountryStateTooltipControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public TooltipData Data
        {
            get => _data;
            set {
                _data = value;
                OnPropertyChanged( "Data" );
            }
        }

        protected virtual void OnPropertyChanged( string propertyName = null )
        {
            if ( PropertyChanged != null )
                PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
