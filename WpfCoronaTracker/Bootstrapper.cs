﻿using Caliburn.Micro;
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
        private readonly SimpleContainer _container = new SimpleContainer();

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

        protected override void Configure()
        {
            _container.Instance( _container );

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                .Where( type => type.IsClass )
                .Where( type => type.Name.EndsWith( "ViewModel" ) )
                .ToList()
                .ForEach( viewModelType => _container.RegisterPerRequest(
                     viewModelType, viewModelType.ToString(), viewModelType ) );
        }

        protected override object GetInstance( Type service, string key )
        {
            return _container.GetInstance( service, key );
        }

        protected override IEnumerable<object> GetAllInstances( Type service )
        {
            return _container.GetAllInstances( service );
        }

        protected override void BuildUp( object instance )
        {
            _container.BuildUp( instance );
        }
    }
}
