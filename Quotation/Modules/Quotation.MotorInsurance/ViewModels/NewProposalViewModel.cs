using Prism.Commands;
using Prism.Regions;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quotation.DataAccess;
using Quotation.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Models;
using Quotation.Infrastructure.Utilities;
using Quotation.MotorInsuranceModule.Views;
using MaterialDesignThemes.Wpf;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class NewProposalViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;

        public NewProposalViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();
            this.SubscribeEvents();
        }
       
        public QuotationViewModel QuotationViewModel { get; set; }

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);

            this.AddOwnerCommand = new RelayCommand(this.ExecuteAddOwnerCommand, this.CanExecuteAddOwnerCommand);
            this.DeleteOwnerCommand = new RelayCommand(this.ExecuteDeleteCommand, this.CanExecuteDeleteCommand);

            this.AddDriverCommand = new RelayCommand(this.ExecuteAddDriverCommand, this.CanExecuteAddDriverCommand);
            this.DeleteDriverCommand = new RelayCommand(this.ExecuteDeleteDriverCommand, this.CanExecuteDeleteDriverCommand);

            this.AddQuotationCommand = new RelayCommand(this.ExecuteAddQuotationCommand, this.CanExecuteAddQuotationCommand);
            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);

            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
        }

        public ICommand DashboardCommand { get; private set; }

        public bool CanExecuteDashboardCommand()
        {
            return true;
        }

        public void ExecuteDashboardCommand()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Publish(new DashboardEventArgs
            {
            });
        }

        public ICommand DeleteOwnerCommand { get; private set; }

        public bool CanExecuteDeleteCommand()
        {
            return true;
        }

        public async void ExecuteDeleteCommand()
        {
            string title = "Create Owner";
            string message = "Do you really want to cancel the Owner creation?";
            if(this.QuotationViewModel.IsOwnerCreated)
            {
                title = "Delete Owner";
                message = "Do you really want to delete the Owner?";
            }

            var result = await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc(title, message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);

            if (result == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
            {
                this.EventAggregator.GetEvent<DeleteOwnerEvent>().Publish(new Events.OwnerEventArgs
                {
                });
            }
        }

        public ICommand AddOwnerCommand { get; private set; }

        public bool CanExecuteAddOwnerCommand()
        {
            if (this.QuotationViewModel != null && this.QuotationViewModel.OwnerDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddOwnerCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new OwnerEventArgs
            {
                OwnerDetail = this.QuotationViewModel.OwnerDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddQuotationDetail
            });
        }


        public ICommand AddDriverCommand { get; private set; }

        public bool CanExecuteAddDriverCommand()
        {
            return true;
        }

        public async void ExecuteAddDriverCommand()
        {
            var view = new AddDriverDialog
            {
                DataContext = new AddDriverDialogViewModel(new DriverDetailViewModel(new DriverDetail()))
            };

            var result = await DialogHost.Show(view, "DriverDialog_NewQuotation", ExtendedOpenedEventHandler);
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
        }

        public ICommand DeleteDriverCommand { get; private set; }

        public bool CanExecuteDeleteDriverCommand()
        {
            if (QuotationViewModel != null && QuotationViewModel.SelectedDriverDetail != null)
            {
                return true;
            }
            else return false;
        }

        public void ExecuteDeleteDriverCommand()
        {
            this.EventAggregator.GetEvent<DeleteDriverEvent>().Publish(new DriverEventArgs
            {
                DriverDetail = QuotationViewModel.SelectedDriverDetail.Model
            });
        }

        public ICommand AddQuotationCommand { get; private set; }

        public bool CanExecuteAddQuotationCommand()
        {
            if (this.QuotationViewModel != null && this.QuotationViewModel.VehicleDetail.IsValid() && this.QuotationViewModel.CurrentInsuranceDetail.IsValid())
            {
                bool isValid = true;
                //foreach (var dDetail in this.QuotationViewModel.DriverDetails)
                //{
                //    if (dDetail.IsValid() == false)
                //    {
                //        isValid = false;
                //    }
                //}

                return isValid;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddQuotationCommand()
        {
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Publish(new InsuranceEventArgs
            {
                DriverDetails = this.QuotationViewModel.DriverDetails.Select(dd => dd.Model),
                VehicleDetail = this.QuotationViewModel.VehicleDetail.Model,
                InsuranceDetail = this.QuotationViewModel.CurrentInsuranceDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                //Source = WindowNames.MotorSummaryDetail
                Source = PopupNames.ReportModule_Motor
            });
        }

        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            return true;
        }

        public void ExecutePreviousCommand()
        {
            this.EventAggregator.GetEvent<PreviousEvent>().Publish(new PreviousEventArgs
            {
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddOwnerDetail
            });
        }

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            return true;
        }

        public void ExecutePrintQuotationCommand()
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("ReportDataSet", this.QuotationViewModel.QuotationDataSet);

            this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, PopupNames.ReportModule_Motor, navParameters);
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<DeleteOwnerEvent>().Unsubscribe(OnCancelEvent);
            this.EventAggregator.GetEvent<DeleteOwnerEvent>().Subscribe(OnCancelEvent);

            this.EventAggregator.GetEvent<PreviousEvent>().Unsubscribe(OnPreviousEvent);
            this.EventAggregator.GetEvent<PreviousEvent>().Subscribe(OnPreviousEvent);

            this.EventAggregator.GetEvent<NextEvent>().Unsubscribe(OnNextEvent);
            this.EventAggregator.GetEvent<NextEvent>().Subscribe(OnNextEvent);
        }

        private void OnCancelEvent(OwnerEventArgs arg)
        {
            ExecuteDashboardCommand();
        }

        private void OnPreviousEvent(PreviousEventArgs arg)
        {
            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
        }

        private void OnNextEvent(NextEventArgs arg)
        {
            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
        }
        #endregion //EventAggregation

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                QuotationViewModel = new QuotationViewModel(quotationDb);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if(navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                (QuotationViewModel as IViewModel).UnSubscribeEvents();
                QuotationViewModel = null;
            }
        }
        #endregion //INavigationAware
    }
}
