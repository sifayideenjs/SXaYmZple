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

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class QuotationViewModel : ViewModelBase
    {
        QuotationDb quotationDb;

        private OwnerDetailViewModel ownerDetail;
        private ObservableCollection<DriverDetailViewModel> driverDetails;
        private DriverDetailViewModel currentDriverDetail;
        private DriverDetailViewModel selectedDriverDetail;
        private VehicleDetailViewModel vehicleDetail;
        private ObservableCollection<InsuranceDetailViewModel> insuranceDetails;
        private InsuranceDetailViewModel currentInsuranceDetail;

        public QuotationViewModel(OwnerDetail ownerDetail, List<DriverDetail> driverDetails, VehicleDetail vehicleDetail, List<MIQuotation> insuranceDetails)
        {
            this.ownerDetail = new OwnerDetailViewModel(ownerDetail);
            this.driverDetails = new ObservableCollection<DriverDetailViewModel>(driverDetails.Select(d => new DriverDetailViewModel(d)));
            this.vehicleDetail = new VehicleDetailViewModel(vehicleDetail);
            this.insuranceDetails = new ObservableCollection<InsuranceDetailViewModel>(insuranceDetails.Select(i => new InsuranceDetailViewModel(i)));
            SubscribeEvents();
        }

        public QuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            SubscribeEvents();
            this.EditOwnerCommand = new Infrastructure.RelayCommand(this.ExecuteEditOwnerCommand, this.CanExecuteEditOwnerCommand);
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

        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Subscribe(OnAddOwnerView);
            this.EventAggregator.GetEvent<SaveDriverEvent>().Subscribe(OnSaveDriverView);
            this.EventAggregator.GetEvent<AddVehicleEvent>().Subscribe(OnAddVehicleView);
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Subscribe(OnAddInsuranceView);
        }

        private void OnAddOwnerView(OwnerEventArgs arg)
        {
            if (arg != null && this.OwnerDetail.IsValid())
            {
                OwnerDetail ownerDetail = arg.OwnerDetail;
                if (ownerDetail != null)
                {
                    ownerDetail.CreatedBy = "Sifayideen";
                    ownerDetail.LastUpdatedBy = "Sifayideen";

                    var errorInfo = quotationDb.AddOwnerDetails(ownerDetail);
                    if (errorInfo.Code == 0)
                    {
                        this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                    }
                    else
                    {
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

        private void OnSaveDriverView(DriverEventArgs arg)
        {
            if (arg != null)
            {
                this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
            }
        }

        private void OnAddVehicleView(VehicleEventArgs arg)
        {
            if (arg != null && this.VehicleDetail.IsValid())
            {
                VehicleDetail vehicleDetail = arg.VehicleDetail;
                if (vehicleDetail != null)
                {
                    vehicleDetail.NRIC = this.OwnerDetail.NRIC;
                    var errorInfo = quotationDb.AddVehicleDetails(vehicleDetail);
                    if (errorInfo.Code == 0)
                    {
                        this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                    }
                    else
                    {
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

        private void OnAddInsuranceView(InsuranceEventArgs arg)
        {
            if (arg != null && this.CurrentInsuranceDetail.IsValid())
            {
                MIQuotation insuranceDetail = arg.InsuranceDetail;
                if (insuranceDetail != null)
                {
                    insuranceDetail.NRIC = this.OwnerDetail.NRIC;
                    insuranceDetail.InsuranceQtnNo = "123456";
                    var errorInfo = quotationDb.AddInsuranceDetails(insuranceDetail);
                    if (errorInfo.Code == 0)
                    {
                        this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
                    }
                    else
                    {
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


        public System.Windows.Input.ICommand EditOwnerCommand { get; private set; }

        public bool CanExecuteEditOwnerCommand()
        {
            return true;
        }

        public void ExecuteEditOwnerCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.DialogPopupRegion, WindowNames.MotorAddOwnerDetail);
        }
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
        public Nullable<short> RenewalRemindDays
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
            }

            return validationMessage;
        }

        internal bool IsValid()
        {
            if (string.IsNullOrEmpty(Name) == false &&
                string.IsNullOrEmpty(NRIC) == false &&
                DateOfBirth != null &&
                string.IsNullOrEmpty(Gender) == false &&
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
            this.Name = string.Empty;
            this.NRIC = string.Empty;
            this.DateOfBirth = null;
            this.Gender = string.Empty;
            this.MaritalStatus = false;
            this.Occupation = string.Empty;
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
        public System.DateTime DateOfRegistered
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
        public byte ParallelImport
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
        public byte OffPeakVehicle
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
        public System.DateTime InsuranceExpiryDate
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
        public System.DateTime InsuranceRenewalDate
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
        public System.DateTime RoadTaxExpiryDate
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
        public System.DateTime RoadTaxRenewalDate
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
        public byte InsuranceRenewed
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
        public byte RoadTaxRenewed
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
