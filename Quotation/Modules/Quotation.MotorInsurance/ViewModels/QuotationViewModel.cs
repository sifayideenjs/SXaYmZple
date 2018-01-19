using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quotation.DataAccess.Models;
using System.Collections.ObjectModel;
using Quotation.MotorInsuranceModule.Events;
using Quotation.Infrastructure.Constants;
using Quotation.DataAccess;
using System.ComponentModel;
using Quotation.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using System.Data;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class QuotationViewModel : ViewModelBase, IViewModel
    {
        QuotationDb quotationDb;

        private bool isOwnerCreated = false;
        private bool isDriverUpdated = false;
        private bool isVehicalUpdated = false;
        private bool isInsuranceUpdated = false;

        private OwnerDetailViewModel ownerDetail;
        private ObservableCollection<DriverDetailViewModel> driverDetails;
        private DriverDetailViewModel currentDriverDetail;
        private DriverDetailViewModel selectedDriverDetail;
        private VehicleDetailViewModel vehicleDetail;
        private ObservableCollection<InsuranceDetailViewModel> insuranceDetails;
        private InsuranceDetailViewModel currentInsuranceDetail;

        public QuotationViewModel(QuotationDb quotationDb, OwnerDetail ownerDetail, List<DriverDetail> driverDetails, VehicleDetail vehicleDetail, MIQuotation insuranceDetail)
        {
            this.quotationDb = quotationDb;
            this.ownerDetail = new OwnerDetailViewModel(ownerDetail);
            this.driverDetails = new ObservableCollection<DriverDetailViewModel>();
            if (driverDetails != null && driverDetails.Count > 0)
            {
                this.driverDetails = new ObservableCollection<DriverDetailViewModel>(driverDetails.Select(d => new DriverDetailViewModel(d)));
            }
            this.vehicleDetail = new VehicleDetailViewModel(vehicleDetail);
            this.currentInsuranceDetail = new InsuranceDetailViewModel(insuranceDetail);
            SubscribeEvents();
        }

        public QuotationViewModel(DataSet dataSet)
        {
            if (dataSet != null && dataSet.Tables.Count == 4)
            {
                OwnerDetail ownerDetail = GetOwnerDetail(dataSet.Tables[0]);
                this.ownerDetail = new OwnerDetailViewModel(ownerDetail);

                List<DriverDetail> driverDetails = GetDriverDetails(dataSet.Tables[1]);
                this.driverDetails = new ObservableCollection<DriverDetailViewModel>();
                if (driverDetails != null && driverDetails.Count > 0)
                {
                    this.driverDetails = new ObservableCollection<DriverDetailViewModel>(driverDetails.Select(d => new DriverDetailViewModel(d)));
                }

                VehicleDetail vehicleDetail = GetVehicleDetail(dataSet.Tables[2]);
                this.vehicleDetail = new VehicleDetailViewModel(vehicleDetail);

                MIQuotation insuranceDetail = GetInsuranceDetail(dataSet.Tables[3]);
                this.currentInsuranceDetail = new InsuranceDetailViewModel(insuranceDetail);
            }
            else
            {
                this.ownerDetail = new OwnerDetailViewModel(new DataAccess.Models.OwnerDetail());
                this.driverDetails = new ObservableCollection<DriverDetailViewModel>();
                this.vehicleDetail = new VehicleDetailViewModel(new DataAccess.Models.VehicleDetail());
                this.currentInsuranceDetail = new InsuranceDetailViewModel(new MIQuotation());
            }

            SubscribeEvents();
        }

        public QuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;

#if DEBUG
            DataAccess.Models.OwnerDetail ownerDetail = new DataAccess.Models.OwnerDetail()
            {
                Name = "Sifayideen",
                NRIC = "YYY-ZZZ1",
                DateOfBirth = new DateTime(1983, 5, 7),
                Gender = "MALE",
                MaritalStatus = true,
                Occupation = "Software Engineer",
                LicenseDate = DateTime.Now,
                Email = "sifayideen@gmail.com",
                Address = "Chennai",
                RenewalRemindDays = 7
            };

            this.ownerDetail = new OwnerDetailViewModel(ownerDetail);
#else
            this.ownerDetail = new OwnerDetailViewModel(new DataAccess.Models.OwnerDetail());
#endif

#if DEBUG
            DataAccess.Models.DriverDetail driverDetail = new DataAccess.Models.DriverDetail()
            {
                InsuredName = "Kasim",
                InsuredNRIC = "YYY",
                BizRegNo = "2233",
                DateOfBirth = new DateTime(1984, 4, 11),
                Gender = "MALE",
                MaritalStatus = true,
                Occupation = "Software Engineer",
                Industry = "IT",
                LicenseDate = DateTime.Now
            };
            this.driverDetails = new ObservableCollection<DriverDetailViewModel>() { new DriverDetailViewModel(driverDetail) };
#else
            this.driverDetails = new ObservableCollection<DriverDetailViewModel>();
#endif

#if DEBUG
            DataAccess.Models.VehicleDetail vehicleDetail = new DataAccess.Models.VehicleDetail()
            {
                Make = "TOYOTA COROLLA",
                Model = "AXIO 1.5XA",
                YearMade = "2007",
                Capacity = "1496CC",
                DateOfRegistered = DateTime.Now,
                RegNo = "SGY9152X",
                PreviousRegNo = "SGY9152X",
                ParallelImport = 1,
                OffPeakVehicle = 0,
                NCD = "10% EISTING",
                ExistingInsurer = "AXA",
                Claims = string.Empty
            };

            this.VehicleDetail = new VehicleDetailViewModel(vehicleDetail);
#else
            this.vehicleDetail = new VehicleDetailViewModel(new DataAccess.Models.VehicleDetail());
#endif

#if DEBUG
            DataAccess.Models.MIQuotation insuranceDetail = new DataAccess.Models.MIQuotation()
            {
                InsuranceExpiryDate = new DateTime(2019, 01, 14),
                InsuranceRenewalDate = new DateTime(2019, 01, 14),
                RoadTaxExpiryDate = new DateTime(2020, 01, 14),
                RoadTaxRenewalDate = new DateTime(2020, 01, 14),
                PreviousDealer = "CAR HOUSE",
                Agency = "MDIVINE",
                FinanceBank = "MAYBANK",
                PrevYearPremium = "NIL"
            };
            this.CurrentInsuranceDetail = new InsuranceDetailViewModel(insuranceDetail);
#else            
            this.currentInsuranceDetail = new InsuranceDetailViewModel(new MIQuotation());
#endif
            SubscribeEvents();
        }

        public bool IsOwnerCreated
        {
            get { return isOwnerCreated; }
            set { isOwnerCreated = value; OnPropertyChanged(); }
        }
        public bool IsDriverUpdated
        {
            get { return isDriverUpdated; }
            set { isDriverUpdated = value; OnPropertyChanged(); }
        }
        public bool IsVehicalUpdated
        {
            get { return isVehicalUpdated; }
            set { isVehicalUpdated = value; OnPropertyChanged(); }
        }
        public bool IsInsuranceUpdated
        {
            get { return isInsuranceUpdated; }
            set { isInsuranceUpdated = value; OnPropertyChanged(); }
        }


        public OwnerDetailViewModel OwnerDetail
        {
            get { return ownerDetail; }
            set { ownerDetail = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DriverDetailViewModel> DriverDetails
        {
            get
            {
                return driverDetails;
            }
            set
            {
                driverDetails = value;
                OnPropertyChanged();
            }
        }

        public DriverDetailViewModel CurrentDriverDetail
        {
            get
            {
                return currentDriverDetail;
            }
            set
            {
                currentDriverDetail = value;
                OnPropertyChanged();
            }
        }

        public DriverDetailViewModel SelectedDriverDetail
        {
            get
            {
                return selectedDriverDetail;
            }
            set
            {
                selectedDriverDetail = value;
                OnPropertyChanged();
            }
        }

        public VehicleDetailViewModel VehicleDetail
        {
            get { return vehicleDetail; }
            set { vehicleDetail = value; OnPropertyChanged(); }
        }

        public ObservableCollection<InsuranceDetailViewModel> InsuranceDetails
        {
            get
            {
                return insuranceDetails;
            }
            set
            {
                insuranceDetails = value;
                OnPropertyChanged();
            }
        }

        public InsuranceDetailViewModel CurrentInsuranceDetail
        {
            get
            {
                return currentInsuranceDetail;
            }
            set
            {
                currentInsuranceDetail = value;
                OnPropertyChanged();
            }
        }

        public void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Subscribe(OnAddOwnerView);
            this.EventAggregator.GetEvent<DeleteOwnerEvent>().Subscribe(OnDeleteOwnerEvent);
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Subscribe(OnAddInsuranceView);
        }

        private async void OnAddOwnerView(OwnerEventArgs arg)
        {
            if (arg != null && this.OwnerDetail.IsValid())
            {
                OwnerDetail ownerDetail = arg.OwnerDetail;
                if (ownerDetail != null)
                {
                    if(this.IsOwnerCreated == false)
                    {
                        ownerDetail.CreatedBy = "Sifayideen";
                        ownerDetail.LastUpdatedBy = "Sifayideen";

                        var errorInfo = quotationDb.AddOwnerDetails(ownerDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                            this.IsOwnerCreated = true;
                        }
                        else
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", "Owner with same NRIC already exist!");
                        }
                    }
                    else
                    {
                        ownerDetail.LastUpdatedBy = "Sifayideen";

                        var errorInfo = quotationDb.EditOwnerDetails(ownerDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                            this.IsOwnerCreated = true;
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", "Unable to add Owner details");
                    return;
                }
            }
            else
            {
            }
        }

        private void OnDeleteOwnerEvent(OwnerEventArgs arg)
        {
            if (arg != null)
            {
                OwnerDetail ownerDetail = arg.OwnerDetail;
                if (ownerDetail != null)
                {
                    if (this.IsOwnerCreated == true)
                    {
                        var errorInfo = quotationDb.DeleteOwnerDetails(ownerDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
                }
            }
            else
            {
            }
        }

        private async void OnAddInsuranceView(InsuranceEventArgs arg)
        {
            if (arg != null && this.VehicleDetail.IsValid() && this.CurrentInsuranceDetail.IsValid())
            {
                IEnumerable<DriverDetail> driverDetails = arg.DriverDetails;
                foreach(var driver in driverDetails)
                {
                    driver.NRIC = this.OwnerDetail.NRIC;
                }
                if (this.IsDriverUpdated == false)
                {
                    var errorInfo = quotationDb.AddDriverDetails(this.OwnerDetail.NRIC, driverDetails);
                    if (errorInfo.Code == 0)
                    {
                        this.IsDriverUpdated = true;
                    }
                    else
                    {
                        await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorInfo.Info);
                        return;
                    }
                }

                VehicleDetail vehicleDetail = arg.VehicleDetail;
                if (vehicleDetail != null)
                {
                    if (this.IsVehicalUpdated == false)
                    {
                        vehicleDetail.NRIC = this.OwnerDetail.NRIC;
                        var errorInfo = quotationDb.AddVehicleDetails(vehicleDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.IsVehicalUpdated = true;
                        }
                        else
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorInfo.Info);
                            return;
                        }
                    }
                    else
                    {
                        var errorInfo = quotationDb.EditVehicleDetails(vehicleDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.IsVehicalUpdated = true;
                        }
                        else
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorInfo.Info);
                            return;
                        }
                    }
                }
                else
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", "Unable to add Vehicle details");
                    return;
                }

                MIQuotation insuranceDetail = arg.InsuranceDetail;
                if (insuranceDetail != null)
                {
                    if(this.IsInsuranceUpdated == false)
                    {
                        insuranceDetail.NRIC = this.OwnerDetail.NRIC;
                        insuranceDetail.InsuranceQtnNo = "1234567";
                        var errorInfo = quotationDb.AddInsuranceDetails(insuranceDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                            this.IsInsuranceUpdated = true;
                        }
                        else
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorInfo.Info);
                            return;
                        }
                    }
                    else
                    {
                        var errorInfo = quotationDb.EditInsuranceDetails(insuranceDetail);
                        if (errorInfo.Code == 0)
                        {
                            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                            this.IsInsuranceUpdated = true;
                        }
                        else
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorInfo.Info);
                            return;
                        }
                    }
                }
                else
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", "Unable to add Insurance details");
                    return;
                }
            }
            else
            {
            }
        }
        
        public void UnSubscribeEvents()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Unsubscribe(OnAddOwnerView);
            this.EventAggregator.GetEvent<DeleteOwnerEvent>().Unsubscribe(OnDeleteOwnerEvent);
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Unsubscribe(OnAddInsuranceView);
        }

        #region Helper


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
        #endregion //Helper
    }

    public class OwnerDetailViewModel : ViewModelBase, IDataErrorInfo
    {
        OwnerDetail model = null;
        private List<string> genderTypes = new List<string>() { "MALE", "FEMALE" };
        private List<string> maritalStatusTypes = new List<string>() { "NO", "YES" };
        private List<short> renewalReminds = new List<short>() { 1, 7, 14, 30, 60 };

        public OwnerDetailViewModel(OwnerDetail model)
        {
            this.model = model;
            if(this.model != null)
            {
                this.model.Gender = this.genderTypes.First();
                this.model.RenewalRemindDays = this.renewalReminds.First();
            }
        }

        public OwnerDetail Model
        {
            get { return this.model; }
        }
        public string Name
        {
            get
            {
                return this.model.Name;
            }
            set
            {
                this.model.Name = value;
                OnPropertyChanged();
            }
        }
        public string NRIC
        {
            get
            {
                return this.model.NRIC;
            }
            set
            {
                this.model.NRIC = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.model.DateOfBirth;
            }
            set
            {
                this.model.DateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public List<string> GenderTypes
        {
            get
            {
                return genderTypes;
            }
            set
            {
                genderTypes = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get
            {
                return this.model.Gender;
            }
            set
            {
                this.model.Gender = value;
                OnPropertyChanged();
            }
        }
        public List<string> MaritalStatusTypes
        {
            get
            {
                return maritalStatusTypes;
            }
            set
            {
                maritalStatusTypes = value;
                OnPropertyChanged();
            }
        }
        public Nullable<bool> MaritalStatus
        {
            get
            {
                return this.model.MaritalStatus;
            }
            set
            {
                this.model.MaritalStatus = value;
                OnPropertyChanged();
            }
        }
        public string Occupation
        {
            get
            {
                return this.model.Occupation;
            }
            set
            {
                this.model.Occupation = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> LicenseDate
        {
            get
            {
                return this.model.LicenseDate;
            }
            set
            {
                this.model.LicenseDate = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return this.model.Email;
            }
            set
            {
                this.model.Email = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get
            {
                return this.model.Address;
            }
            set
            {
                this.model.Address = value;
                OnPropertyChanged();
            }
        }
        public List<short> RenewalReminds
        {
            get
            {
                return renewalReminds;
            }
            set
            {
                renewalReminds = value;
                OnPropertyChanged();
            }
        }
        public Nullable<int> RenewalRemindDays
        {
            get
            {
                return this.model.RenewalRemindDays;
            }
            set
            {
                this.model.RenewalRemindDays = value;
                OnPropertyChanged();
            }
        }

        #region Validation
        public string Error
        {
            get;
        }
        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "Name":
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        validationMessage = "Please enter Insurer name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "NRIC":
                    if (string.IsNullOrEmpty(this.NRIC))
                    {
                        validationMessage = "Please enter NRIC number";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "DateOfBirth":
                    if (this.DateOfBirth == null)
                    {
                        validationMessage = "Please choose Date of Birth";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Occupation":
                    if (string.IsNullOrEmpty(this.Occupation))
                    {
                        validationMessage = "Please enter an Occupation";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "LicenseDate":
                    if (this.LicenseDate == null)
                    {
                        validationMessage = "Please choose a License date";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Address":
                    if (string.IsNullOrEmpty(this.Address))
                    {
                        validationMessage = "Please enter Address";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
            }

            return validationMessage;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name) == false &&
                string.IsNullOrEmpty(NRIC) == false &&
                DateOfBirth != null &&
                string.IsNullOrEmpty(Gender) == false &&
                string.IsNullOrEmpty(Occupation) == false &&
                LicenseDate != null &&
                string.IsNullOrEmpty(Address) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion //Validation
    }

    public class DriverDetailViewModel : ViewModelBase, IDataErrorInfo
    {
        private DriverDetail model;
        private List<string> genderTypes = new List<string>() { "MALE", "FEMALE" };
        private List<string> maritalStatusTypes = new List<string>() { "NO", "YES" };

        public DriverDetailViewModel(DriverDetail model)
        {
            this.model = model;
        }

        public DriverDetail Model
        {
            get { return model; }
        }
        public string InsuredName
        {
            get
            {
                return this.model.InsuredName;
            }
            set
            {
                this.model.InsuredName = value;
                OnPropertyChanged();
            }
        }
        public string InsuredNRIC
        {
            get
            {
                return this.model.InsuredNRIC;
            }
            set
            {
                this.model.InsuredNRIC = value;
                OnPropertyChanged();
            }
        }
        public string BizRegNo
        {
            get
            {
                return this.model.BizRegNo;
            }
            set
            {
                this.model.BizRegNo = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this.model.DateOfBirth;
            }
            set
            {
                this.model.DateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public List<string> GenderTypes
        {
            get
            {
                return genderTypes;
            }
            set
            {
                genderTypes = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get
            {
                return this.model.Gender;
            }
            set
            {
                this.model.Gender = value;
                OnPropertyChanged();
            }
        }
        public List<string> MaritalStatusTypes
        {
            get
            {
                return maritalStatusTypes;
            }
            set
            {
                maritalStatusTypes = value;
                OnPropertyChanged();
            }
        }
        public Nullable<bool> MaritalStatus
        {
            get
            {
                return this.model.MaritalStatus;
            }
            set
            {
                this.model.MaritalStatus = value;
                OnPropertyChanged();
            }
        }
        public string Occupation
        {
            get
            {
                return this.model.Occupation;
            }
            set
            {
                this.model.Occupation = value;
                OnPropertyChanged();
            }
        }
        public string Industry
        {
            get
            {
                return this.model.Industry;
            }
            set
            {
                this.model.Industry = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> LicenseDate
        {
            get
            {
                return this.model.LicenseDate;
            }
            set
            {
                this.model.LicenseDate = value;
                OnPropertyChanged();
            }
        }

        #region Validation
        public string Error
        {
            get;
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "InsuredName":
                    if (string.IsNullOrEmpty(this.InsuredName))
                    {
                        validationMessage = "Please enter Insurer name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "InsuredNRIC":
                    if (string.IsNullOrEmpty(this.InsuredNRIC))
                    {
                        validationMessage = "Please enter Insurer NRIC number";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "BizRegNo":
                    if (string.IsNullOrEmpty(this.BizRegNo))
                    {
                        validationMessage = "Please enter Biz Reg number";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "DateOfBirth":
                    if (this.DateOfBirth == null)
                    {
                        validationMessage = "Please choose Date of Birth";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Occupation":
                    if (string.IsNullOrEmpty(this.Occupation))
                    {
                        validationMessage = "Please enter an Occupation";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Industry":
                    if (string.IsNullOrEmpty(this.Industry))
                    {
                        validationMessage = "Please enter an Industry";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "LicenseDate":
                    if (this.LicenseDate == null)
                    {
                        validationMessage = "Please choose a License date";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
            }

            return validationMessage;
        }

        internal bool IsValid()
        {
            if (string.IsNullOrEmpty(InsuredName) == false &&
                string.IsNullOrEmpty(InsuredNRIC) == false &&
                DateOfBirth != null &&
                string.IsNullOrEmpty(Gender) == false &&
                string.IsNullOrEmpty(Occupation) == false &&
                string.IsNullOrEmpty(Occupation) == false &&
                LicenseDate != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ClearDetail()
        {
            this.InsuredName = string.Empty;
            this.InsuredNRIC = string.Empty;
            this.DateOfBirth = null;
            this.Gender = string.Empty;
            this.MaritalStatus = false;
            this.Occupation = string.Empty;
            this.Industry = string.Empty;
            this.LicenseDate = null;
        }
        #endregion //Validation

    }

    public class VehicleDetailViewModel : ViewModelBase, IDataErrorInfo
    {
        VehicleDetail model = null;
        private List<string> yesNOs = new List<string>() { "NO", "YES" };

        public VehicleDetailViewModel(VehicleDetail model)
        {
            this.model = model;
        }

        public VehicleDetail Model
        {
            get { return model; }
        }
        public string NRIC
        {
            get
            {
                return this.model.NRIC;
            }
            set
            {
                this.model.NRIC = value;
                OnPropertyChanged();
            }
        }
        public string Make
        {
            get
            {
                return this.model.Make;
            }
            set
            {
                this.model.Make = value;
                OnPropertyChanged();
            }
        }
        public string VehicleModel
        {
            get
            {
                return this.model.Model;
            }
            set
            {
                this.model.Model = value;
                OnPropertyChanged();
            }
        }
        public string Capacity
        {
            get
            {
                return this.model.Capacity;
            }
            set
            {
                this.model.Capacity = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> DateOfRegistered
        {
            get
            {
                return this.model.DateOfRegistered;
            }
            set
            {
                this.model.DateOfRegistered = value;
                OnPropertyChanged();
            }
        }
        public string YearMade
        {
            get
            {
                return this.model.YearMade;
            }
            set
            {
                this.model.YearMade = value;
                OnPropertyChanged();
            }
        }
        public string RegNo
        {
            get
            {
                return this.model.RegNo;
            }
            set
            {
                this.model.RegNo = value;
                OnPropertyChanged();
            }
        }
        public List<string> YesNos
        {
            get
            {
                return yesNOs;
            }
            set
            {
                yesNOs = value;
                OnPropertyChanged();
            }
        }
        public int ParallelImport
        {
            get
            {
                return this.model.ParallelImport;
            }
            set
            {
                this.model.ParallelImport = value;
                OnPropertyChanged();
            }
        }
        public int OffPeakVehicle
        {
            get
            {
                return this.model.OffPeakVehicle;
            }
            set
            {
                this.model.OffPeakVehicle = value;
                OnPropertyChanged();
            }
        }
        public string NCD
        {
            get
            {
                return this.model.NCD;
            }
            set
            {
                this.model.NCD = value;
                OnPropertyChanged();
            }
        }
        public string ExistingInsurer
        {
            get
            {
                return this.model.ExistingInsurer;
            }
            set
            {
                this.model.ExistingInsurer = value;
                OnPropertyChanged();
            }
        }
        public string PreviousRegNo
        {
            get
            {
                return this.model.PreviousRegNo;
            }
            set
            {
                this.model.PreviousRegNo = value;
                OnPropertyChanged();
            }
        }
        public string Claims
        {
            get
            {
                return this.model.Claims;
            }
            set
            {
                this.model.Claims = value;
                OnPropertyChanged();
            }
        }

        #region Validation
        public string Error
        {
            get;
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "Make":
                    if (string.IsNullOrEmpty(this.Make))
                    {
                        validationMessage = "Please enter Vehicle Make";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "VehicleModel":
                    if (string.IsNullOrEmpty(this.VehicleModel))
                    {
                        validationMessage = "Please enter Vehicle Model";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Capacity":
                    if (string.IsNullOrEmpty(this.Capacity))
                    {
                        validationMessage = "Please enter Vehicle Capacity";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "DateOfRegistered":
                    if (this.DateOfRegistered == null)
                    {
                        validationMessage = "Please choose Date Of Registered";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "YearMade":
                    if (string.IsNullOrEmpty(this.YearMade))
                    {
                        validationMessage = "Please enter Vehicle Year Made";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "RegNo":
                    if (string.IsNullOrEmpty(this.RegNo))
                    {
                        validationMessage = "Please enter Vehicle Registration No";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "NCD":
                    if (string.IsNullOrEmpty(this.NCD))
                    {
                        validationMessage = "Please enter NCD";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                //case "ExistingInsurer":
                //    if (string.IsNullOrEmpty(this.ExistingInsurer))
                //    {
                //        validationMessage = "Please enter Existing Insurer";
                //    }
                //    else
                //    {
                //        validationMessage = string.Empty;
                //    }
                //    break;
                //case "PreviousRegNo":
                //    if (string.IsNullOrEmpty(this.PreviousRegNo))
                //    {
                //        validationMessage = "Please enter Vehicle Previous Registration No";
                //    }
                //    else
                //    {
                //        validationMessage = string.Empty;
                //    }
                //    break;
                //case "Claims":
                //    if (string.IsNullOrEmpty(this.Claims))
                //    {
                //        validationMessage = "Please enter Vehicle Claims";
                //    }
                //    else
                //    {
                //        validationMessage = string.Empty;
                //    }
                //    break;
            }

            return validationMessage;
        }

        internal bool IsValid()
        {
            if (string.IsNullOrEmpty(Make) == false &&
                string.IsNullOrEmpty(VehicleModel) == false &&
                string.IsNullOrEmpty(Capacity) == false &&
                DateOfRegistered != null &&
                string.IsNullOrEmpty(YearMade) == false &&
                string.IsNullOrEmpty(RegNo) == false &&
                string.IsNullOrEmpty(NCD) == false &&
                string.IsNullOrEmpty(ExistingInsurer) == false &&
                string.IsNullOrEmpty(PreviousRegNo) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion //Validation
    }

    public class InsuranceDetailViewModel : ViewModelBase, IDataErrorInfo
    {
        MIQuotation model = null;
        
        public InsuranceDetailViewModel(MIQuotation model)
        {
            this.model = model;
        }

        public MIQuotation Model
        {
            get { return model; }
        }
        public string NRIC
        {
            get
            {
                return this.model.NRIC;
            }
            set
            {
                this.model.NRIC = value;
                OnPropertyChanged();
            }
        }
        public string InsuranceQtnNo
        {
            get
            {
                return this.model.InsuranceQtnNo;
            }
            set
            {
                this.model.InsuranceQtnNo = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> InsuranceExpiryDate
        {
            get
            {
                return this.model.InsuranceExpiryDate;
            }
            set
            {
                this.model.InsuranceExpiryDate = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> InsuranceRenewalDate
        {
            get
            {
                return this.model.InsuranceRenewalDate;
            }
            set
            {
                this.model.InsuranceRenewalDate = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> RoadTaxExpiryDate
        {
            get
            {
                return this.model.RoadTaxExpiryDate;
            }
            set
            {
                this.model.RoadTaxExpiryDate = value;
                OnPropertyChanged();
            }
        }
        public Nullable<System.DateTime> RoadTaxRenewalDate
        {
            get
            {
                return this.model.RoadTaxRenewalDate;
            }
            set
            {
                this.model.RoadTaxRenewalDate = value;
                OnPropertyChanged();
            }
        }
        public string PreviousDealer
        {
            get
            {
                return this.model.PreviousDealer;
            }
            set
            {
                this.model.PreviousDealer = value;
                OnPropertyChanged();
            }
        }
        public string Agency
        {
            get
            {
                return this.model.Agency;
            }
            set
            {
                this.model.Agency = value;
                OnPropertyChanged();
            }
        }
        public string PrevYearPremium
        {
            get
            {
                return this.model.PrevYearPremium;
            }
            set
            {
                this.model.PrevYearPremium = value;
                OnPropertyChanged();
            }
        }
        public string FinanceBank
        {
            get
            {
                return this.model.FinanceBank;
            }
            set
            {
                this.model.FinanceBank = value;
                OnPropertyChanged();
            }
        }
        public int InsuranceRenewed
        {
            get
            {
                return this.model.InsuranceRenewed;
            }
            set
            {
                this.model.InsuranceRenewed = value;
                OnPropertyChanged();
            }
        }
        public int RoadTaxRenewed
        {
            get
            {
                return this.model.RoadTaxRenewed;
            }
            set
            {
                this.model.RoadTaxRenewed = value;
                OnPropertyChanged();
            }
        }


        #region Validation
        public string Error
        {
            get;
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "InsuranceExpiryDate":
                    if (this.InsuranceExpiryDate == null)
                    {
                        validationMessage = "Please choose Insurance Expiry Date";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "RoadTaxExpiryDate":
                    if (this.RoadTaxExpiryDate == null)
                    {
                        validationMessage = "Please choose Road Tax Expiry Date";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "PreviousDealer":
                    if (string.IsNullOrEmpty(this.PreviousDealer))
                    {
                        validationMessage = "Please enter Previous Dealer / Purchase Date";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Agency":
                    if (string.IsNullOrEmpty(this.Agency))
                    {
                        validationMessage = "Please enter Agency name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "PrevYearPremium":
                    if (string.IsNullOrEmpty(this.PrevYearPremium))
                    {
                        validationMessage = "Please enter Previous Year Premium";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "FinanceBank":
                    if (string.IsNullOrEmpty(this.FinanceBank))
                    {
                        validationMessage = "Please enter Finance Bank name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
            }

            return validationMessage;
        }

        internal bool IsValid()
        {
            if (InsuranceExpiryDate != null &&
                RoadTaxExpiryDate != null &&
                string.IsNullOrEmpty(PreviousDealer) == false &&
                string.IsNullOrEmpty(Agency) == false &&
                string.IsNullOrEmpty(PrevYearPremium) == false &&
                string.IsNullOrEmpty(FinanceBank) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion //Validation
    }
}
