using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoronaTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup( object sender, StartupEventArgs e )
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo( "es-AR" );

            MainWindow window = new MainWindow();
            if ( e.Args.Length == 1 )
            {
                window.Title = $"{e.Args[ 0 ]}";
            }
            window.Show();
        }

        private void Application_DispatcherUnhandledException( object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e )
        {
            MessageBox.Show( e.Exception.Message, "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error );
            e.Handled = true;
        }
    }
}
