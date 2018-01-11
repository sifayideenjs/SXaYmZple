﻿using Prism.Unity;
using System.Windows;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Quotation.Infrastructure.Constants;
using Prism.Modularity;
using Quotation.Shell.Views;
using Quotation.Infrastructure.Services;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Interfaces;
using Prism.Logging;

namespace Quotation.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Container.RegisterInstance(typeof(Window), WindowNames.MainWindowName, Container.Resolve<ShellWindow>(), new ContainerControlledLifetimeManager());
            return Container.Resolve<Window>(WindowNames.MainWindowName);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            // Register views
            var regionManager = this.Container.Resolve<IRegionManager>();
            if (regionManager != null)
            {
                //Prism.Unity.UnityExtensions.RegisterTypeForNavigation<Views.MainWindow>(this.Container, WindowNames.DashboardWindow);
                //regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(MainWindow));

                // Add right windows commands
                //regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
                // Add flyouts
                //regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(ShellSettingsFlyout));
                // Add tiles to MainRegion
                //regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));
            }

            // Register services
            this.RegisterServices();

            Application.Current.MainWindow.Show();
        }
        
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IApplicationCommands, ApplicationCommandsProxy>();
            Container.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

            Container.RegisterTypeForNavigation< Quotation.DashboardModule.Views.Dashboard> (WindowNames.Dashboard);
        }
        
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Quotation.LoginModule.LoginModule));
            moduleCatalog.AddModule(typeof(Quotation.MotorInsuranceModule.MotorInsuranceModule));
            moduleCatalog.AddModule(typeof(Quotation.TravelInsuranceModule.TravelInsuranceModule));
            moduleCatalog.AddModule(typeof(Quotation.DashboardModule.DashboardModule));
        }
        
        private void RegisterServices()
        {
            Container.RegisterInstance<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService, Container.Resolve<MetroMessageDisplayService>(), new ContainerControlledLifetimeManager());
        }
        
        protected override ILoggerFacade CreateLogger()
        {
            return new Logging.NLogLogger();
        }
    }
}