using Prism.Commands;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Quotation.Infrastructure;
using System.Windows.Controls;
using System.Threading;
using Quotation.Core;
using Quotation.Infrastructure.Events;
using Prism.Regions;
using Quotation.DataAccess;
using Quotation.Core.Utilities;

namespace Quotation.LoginModule.ViewModels
{
    public class LoginViewViewModel : ViewModelBase
    {
        #region Fields
        private LicenseDb dbContext = null;
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private string _error = string.Empty;
        private string _status = string.Empty;
        #endregion //Fields

        #region Constructor
        public LoginViewViewModel(LicenseDb licenseDb)
        {
            this.dbContext = licenseDb;
            this._authenticationService = this.Container.Resolve<IAuthenticationService>(ServiceNames.AuthenticationService);
            this.IntializeCommands();

//#if DEBUG
//            Username = "Admin";
//#endif
        }
        #endregion //Constructor

        #region Properties
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged();
            }
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.LoginCommand = new RelayCommand<object>(this.ExecuteLoginCommand, this.CanExecuteLoginCommand);
            this.LogoutCommand = new RelayCommand(this.ExecuteLogoutCommand, this.CanExecuteLogoutCommand);
        }

        public ICommand LoginCommand { get; private set; }

        public bool CanExecuteLoginCommand(object parameter)
        {
            return true;
        }

        public void ExecuteLoginCommand(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
//#if DEBUG
//            if (_username == "Mark") clearTextPassword = "Mark";
//            else if (_username == "Admin") clearTextPassword = "Admin";
//#endif
            try
            {
                //Validate Credentials through the Authentication Service
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);

                //Get the Current Principal Object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                {
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
                }

                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.ID, user.Name, user.Username, user.Role, user.FormNames);

                //Update UI
                OnPropertyChanged("IsAuthenticated");
                Username = string.Empty;
                passwordBox.Password = string.Empty;
                Status = string.Empty;

                this.EventAggregator.GetEvent<LoginEvent>().Publish(new LoginEventArgs
                {
                    User = user,
                    ActionType = "Login"
                });

                string errorMessage;
                var licenseDetails = this.dbContext.GetLicenseDetails(out errorMessage);
                if (licenseDetails != null && licenseDetails.ContainsKey("ExpiryDate"))
                {
                    var eDate = licenseDetails["ExpiryDate"];
                    DateTime expiryDate; DateTime.TryParse(eDate, out expiryDate);
                    if (string.IsNullOrEmpty(eDate) == false && IsDateBeforeOrToday(expiryDate))
                    {
                        if(ClockTampering.IsClockTampered())
                        {
                            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.ClockTamperingDetectionView);
                        }
                        else
                        {
                            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
                        }
                    }
                    else
                    {
                        this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.LicenseView);
                    }
                }
                else
                {
                    this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.LicenseView);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
                this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Login", Status);
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
                this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Login", Status);
            }
        }

        public ICommand LogoutCommand { get; private set; }

        public bool CanExecuteLogoutCommand()
        {
            return true;
        }

        public void ExecuteLogoutCommand()
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                OnPropertyChanged("IsAuthenticated");
                Status = string.Empty;
            }

            ClearRegions(RegionNames.MainRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.LoginView);
        }
        #endregion //Commands

        public bool IsDateBeforeOrToday(DateTime inputDate)
        {
            bool result = DateTime.Today <= inputDate;
            return result;

        }
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
