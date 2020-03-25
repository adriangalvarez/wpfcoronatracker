using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCoronaTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Models.Country> countries;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded( object sender, RoutedEventArgs e )
        {
            try
            {
                //this.cmbCountryList.DisplayMemberPath = "Name";
                //this.cmbCountryList.SelectedValuePath = "Code";
                this.cmbCountryList.ItemsSource = Models.CountryList.LoadCountryList();
            } catch ( Exception ex)
            {
                throw ex;
            }
        }

        private void cmbCountryList_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {

        }
    }
}
