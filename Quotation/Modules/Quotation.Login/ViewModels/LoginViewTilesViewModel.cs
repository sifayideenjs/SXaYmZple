using Prism.Regions;
using Quotation.Core;
using Quotation.Core.Utilities;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.LoginModule.Constants;
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
        private Visibility canGroupManagement = Visibility.Collapsed;

        public LoginViewTilesViewModel()
        {
            this.InitializeUI();
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

        public Visibility CanGroupManagement
        {
            get { return canGroupManagement; }
            set
            {
                canGroupManagement = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.UserManagementCommand = new RelayCommand(this.ExecuteUserManagementCommand, this.CanExecuteUserManagementCommand);
            this.GroupManagementCommand = new RelayCommand(this.ExecuteGroupManagementCommand, this.CanExecuteUserManagementCommand);
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

        public ICommand GroupManagementCommand { get; private set; }

        public bool CanExecuteGroupManagementCommand()
        {
            return true;
        }

        public void ExecuteGroupManagementCommand()
        {
            //ClearRegions(RegionNames.MainRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.GroupManagementView);
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
                            this.InitializeUI();
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

        private void InitializeUI()
        {
            bool isGroupManagementAccessible = IdentityUtility.IsFormAccessible(FormNames.GROUP_MANAGEMENT);
            bool isUserManagementAccessible = IdentityUtility.IsFormAccessible(FormNames.USER_MANAGEMENT);

            this.CanGroupManagement = isGroupManagementAccessible ? Visibility.Visible : Visibility.Collapsed;
            this.CanUserManagement = isUserManagementAccessible ? Visibility.Visible : Visibility.Collapsed;
        }

        //private static bool IsSuperAdministrator()
        //{
        //    bool isSuperAdministrator = false;
        //    CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
        //    if (customPrincipal != null)
        //    {
        //        isSuperAdministrator = customPrincipal.IsInRole(RoleNames.SuperAdministrator);
        //    }

        //    return isSuperAdministrator;
        //}
        #endregion //EventAggregation

        #region IRegion
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
        #endregion //IRegion
    }
}