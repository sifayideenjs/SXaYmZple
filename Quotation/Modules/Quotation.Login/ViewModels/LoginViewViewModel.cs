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
using Quotation.Infrastructure.Models;
using System.Threading;
using Quotation.Core;
using Quotation.Infrastructure.Events;

namespace Quotation.LoginModule.ViewModels
{
    public class LoginViewViewModel : ViewModelBase
    {
        #region Fields
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private string _error = string.Empty;
        private string _status = string.Empty;
        #endregion //Fields

        #region Constructor
        public LoginViewViewModel()
        {
            this._authenticationService = this.Container.Resolve<IAuthenticationService>(ServiceNames.AuthenticationService);
            this.IntializeCommands();

#if DEBUG
            Username = "Mark";
#endif
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
#if DEBUG
            if(_username == "Mark") clearTextPassword = "Mark";
            else if (_username == "John") clearTextPassword = "John";
#endif
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
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Roles);

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

                this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
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
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.LoginView);
        }
        #endregion //Commands
    }
}
