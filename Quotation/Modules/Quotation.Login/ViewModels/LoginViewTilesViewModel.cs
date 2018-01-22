using Prism.Regions;
using Quotation.Core;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class LoginViewTilesViewModel : ViewModelBase
    {
        private Visibility canUserManagement = Visibility.Collapsed;

        public LoginViewTilesViewModel()
        {
            bool isAdministrator = IsUserAdministrator();
            this.CanUserManagement = isAdministrator ? Visibility.Visible : Visibility.Collapsed;

            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Properties
        public Visibility CanUserManagement
        {
            get { return canUserManagement; }
            set
            {
                canUserManagement = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.UserManagementCommand = new RelayCommand(this.ExecuteUserManagementCommand, this.CanExecuteUserManagementCommand);
        }

        public ICommand UserManagementCommand { get; private set; }

        public bool CanExecuteUserManagementCommand()
        {
            return true;
        }

        public void ExecuteUserManagementCommand()
        {
            //ClearRegions(RegionNames.MainRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.UserManagementView);
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
                            //if (arg.User != null)
                            //{
                            //    User user = arg.User;                                
                            //}

                            bool isAdministrator = IsUserAdministrator();
                            this.CanUserManagement = isAdministrator ? Visibility.Visible : Visibility.Collapsed;
                            break;
                        }
                    case "SignUp":
                        {
                            break;
                        }
                    case "Logout":
                        {
                            break;
                        }
                }
            }
        }

        private static bool IsUserAdministrator()
        {
            bool isAdministrator = false;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                isAdministrator = customPrincipal.IsInRole(RoleNames.Administrator);
            }

            return isAdministrator;
        }
        #endregion //EventAggregation

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