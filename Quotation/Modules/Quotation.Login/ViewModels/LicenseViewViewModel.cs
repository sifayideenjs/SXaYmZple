using Quotation.Core.Utilities;
using Quotation.DataAccess;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class LicenseViewViewModel : ViewModelBase
    {
        #region Fields
        private LicenseDb dbContext = null;
        private string _licenseFilePath = string.Empty;
        private string _warningMessage = string.Empty;
        private bool _isLicenseUpdated = false;
        private string _expiryDate = string.Empty;
        #endregion //Fields

        #region Constructor
        public LicenseViewViewModel(LicenseDb licenseDb)
        {
            this.dbContext = licenseDb;

            string errorMessage;
            var licenseDetails = this.dbContext.GetLicenseDetails(out errorMessage);
            if (licenseDetails != null && licenseDetails.ContainsKey("ExpiryDate"))
            {
                _expiryDate = licenseDetails["ExpiryDate"];
                DateTime expiryDate; DateTime.TryParse(_expiryDate, out expiryDate);
                if (_expiryDate != null && IsDateBeforeOrToday(expiryDate))
                {
                    this.WarningMessage = string.Format("Your License expires on {0}", expiryDate.ToShortDateString());
                    this.IsLicenseUpdated = true;
                }
                else
                {
                    this.WarningMessage = string.Format("Your License was expired on {0}", expiryDate.ToShortDateString());
                    this.IsLicenseUpdated = false;
                }
            }
            else
            {
            }

            InitialilzeCommands();
        }
        #endregion //Constructor

        #region Properties
        public string LicenseFilePath
        {
            get { return _licenseFilePath; }
            set
            {
                _licenseFilePath = value;
                OnPropertyChanged();
            }
        }

        public string WarningMessage
        {
            get { return _warningMessage; }
            set
            {
                _warningMessage = value;
                OnPropertyChanged();
            }
        }
        public bool IsLicenseUpdated
        {
            get { return _isLicenseUpdated; }
            private set
            {
                _isLicenseUpdated = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void InitialilzeCommands()
        {
            this.BrowseLicenseFileCommand = new RelayCommand(ExecuteBrowseLicenseFileCommand);
            this.ActivateLicenseCommand = new RelayCommand(ExecuteActivateLicenseCommand, CanExecuteActivateLicenseCommand);
            this.NavigateCommand = new RelayCommand(ExecuteNavigateCommand, CanExecuteNavigateCommand);
        }

        public ICommand BrowseLicenseFileCommand { get; set; }

        private void ExecuteBrowseLicenseFileCommand()
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.Title = "Browse for License File";
            openDialog.DefaultExt = ".lic";
            openDialog.Filter = "License File|*.lic";
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                this.LicenseFilePath = openDialog.FileName;
            }
        }

        public ICommand ActivateLicenseCommand { get; set; }

        private bool CanExecuteActivateLicenseCommand()
        {
            if (this.dbContext == null) return false;

            if (string.IsNullOrEmpty(this.LicenseFilePath)) return false;
            else
            {
                var extn = Path.GetExtension(this.LicenseFilePath).ToUpper();
                if (extn == ".LIC") return true;
                else return false;
            }
        }

        private void ExecuteActivateLicenseCommand()
        {
            string errorMessage;
            var userId = IdentityUtility.GetLoggedInUserId();

            StreamReader reader = new StreamReader(this._licenseFilePath);
            string encryptedLicenseDetail = reader.ReadToEnd();
            reader.Close();
            
            var isUpdated = this.dbContext.UpdateLicense(userId, encryptedLicenseDetail, out errorMessage);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                this.WarningMessage = errorMessage;
                this.IsLicenseUpdated = false;
            }
            else
            {
                if(isUpdated)
                {
                    this.WarningMessage = string.Empty;

                    var licenseDetails = this.dbContext.GetLicenseDetails(out errorMessage);
                    if (licenseDetails != null && licenseDetails.ContainsKey("ExpiryDate"))
                    {
                        _expiryDate = licenseDetails["ExpiryDate"];
                        DateTime expiryDate; DateTime.TryParse(_expiryDate, out expiryDate);
                        if(_expiryDate != null && IsDateBeforeOrToday(expiryDate))
                        {
                            this.WarningMessage = string.Format("Your License expires on {0}", expiryDate.ToShortDateString());
                            this.IsLicenseUpdated = true;
                        }
                        else
                        {
                            this.WarningMessage = string.Format("Your License was expired on {0}", expiryDate.ToShortDateString());
                            this.IsLicenseUpdated = false;
                        }
                    }
                    else
                    {
                        this._expiryDate = string.Empty;
                        this.WarningMessage = "Please select a valid License file";
                        this.IsLicenseUpdated = false;
                    }
                }
                else
                {
                    this._expiryDate = string.Empty;
                    this.WarningMessage = "Please select a valid License file";
                    this.IsLicenseUpdated = false;
                }
            }
        }

        public ICommand NavigateCommand { get; set; }

        private bool CanExecuteNavigateCommand()
        {
            if (this.dbContext == null) return false;

            DateTime expiryDate; DateTime.TryParse(_expiryDate, out expiryDate);
            if (IsLicenseUpdated && IsDateBeforeOrToday(expiryDate)) return true;
            else return false;
        }

        private void ExecuteNavigateCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
        }
        #endregion //Commands

        public bool IsDateBeforeOrToday(DateTime inputDate)
        {
            bool result = DateTime.Today <= inputDate;
            return result;
        }
    }
}
