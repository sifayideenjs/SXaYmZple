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
using Quotation.Core.Utilities;
using Quotation.MotorInsuranceModule.Constants;
using Quotation.Infrastructure.Utilities;
using Quotation.Infrastructure.Models;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class MotorInsuranceTilesViewModel : ViewModelBase
    {
        private string recentFileName = "MotorData.xml";
        private Visibility canNewProposal = Visibility.Collapsed;
        private Visibility canAddQuotation = Visibility.Collapsed;
        private Visibility canSearchQuotation = Visibility.Collapsed;

        public MotorInsuranceTilesViewModel()
        {
            this.InitializeUI();
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Properties
        public Visibility CanNewProposal
        {
            get { return canNewProposal; }
            set
            {
                canNewProposal = value;
                OnPropertyChanged();
            }
        }

        public Visibility CanAddQuotation
        {
            get { return canAddQuotation; }
            set
            {
                canAddQuotation = value;
                OnPropertyChanged();
            }
        }

        public Visibility CanSearchQuotation
        {
            get { return canSearchQuotation; }
            set
            {
                canSearchQuotation = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.NewProposalCommand = new RelayCommand(this.ExecuteNewProposalCommand, this.CanExecuteNewProposalCommand);
            this.AddQuotationCommand = new RelayCommand(this.ExecuteAddQuotationCommand, this.CanExecuteAddQuotationCommand);
            this.SearchQuotationCommand = new RelayCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.ExpiringQuotationCommand = new RelayCommand(this.ExecuteExpiringQuotationCommand, this.CanExecuteExpiringQuotationCommand);
        }

        public ICommand NewProposalCommand { get; private set; }
        public ICommand AddQuotationCommand { get; private set; }
        public ICommand SearchQuotationCommand { get; private set; }
        public ICommand ExpiringQuotationCommand { get; private set; }

        public bool CanExecuteNewProposalCommand()
        {
            return true;
        }

        public void ExecuteNewProposalCommand()
        {
            ClearRegions(RegionNames.MotorWizardRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorNewProposal);
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddOwnerDetail);
        }

        public bool CanExecuteAddQuotationCommand()
        {
            return true;
        }

        public void ExecuteAddQuotationCommand()
        {
            ClearRegions(RegionNames.MotorWizardRegion);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorCreateQuotation);
            //this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddOwnerDetail);
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
            ClearRegions(RegionNames.MainRegion);
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
                            InitializeUI();
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
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorNewProposal);
        }
        #endregion //EventAggregation

        private void InitializeUI()
        {
            bool isNewProposalAccessible = IdentityUtility.IsFormAccessible(FormNames.NEW_PROPOSAL);
            bool isAddQuotationAccessible = IdentityUtility.IsFormAccessible(FormNames.ADD_QUOTATION);
            bool isSearchQuotationAccessible = IdentityUtility.IsFormAccessible(FormNames.SEARCH_QUOTATION);
            
            this.CanNewProposal = isNewProposalAccessible ? Visibility.Visible : Visibility.Collapsed;
            this.CanAddQuotation = isAddQuotationAccessible ? Visibility.Visible : Visibility.Collapsed;
            this.CanSearchQuotation = isSearchQuotationAccessible ? Visibility.Visible : Visibility.Collapsed;
        }

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