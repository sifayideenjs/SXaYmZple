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

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class SearchQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;
        private ObservableCollection<OwnerDetail> ownerDetails = new ObservableCollection<OwnerDetail>();
        private string searchText = string.Empty;
        private List<string> searchTypes = null;
        private string searchType = string.Empty;
        private string errorInfo = "No Record Found!";

        public SearchQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();

            searchTypes = new List<string>() { "NRIC", "Quotation No" };
            searchType = searchTypes.First();
        }

        #region Properties
        public QuotationViewModel QuotationViewModel { get; set; }

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
                string errorMessage = string.Empty;
                DataSet quotationDataSet = quotationDb.GetMIQuoationDetails(this.SearchText, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", errorMessage);
                    return;
                }
                else
                {
                    if (quotationDataSet != null)
                    {
                        if (quotationDataSet.Tables.Count == 4)
                        {
                            OwnerDetail ownerDetail = GetOwnerDetail(quotationDataSet.Tables[0]);
                            List<DriverDetail> driverDetails = GetDriverDetails(quotationDataSet.Tables[1]);
                            VehicleDetail vehicleDetail = GetVehicleDetail(quotationDataSet.Tables[2]);
                            MIQuotation insuranceDetail = GetInsuranceDetail(quotationDataSet.Tables[3]);
                            this.QuotationViewModel = new QuotationViewModel(quotationDb, ownerDetail, driverDetails, vehicleDetail, insuranceDetail);

                            //ClearRegions(RegionNames.MotorWizardRegion);
                            this.RegionManager.RequestNavigate(RegionNames.MotorSearchRegion, WindowNames.MotorSummaryDetail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ErrorInfo = ex.Message;
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Search", ex.Message);
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
                (QuotationViewModel as IViewModel).UnSubscribeEvents();
                QuotationViewModel = null;
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

        private OwnerDetail GetOwnerDetail(DataTable dataTable)
        {
            OwnerDetail ownerDetail = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                ownerDetail = new OwnerDetail
                {
                    Name = row.Field<string>("Name"),
                    NRIC = row.Field<string>("NRIC"),
                    DateOfBirth = row.Field<DateTime?>("DateOfBirth"),
                    Gender = row.Field<string>("Gender"),
                    MaritalStatus = row.Field<bool?>("MaritalStatus"),
                    Occupation = row.Field<string>("Occupation"),
                    LicenseDate = row.Field<DateTime?>("LicenseDate"),
                    CreatedBy = row.Field<string>("CreatedBy"),
                    CreatedDate = row.Field<DateTime?>("CreatedDate"),
                    LastUpdatedBy = row.Field<string>("LastUpdatedBy"),
                    LastUpdatedDate = row.Field<DateTime?>("LastUpdatedDate"),
                    Email = row.Field<string>("Email"),
                    Address = row.Field<string>("Address"),
                    // RenewalRemindDays = row.Field<short?>("RenewalRemindDays"),
                };
            }
            return ownerDetail;
        }
        private List<DriverDetail> GetDriverDetails(DataTable dataTable)
        {
            List<DriverDetail> driverDetails = new List<DriverDetail>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                driverDetails = dataTable.AsEnumerable().Select(row => new DriverDetail
                {
                    NRIC = row.Field<string>("NRIC"),
                    InsuredName = row.Field<string>("InsuredName"),
                    InsuredNRIC = row.Field<string>("InsuredNRIC"),
                    BizRegNo = row.Field<string>("BizRegNo"),
                    DateOfBirth = row.Field<DateTime?>("DateofBirth"),
                    Gender = row.Field<string>("Gender"),
                    MaritalStatus = int.Parse(row["MaritalStatus"].ToString()) == 1 ? true : false,
                    Occupation = row.Field<string>("Occupation"),
                    Industry = row.Field<string>("Industry"),
                    LicenseDate = row.Field<DateTime?>("LicenseDate"),
                }).ToList();
            }
            return driverDetails;
        }
        private VehicleDetail GetVehicleDetail(DataTable dataTable)
        {
            VehicleDetail vehicleDetail = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                vehicleDetail = new VehicleDetail
                {
                    NRIC = row.Field<string>("NRIC"),
                    Make = row.Field<string>("Make"),
                    Model = row.Field<string>("Model"),
                    Capacity = row.Field<string>("Capacity"),
                    DateOfRegistered = row.Field<DateTime?>("DateOfRegistered"),
                    YearMade = row.Field<string>("YearMade"),
                    RegNo = row.Field<string>("RegNo"),
                    ParallelImport = int.Parse(row["ParallelImport"].ToString()),
                    OffPeakVehicle = int.Parse(row["OffPeakVehicle"].ToString()),
                    NCD = row.Field<string>("NCD"),
                    ExistingInsurer = row.Field<string>("ExistingInsurer"),
                    PreviousRegNo = row.Field<string>("PreviousRegNo"),
                    Claims = row.Field<string>("Claims")
                };
            }
            return vehicleDetail;
        }
        private MIQuotation GetInsuranceDetail(DataTable dataTable)
        {
            List<MIQuotation> insuranceDetails = new List<MIQuotation>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                insuranceDetails = dataTable.AsEnumerable().Select(row => new MIQuotation
                {
                    NRIC = row.Field<string>("NRIC"),
                    InsuranceQtnNo = row.Field<string>("InsuranceQtnNo"),
                    InsuranceExpiryDate = row.Field<DateTime?>("InsuranceExpiryDate"),
                    InsuranceRenewalDate = row.Field<DateTime?>("InsuranceRenewalDate"),
                    RoadTaxExpiryDate = row.Field<DateTime?>("RoadTaxExpiryDate"),
                    RoadTaxRenewalDate = row.Field<DateTime?>("RoadTaxRenewalDate"),
                    PreviousDealer = row.Field<string>("PreviousDealer"),
                    Agency = row.Field<string>("Agency"),
                    PrevYearPremium = row.Field<string>("PrevYearPremium"),
                    FinanceBank = row.Field<string>("FinanceBank"),
                    InsuranceRenewed = int.Parse(row["InsuranceRenewed"].ToString()),
                    RoadTaxRenewed = int.Parse(row["RoadTaxRenewed"].ToString()),
                }).ToList();
            }
            return insuranceDetails.FirstOrDefault();
        }
    }
}
