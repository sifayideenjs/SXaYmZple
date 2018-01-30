using Prism.Regions;
using Quotation.DataAccess;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Interfaces;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Quotation.MotorInsuranceModule.Views;
using Quotation.DataAccess.Models;
using MaterialDesignThemes.Wpf;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class CreateQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;
        private QuotationViewModel quotationViewModel = null;
        private string searchText = string.Empty;
        private string errorInfo = "No Record Found!";
        private DataSet searchDataSet = null;

        public CreateQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Properties
        public QuotationViewModel QuotationViewModel
        {
            get { return quotationViewModel; }
            set
            {
                quotationViewModel = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        public string ErrorInfo
        {
            get
            {
                return errorInfo;
            }
            set
            {
                errorInfo = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.SearchQuotationCommand = new RelayCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.AddDriverCommand = new RelayCommand(this.ExecuteAddDriverCommand, this.CanExecuteAddDriverCommand);
            this.DeleteDriverCommand = new RelayCommand(this.ExecuteDeleteDriverCommand, this.CanExecuteDeleteDriverCommand);
            this.AddQuotationCommand = new RelayCommand(this.ExecuteAddQuotationCommand, this.CanExecuteAddQuotationCommand);
            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
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


        public ICommand SearchQuotationCommand { get; private set; }

        public bool CanExecuteSearchQuotationCommand()
        {
            if (string.IsNullOrEmpty(this.SearchText)) return false;
            else return true;
        }

        public async void ExecuteSearchQuotationCommand()
        {
            try
            {
                ClearRegions(RegionNames.MotorCreateQuotationRegion);

                string errorMessage = string.Empty;
                searchDataSet = null;
                searchDataSet = quotationDb.GetNRICDetails(this.SearchText, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", errorMessage);
                    return;
                }
                else
                {
                    if (searchDataSet != null && searchDataSet.Tables.Count == 4 && searchDataSet.Tables[0].Rows.Count > 0)
                    {
                        this.QuotationViewModel = new QuotationViewModel(quotationDb, searchDataSet);
                        //this.RegionManager.RequestNavigate(RegionNames.MotorCreateQuotationRegion, WindowNames.MotorAddQuotationDetail);
                    }
                    else
                    {
                        await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", errorInfo);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ErrorInfo = ex.Message;
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", string.Format("ERROR: {0}", ex.Message));
            }
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

            var result = await DialogHost.Show(view, "DriverDialog_CreateQuotation", ExtendedOpenedEventHandler);
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
        }


        public ICommand DeleteDriverCommand { get; private set; }

        public bool CanExecuteDeleteDriverCommand()
        {
            if(QuotationViewModel != null && QuotationViewModel.SelectedDriverDetail != null)
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
                DriverDetails = this.QuotationViewModel.DriverDetails.Count == 0 ? null : this.QuotationViewModel.DriverDetails.Select(dd => dd.Model),
                VehicleDetail = this.QuotationViewModel.VehicleDetail.Model,
                InsuranceDetail = this.QuotationViewModel.CurrentInsuranceDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                //Source = WindowNames.MotorSummaryDetail
                Source = PopupNames.ReportModule_Motor
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

            this.RegionManager.RequestNavigate(RegionNames.MotorCreateQuotationRegion, PopupNames.ReportModule_Motor, navParameters);
        }


        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            return true;
        }

        public void ExecutePreviousCommand()
        {
            this.QuotationViewModel = null;
            this.searchDataSet = null;
            this.SearchText = string.Empty;
            ClearRegions(RegionNames.MotorCreateQuotationRegion);
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
        }
        #endregion //EventAggregation

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                //QuotationViewModel = new QuotationViewModel(quotationDb);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                if(QuotationViewModel != null)
                {
                    (QuotationViewModel as IViewModel).UnSubscribeEvents();
                    QuotationViewModel = null;
                }
            }
        }
        #endregion //INavigationAware

        private void ClearRegions(string regionName)
        {
            if (this.RegionManager.Regions.ContainsRegionWithName(regionName))
            {
                IRegion region = this.RegionManager.Regions[regionName];
                if (region != null)
                {
                    var views = region.Views;
                    foreach (var view in views)
                    {
                        region.Remove(view);
                    }
                }
            }
        }
    }
}
