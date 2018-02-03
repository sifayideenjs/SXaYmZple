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
using System.Windows;
using Quotation.MotorInsuranceModule.Utilities;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class CreateQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;
        private Visibility _searchFound = Visibility.Collapsed;
        private QuotationViewModel quotationViewModel = null;
        private DataSet quotationDataSet = null;
        private string searchText = string.Empty;
        private string errorInfo = "No Record Found!";
        private DataSet searchDataSet = null;
        private bool isQuotationAdded = true;

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

        public Visibility SearchFound
        {
            get { return _searchFound; }
            set
            {
                _searchFound = value;
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

        public DataSet QuotationDataSet
        {
            get { return quotationDataSet; }
            set { quotationDataSet = value; OnPropertyChanged(); }
        }

        public bool IsQuotationAdded
        {
            get { return isQuotationAdded; }
            set { isQuotationAdded = value; OnPropertyChanged(); }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.SearchQuotationCommand = new RelayCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            //this.AddDriverCommand = new RelayCommand(this.ExecuteAddDriverCommand, this.CanExecuteAddDriverCommand);
            //this.DeleteDriverCommand = new RelayCommand(this.ExecuteDeleteDriverCommand, this.CanExecuteDeleteDriverCommand);
            this.AddQuotationCommand = new RelayCommand(this.ExecuteAddQuotationCommand, this.CanExecuteAddQuotationCommand);
            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
            //this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
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
                this.QuotationDataSet = null;
                SearchFound = Visibility.Collapsed;
                ClearRegions(RegionNames.MotorRenewQuotationRegion);

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
                        this.IsQuotationAdded = true;
                        this.QuotationViewModel = new QuotationViewModel(searchDataSet);
                        SearchFound = Visibility.Visible;

                        this.RegionManager.RequestNavigate(RegionNames.MotorRenewQuotationRegion, WindowNames.MotorRenewInsuranceDetail);
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
                if (IsQuotationAdded == true) return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public async void ExecuteAddQuotationCommand()
        {
            MIQuotation insuranceDetail = this.QuotationViewModel.CurrentInsuranceDetail.Model;
            if (insuranceDetail != null)
            {
                string quotationNo = DbUtility.GetNewQuotationNumber(quotationDb);

                insuranceDetail.NRIC = this.QuotationViewModel.OwnerDetail.NRIC;
                insuranceDetail.InsuranceQtnNo = quotationNo;
                var errorInfo = quotationDb.AddInsuranceDetails(insuranceDetail);
                if (errorInfo.Code == 0)
                {
                    this.IsQuotationAdded = false;
                    string errorMessage;
                    this.QuotationDataSet = quotationDb.GetMIQuoationDetails(quotationNo, out errorMessage);
                    //if(String.IsNullOrEmpty(errorMessage) == true)
                    //{
                    //    NavigationParameters navParameters = new NavigationParameters();
                    //    navParameters.Add("ReportDataSet", quotationDataSet);

                    //    this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, PopupNames.ReportModule_Motor, navParameters);
                    //}
                    //else
                    //{
                    //    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Renew Quotation", errorMessage);
                    //    return;
                    //}
                }
                else
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Renew Quotation", errorInfo.Info);
                    return;
                }

                //On Successfully creating a new quotation
                this.EventAggregator.GetEvent<NewQuotationEvent>().Publish(new QuotationEventArgs
                {
                    QuotationNumber = insuranceDetail.InsuranceQtnNo,
                    OwnerName = this.QuotationViewModel.OwnerDetail.Name,
                    NRICNumber = insuranceDetail.NRIC,
                    QuotationDataSet = quotationDataSet
                });
            }
            else
            {
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Renew Quotation", "Unable to add Insurance details");
                return;
            }
        }

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            if (IsQuotationAdded == false) return true;
            else return false;
        }

        public void ExecutePrintQuotationCommand()
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("ReportDataSet", this.QuotationDataSet);

            this.RegionManager.RequestNavigate(RegionNames.MotorRenewQuotationRegion, PopupNames.ReportModule_Motor, navParameters);
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
                    QuotationDataSet = null;
                    SearchFound = Visibility.Collapsed;
                    SearchText = string.Empty;
                    IsQuotationAdded = true;
                    ClearRegions(RegionNames.MotorRenewQuotationRegion);
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
