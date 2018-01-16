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

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class SearchQuotationViewModel : ViewModelBase
    {
        private ObservableCollection<OwnerDetail> ownerDetails = new ObservableCollection<OwnerDetail>();
        private string searchText = string.Empty;
        private List<string> searchTypes = null;
        private string searchType = string.Empty;
        private string errorInfo = "No Record Found!";

        public SearchQuotationViewModel()
        {
            this.IntializeCommands();

            searchTypes = new List<string>() { "NRIC", "Quotation No" };
            searchType = searchTypes.First();
        }

        #region Properties
        public ObservableCollection<OwnerDetail> OwnerDetails
        {
            get
            {
                return ownerDetails;
            }
            set
            {
                ownerDetails = value;
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

        public void ExecuteSearchQuotationCommand()
        {
            try
            {
                //HttpResponseMessage responseMessage = client.GetAsync("/api/Quotation/GetAllOwnerDetails").Result;
                //if (responseMessage.IsSuccessStatusCode)
                //{
                //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                //    IEnumerable<OwnerDetail> ownerDetails = JsonConvert.DeserializeObject<IEnumerable<OwnerDetail>>(responseData);
                //    OwnerDetails = new ObservableCollection<OwnerDetail>(ownerDetails.Select(o => o));

                //    this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorSearchQuotationDetail);
                //}
                //else
                //{
                //    this.ErrorInfo = "No Record Found!";
                //    this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorNonSearchDetail);
                //}
            }
            catch (Exception ex)
            {
                this.ErrorInfo = ex.Message;
                //this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorNonSearchDetail);
                this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", ex.Message);
            }
            this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", this.ErrorInfo);
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
    }
}
