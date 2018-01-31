using Prism.Regions;
using Quotation.Core.Utilities;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Practices.Unity;

namespace Quotation.LoginModule.ViewModels
{
    public class UserProfileFlyoutViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private string _name = string.Empty;
        private string _role = string.Empty;
        private Visibility _IsLoggedIn = Visibility.Collapsed;
        private UserManagementDb dbContext = null;
        public UserProfileFlyoutViewModel(UserManagementDb dbContext)
        {
            this.dbContext = dbContext;
            this.Name = IdentityUtility.GetLoggedInName();
            this.UserName = IdentityUtility.GetLoggedInUserName();
            this.Role = IdentityUtility.GetLoggedInUserRole();
            InitializeCommands();
            SubscribeEvents();
        }

        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged();
            }
        }

        public Visibility IsLoggedIn
        {
            get { return _IsLoggedIn; }
            set
            {
                _IsLoggedIn = value;
                OnPropertyChanged();
            }
        }

        #region Reset Comand
        private void InitializeCommands()
        {
            ResetComand = new AnotherCommandImplementation(ExecuteResetCommand, CanExecuteResetCommand);
        }

        public ICommand ResetComand { get; set; }
        public bool CanExecuteResetCommand(object parameter)
        {
            if (parameter == null) return false;
            if(parameter is PasswordBox)
            {
                PasswordBox passwordBox = parameter as PasswordBox;
                string clearTextPassword = passwordBox.Password;
                if (string.IsNullOrEmpty(clearTextPassword))
                {
                    return false;
                }
                else return true;
            }
            else return false;
        }

        private async void ExecuteResetCommand(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;

            if (IsSaveComplete == true)
            {
                IsSaveComplete = false;
                return;
            }

            if (SaveProgress != 0) return;

            var started = DateTime.Now;
            IsSaving = true;
            
            var userDetail = new UserDetail()
            {
                UserID = IdentityUtility.GetLoggedInUserId(),
                Name = this.Name,
                UserName = this.UserName,
                Password = clearTextPassword,
                GroupID = 0
            };
            var errorInfo = this.dbContext.UpdateUser(userDetail, "RESET", this.UserName);
            if (errorInfo.Code == 0)
            {
            }
            else
            {
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Reset Password", errorInfo.Info);
            }

            new DispatcherTimer(
                TimeSpan.FromMilliseconds(50),
                DispatcherPriority.Normal,
                new EventHandler((o, e) =>
                {
                    var totalDuration = started.AddSeconds(3).Ticks - started.Ticks;
                    var currentProgress = DateTime.Now.Ticks - started.Ticks;
                    var currentProgressPercent = 100.0 / totalDuration * currentProgress;

                    SaveProgress = currentProgressPercent;

                    if (SaveProgress >= 100)
                    {
                        passwordBox.Password = string.Empty;
                        IsSaveComplete = true;
                        IsSaving = false;
                        SaveProgress = 0;
                        ((DispatcherTimer)o).Stop();
                    }

                }), Dispatcher.CurrentDispatcher);
        }

        private bool _isSaving;
        public bool IsSaving
        {
            get { return _isSaving; }
            private set { _isSaving = value; OnPropertyChanged(); }
        }

        private bool _isSaveComplete;
        public bool IsSaveComplete
        {
            get { return _isSaveComplete; }
            private set { _isSaveComplete = value; OnPropertyChanged(); }
        }

        private double _saveProgress;
        public double SaveProgress
        {
            get { return _saveProgress; }
            private set { _saveProgress = value; OnPropertyChanged(); }
        }
        #endregion

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<LoginEvent>().Subscribe(OnLoginEvent);
        }

        private void OnLoginEvent(LoginEventArgs arg)
        {
            if (arg != null)
            {
                switch (arg.ActionType)
                {
                    case "Login":
                        {
                            this.Name = IdentityUtility.GetLoggedInName();
                            this.UserName = IdentityUtility.GetLoggedInUserName();
                            this.Role = IdentityUtility.GetLoggedInUserRole();
                            this.IsLoggedIn = Visibility.Visible;
                            break;
                        }
                    case "SignUp":
                        {
                            break;
                        }
                    case "Logout":
                        {
                            this.Name = "Anonymous";
                            this.UserName = "Anonymous";
                            this.Role = "NIL";
                            this.IsLoggedIn = Visibility.Collapsed;
                            break;
                        }
                }
            }
        }
        #endregion
    }
}
