using Prism.Commands;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class CreateQuotationViewModel : ViewModelBase
    {
        public CreateQuotationViewModel()
        {
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new DelegateCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.CreateOwnerCommand = new DelegateCommand(this.ExecuteCreateOwnerCommand, this.CanExecuteCreateOwnerCommand);
        }

        public ICommand DashboardCommand { get; private set; }

        public bool CanExecuteDashboardCommand()
        {
            return true;
        }

        public void ExecuteDashboardCommand()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Publish(new DashboardEventArgs
            {
            });
        }

        public ICommand CreateOwnerCommand { get; private set; }

        public bool CanExecuteCreateOwnerCommand()
        {
            return true;
        }

        public void ExecuteCreateOwnerCommand()
        {
            this.EventAggregator.GetEvent<CreateDriverEvent>().Publish(new CreateDriverEventArgs
            {
           });
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<CancelEvent>().Subscribe(OnCancelEvent);
            this.EventAggregator.GetEvent<PreviousEvent>().Subscribe(OnPreviousEvent);
            this.EventAggregator.GetEvent<NextEvent>().Subscribe(OnNextEvent);

            this.EventAggregator.GetEvent<AddOwnerEvent>().Subscribe(OnAddOwnerView);
            this.EventAggregator.GetEvent<AddVehicleEvent>().Subscribe(OnAddVehicleView);
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Subscribe(OnAddInsuranceView);
        }

        private void OnCancelEvent(CancelEventArgs arg)
        {
            ExecuteDashboardCommand();
        }

        private void OnPreviousEvent(PreviousEventArgs arg)
        {
            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
        }

        private void OnNextEvent(NextEventArgs arg)
        {
            this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
        }

        private void OnAddOwnerView(AddOwnerEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddVehicleDetail);
        }

        private void OnAddVehicleView(AddVehicleEventArgs arg)
        {
            //this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddInsuranceDetail);
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorSummaryDetail);
        }

        private void OnAddInsuranceView(AddInsuranceEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorSummaryDetail);
        }
        #endregion //EventAggregation
    }
}
