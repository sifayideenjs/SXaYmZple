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

            //AddOwnerDetailViewModel = new AddOwnerDetailViewModel(this);
            //AddDriverDetailViewModel = new AddDriverDetailViewModel(this);
            //AddVehicleDetailViewModel = new AddVehicleDetailViewModel(this);
            //AddInsuranceDetailViewModel = new AddInsuranceDetailViewModel(this);
            //QuotationSummaryViewModel = new QuotationSummaryViewModel(this);
        }
        public bool KeepAlive
        {
            get { return false; }
        }

        public QuotationViewModel QuotationViewModel { get; set; }

        //public AddOwnerDetailViewModel AddOwnerDetailViewModel { get; set; }
        //public AddDriverDetailViewModel AddDriverDetailViewModel { get; set; }
        //public AddVehicleDetailViewModel AddVehicleDetailViewModel { get; set; }
        //public AddInsuranceDetailViewModel AddInsuranceDetailViewModel { get; set; }
        //public QuotationSummaryViewModel QuotationSummaryViewModel { get; set; }


        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);

            this.CancelCommand = new RelayCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
            this.AddOwnerCommand = new RelayCommand(this.ExecuteAddOwnerCommand, this.CanExecuteAddOwnerCommand);
            this.NextCommand = new RelayCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);

            this.AddInsuranceCommand = new RelayCommand(this.ExecuteAddInsuranceCommand, this.CanExecuteAddInsuranceCommand);
            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
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

        public ICommand CancelCommand { get; private set; }

        public bool CanExecuteCancelCommand()
        {
            return true;
        }

        public void ExecuteCancelCommand()
        {
            this.EventAggregator.GetEvent<CancelEvent>().Publish(new Events.CancelEventArgs
            {
            });
        }

        public ICommand AddOwnerCommand { get; private set; }

        public bool CanExecuteAddOwnerCommand()
        {
            if (this.QuotationViewModel.OwnerDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddOwnerCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new OwnerEventArgs
            {
                OwnerDetail = this.QuotationViewModel.OwnerDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddDriverDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            if (this.QuotationViewModel.OwnerDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteNextCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new OwnerEventArgs
            {
                OwnerDetail = this.QuotationViewModel.OwnerDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddDriverDetail
            });
        }

        public ICommand AddInsuranceCommand { get; private set; }

        public bool CanExecuteAddInsuranceCommand()
        {
            if (this.QuotationViewModel.VehicleDetail.IsValid() && this.QuotationViewModel.CurrentInsuranceDetail.IsValid())
            {
                bool isValid = true;
                //foreach (var dDetail in this.QuotationViewModel.DriverDetails)
                //{
                //    if (dDetail.IsValid() == false)
                //    {
                //        isValid = false;
                //    }
                //}

                return isValid;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddInsuranceCommand()
        {
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Publish(new InsuranceEventArgs
            {
                VehicleDetail = this.QuotationViewModel.VehicleDetail.Model,
                InsuranceDetail = this.QuotationViewModel.CurrentInsuranceDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorSummaryDetail
            });
        }
        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            return true;
        }

        public void ExecutePreviousCommand()
        {
            this.EventAggregator.GetEvent<PreviousEvent>().Publish(new PreviousEventArgs
            {
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddVehicleDetail
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
