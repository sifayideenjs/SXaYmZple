using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Quotation.Core;
using System.Threading;
using System.Windows;
using Quotation.Infrastructure.Events;
using System;
using Quotation.Infrastructure.Models;
using Quotation.Infrastructure;

namespace Quotation.LoginModule.ViewModels
{
    public class RightTitlebarViewModel : ViewModelBase
    {
        private string username = string.Empty;
        private Visibility canUserSignUp = Visibility.Visible;
        private Visibility canUserLogout = Visibility.Collapsed;

        public RightTitlebarViewModel()
        {
            SubscribeEvents();
            IntializeCommands();
        }

        #region Properties
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public Visibility CanUserSignUp
        {
            get { return canUserSignUp; }
            set
            {
                canUserSignUp = value;
                OnPropertyChanged();
            }
        }

        public Visibility CanUserLogout
        {
            get { return canUserLogout; }
            set
            {
                canUserLogout = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.LogoutCommand = new RelayCommand(this.ExecuteLogoutCommand, this.CanExecuteLogoutCommand);
        }

        public ICommand LogoutCommand { get; private set; }

        public bool CanExecuteLogoutCommand()
        {
            return true;
        }

        public void ExecuteLogoutCommand()
        {
            this.EventAggregator.GetEvent<LoginEvent>().Publish(new LoginEventArgs
            {
                User = null,
                ActionType = "Logout"
            });
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.LoginView);
        }
        #endregion Commands

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
                            if (arg.User != null)
                            {
                                User user = arg.User;
                                this.Username = user.Name;

                                this.CanUserSignUp = Visibility.Collapsed;
                                this.CanUserLogout = Visibility.Visible;
                            }
                            break;
                        }
                    case "SignUp":
                        {
                            break;
                        }
                    case "Logout":
                        {
                            this.CanUserSignUp = Visibility.Visible;
                            this.CanUserLogout = Visibility.Collapsed;
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}
