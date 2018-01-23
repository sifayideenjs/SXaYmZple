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
using Quotation.MotorInsuranceModule.Events;
using Prism.Regions;
using Quotation.Infrastructure;
using System.Threading;
using Quotation.Core;
using System.Windows;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Models;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class MotorInsuranceTilesViewModel : ViewModelBase
    {
        private Visibility canUserManagement = Visibility.Collapsed;

        public MotorInsuranceTilesViewModel()
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
            this.CreateQuotationCommand = new RelayCommand(this.ExecuteCreateQuotationCommand, this.CanExecuteCreateQuotationCommand);
            this.RecentQuotationCommand = new RelayCommand(this.ExecuteRecentQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.SearchQuotationCommand = new RelayCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.ExpiringQuotationCommand = new RelayCommand(this.ExecuteExpiringQuotationCommand, this.CanExecuteExpiringQuotationCommand);
        }

        public ICommand CreateQuotationCommand { get; private set; }
        public ICommand RecentQuotationCommand { get; private set; }
        public ICommand SearchQuotationCommand { get; private set; }
        public ICommand ExpiringQuotationCommand { get; private set; }

        public bool CanExecuteCreateQuotationCommand()
        {
            return true;
        }

        public void ExecuteCreateQuotationCommand()
        {
            ClearRegions(RegionNames.MotorWizardRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorCreateQuotation);
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddOwnerDetail);
        }

        public bool CanExecuteRecentQuotationCommand()
        {
            return true;
        }
        
        public void ExecuteRecentQuotationCommand()
        {
            ClearRegions(RegionNames.MotorWizardRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorRecentQuotation);
        }

        public bool CanExecuteSearchQuotationCommand()
        {
            return true;
        }

        public void ExecuteSearchQuotationCommand()
        {
            ClearRegions(RegionNames.MotorSearchRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorSearchQuotation);
        }

        public bool CanExecuteExpiringQuotationCommand()
        {
            return true;
        }

        public void ExecuteExpiringQuotationCommand()
        {
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<LoginEvent>().Subscribe(OnLoginEvent);
            this.EventAggregator.GetEvent<CreateOwnerEvent>().Subscribe(OnCreateOwnerView);
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

        private void OnCreateOwnerView(CreateOwnerEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorCreateQuotation);
        }
        #endregion //EventAggregation

        private void ClearRegions(string regionName)
        {
            if(this.RegionManager.Regions.ContainsRegionWithName(regionName))
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