using Prism.Unity;
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
using Quotation.Core;
using System;
using System.Threading;
using Quotation.LoginModule.Services;

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

            //Create a Custom Principal with an Anonymous Identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
            //Thread.CurrentPrincipal = customPrincipal;

            // Register services
            this.RegisterServices();

            Application.Current.MainWindow.Show();
        }
        
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IApplicationCommands, ApplicationCommandsProxy>();
            Container.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

            Container.RegisterTypeForNavigation<Quotation.LoginModule.Views.LoginView>(WindowNames.LoginView);
            Container.RegisterTypeForNavigation<Quotation.LoginModule.Views.LicenseView>(WindowNames.LicenseView);
            Container.RegisterTypeForNavigation<Quotation.LoginModule.Views.UserManagement>(WindowNames.UserManagementView);
            Container.RegisterTypeForNavigation<Quotation.LoginModule.Views.GroupManagement>(WindowNames.GroupManagementView);
            //Container.RegisterTypeForNavigation<Quotation.LoginModule.Views.AdministrationTitlebar>(FlyoutNames.LoginAdminFlyout);

            Container.RegisterTypeForNavigation< Quotation.DashboardModule.Views.Dashboard> (WindowNames.Dashboard);

            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.NewProposal>(WindowNames.MotorNewProposal);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.CreateQuotation>(WindowNames.MotorCreateQuotation);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.Wizards.AddOwnerDetail>(WindowNames.MotorAddOwnerDetail);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.CreateWizards.AddQuotationDetail>(WindowNames.MotorAddQuotationDetail);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.Wizards.QuotationSummary>(WindowNames.MotorSummaryDetail);

            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.SearchWizards.SearchView>(WindowNames.MotorSearchQuotationDetail);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.SearchWizards.NonSearchView>(WindowNames.MotorNonSearchDetail);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.SearchWizards.InsuranceRenewalDetail>(WindowNames.MotorInsuranceRenewalDetail);

            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.RecentQuotation>(WindowNames.MotorRecentQuotation);
            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.ViewQuotation>(WindowNames.MotorViewQuotation);

            Container.RegisterTypeForNavigation<Quotation.MotorInsuranceModule.Views.SearchQuotation>(WindowNames.MotorSearchQuotation);

            // Container.RegisterTypeForNavigation<Quotation.ReportModule.MotorQuotationReport>(WindowNames.ReportView);
        }
        
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Quotation.LoginModule.LoginModule));
            moduleCatalog.AddModule(typeof(Quotation.MotorInsuranceModule.MotorInsuranceModule));
            //moduleCatalog.AddModule(typeof(Quotation.TravelInsuranceModule.TravelInsuranceModule));
            moduleCatalog.AddModule(typeof(Quotation.DashboardModule.DashboardModule));
            moduleCatalog.AddModule(typeof(Quotation.ReportModule.ReportModule));
        }
        
        private void RegisterServices()
        {
            Container.RegisterInstance<IAuthenticationService>(ServiceNames.AuthenticationService, Container.Resolve<AuthenticationService>(), new ContainerControlledLifetimeManager());
            Container.RegisterInstance<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService, Container.Resolve<MetroMessageDisplayService>(), new ContainerControlledLifetimeManager());
        }
        
        protected override ILoggerFacade CreateLogger()
        {
            return new Logging.NLogLogger();
        }
    }
}