using Prism.Commands;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quotation.DataAccess.Models;
using Newtonsoft.Json;
using Prism.Regions;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using System.Data;
using Quotation.DataAccess;
using Quotation.Infrastructure.Events;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class SearchQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;
        private QuotationViewModel quotationViewModel = null;
        private string searchText = string.Empty;
        private List<string> searchTypes = null;
        private string searchType = string.Empty;
        private string errorInfo = "No Record Found!";
        private DataSet searchDataSet = null;

        public SearchQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();

            searchTypes = new List<string>() { "NRIC", "Quotation No" };
            searchType = searchTypes.First();
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

        public List<string> SearchTypes
        {
            get
            {
                return searchTypes;
            }
            set
            {
                searchTypes = value;
                OnPropertyChanged();
            }
        }

        public string SearchType
        {
            get
            {
                return searchType;
            }
            set
            {
                searchType = value;
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
            this.RenewInsuranceCommand = new RelayCommand(this.ExecuteRenewInsuranceCommand, this.CanExecuteRenewInsuranceCommand);
            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
            this.DeleteQuotationCommand = new RelayCommand(this.ExecuteDeleteQuotationCommand, this.CanExecuteDeleteQuotationCommand);
            this.AddInsuranceCommand = new RelayCommand(this.ExecuteAddInsuranceCommand, this.CanExecuteAddInsuranceCommand);
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
                ClearRegions(RegionNames.MotorSearchRegion);

                string errorMessage = string.Empty;
                searchDataSet = null;
                searchDataSet = quotationDb.GetMIQuoationDetails(this.SearchText, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", errorMessage);
                    return;
                }
                else
                {
                    if (searchDataSet != null && searchDataSet.Tables.Count == 4)
                    {
                        this.QuotationViewModel = new QuotationViewModel(searchDataSet);
                        this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorSummaryDetail);
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


        public ICommand RenewInsuranceCommand { get; private set; }

        public bool CanExecuteRenewInsuranceCommand()
        {
            return true;
        }

        public void ExecuteRenewInsuranceCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorInsuranceRenewalDetail);
        }
        

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            return true;
        }

        public void ExecutePrintQuotationCommand()
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("ReportDataSet", searchDataSet);

            this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, PopupNames.ReportModule_Motor, navParameters);
        }


        public ICommand DeleteQuotationCommand { get; private set; }

        public bool CanExecuteDeleteQuotationCommand()
        {
            return true;
        }

        public void ExecuteDeleteQuotationCommand()
        {
        }


        public ICommand AddInsuranceCommand { get; private set; }

        public bool CanExecuteAddInsuranceCommand()
        {
            return true;
        }

        public void ExecuteAddInsuranceCommand()
        {
        }
        #endregion //Commands

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
