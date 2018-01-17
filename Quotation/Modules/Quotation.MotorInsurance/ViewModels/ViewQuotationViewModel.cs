using Prism.Regions;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class ViewQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;

        public ViewQuotationViewModel(QuotationDb quotationDb)
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

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            return true;
        }

        public void ExecutePrintQuotationCommand()
        {
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<OpenQuotationEvent>().Unsubscribe(OnOpenQuotationEvent);
            this.EventAggregator.GetEvent<OpenQuotationEvent>().Subscribe(OnOpenQuotationEvent);
        }

        private void OnOpenQuotationEvent(QuotationEventArgs arg)
        {
            if(arg != null && arg.QuotationDataSet != null)
            {
                if(arg.QuotationDataSet.Tables.Count == 4)
                {
                    OwnerDetail ownerDetail = GetOwnerDetail(arg.QuotationDataSet.Tables[0]);
                    List<DriverDetail> driverDetails = GetDriverDetails(arg.QuotationDataSet.Tables[1]);
                    VehicleDetail vehicleDetail = GetVehicleDetail(arg.QuotationDataSet.Tables[2]);
                    MIQuotation insuranceDetail = GetInsuranceDetail(arg.QuotationDataSet.Tables[3]);
                    QuotationViewModel = new QuotationViewModel(quotationDb, ownerDetail, driverDetails, vehicleDetail, insuranceDetail);

                    //ClearRegions(RegionNames.MotorWizardRegion);
                    this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                }
            }
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
            if(dataTable != null && dataTable.Rows.Count > 0)
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
