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

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class MotorInsuranceTilesViewModel : ViewModelBase
    {
        public MotorInsuranceTilesViewModel()
        {
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.CreateQuotationCommand = new DelegateCommand(this.ExecuteCreateQuotationCommand, this.CanExecuteCreateQuotationCommand);
            this.RecentQuotationCommand = new DelegateCommand(this.ExecuteRecentQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.SearchQuotationCommand = new DelegateCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.ExpiringQuotationCommand = new DelegateCommand(this.ExecuteExpiringQuotationCommand, this.CanExecuteExpiringQuotationCommand);
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
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorCreateQuotation);
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddOwnerDetail);
        }        

        public bool CanExecuteRecentQuotationCommand()
        {
            return true;
        }
        
        public void ExecuteRecentQuotationCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorRecentQuotation);
        }

        public bool CanExecuteSearchQuotationCommand()
        {
            return true;
        }

        public void ExecuteSearchQuotationCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorSearchQuotation);
        }

        public bool CanExecuteExpiringQuotationCommand()
        {
            return true;
        }

        public void ExecuteExpiringQuotationCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorExpiringQuotation);
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Subscribe(OnDashboardView);
            this.EventAggregator.GetEvent<CreateDriverEvent>().Subscribe(OnCreateDriverView);
        }

        private void OnCreateDriverView(CreateDriverEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorRecentQuotation);
        }

        private void OnDashboardView(DashboardEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
        }
        #endregion //EventAggregation
    }
}