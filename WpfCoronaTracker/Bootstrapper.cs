using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WpfCoronaTracker.ViewModels;

namespace WpfCoronaTracker
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo( "es-AR" );
            FrameworkElement.LanguageProperty.OverrideMetadata( 
                typeof( FrameworkElement ), 
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage
                    ( 
                        CultureInfo.CurrentCulture.IetfLanguageTag
                    )
                )
            );
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
