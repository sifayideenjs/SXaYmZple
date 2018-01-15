using Prism.Commands;
using Prism.Regions;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using Quotation.DataAccess.Models;
using Quotation.MotorInsuranceModule.ViewModels.CreateWizards;
using Quotation.MotorInsuranceModule.ViewModels.Wizards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quotation.DataAccess;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class CreateQuotationViewModel : ViewModelBase, IRegionMemberLifetime
    {
        QuotationDb quotationDb = null;

        public CreateQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();
            this.SubscribeEvents();

            QuotationViewModel = new QuotationViewModel(quotationDb);

            AddOwnerDetailViewModel = new AddOwnerDetailViewModel(this);
            AddDriverDetailViewModel = new AddDriverDetailViewModel(this);
            AddVehicleDetailViewModel = new AddVehicleDetailViewModel(this);
            AddInsuranceDetailViewModel = new AddInsuranceDetailViewModel(this);
            QuotationSummaryViewModel = new QuotationSummaryViewModel(this);
        }
        public bool KeepAlive
        {
            get { return false; }
        }

        public QuotationViewModel QuotationViewModel { get; set; }

        public AddOwnerDetailViewModel AddOwnerDetailViewModel { get; set; }
        public AddDriverDetailViewModel AddDriverDetailViewModel { get; set; }
        public AddVehicleDetailViewModel AddVehicleDetailViewModel { get; set; }
        public AddInsuranceDetailViewModel AddInsuranceDetailViewModel { get; set; }
        public QuotationSummaryViewModel QuotationSummaryViewModel { get; set; }


        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.CreateOwnerCommand = new RelayCommand(this.ExecuteCreateOwnerCommand, this.CanExecuteCreateOwnerCommand);
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
            this.EventAggregator.GetEvent<CreateOwnerEvent>().Publish(new CreateOwnerEventArgs
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
        #endregion //EventAggregation
    }
}
