using Prism.Commands;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class AddInsuranceDetailViewModel : ViewModelBase
    {
        private CreateQuotationViewModel parentViewModel = null;

        public AddInsuranceDetailViewModel(CreateQuotationViewModel parentViewModel)
        {
            this.parentViewModel = parentViewModel;
            this.InsuranceDetails = new ObservableCollection<InsuranceDetailViewModel>();
#if DEBUG
            DataAccess.Models.MIQuotation insuranceDetail = new DataAccess.Models.MIQuotation()
            {
                InsuranceExpiryDate = new DateTime(2019, 01, 14),
                InsuranceRenewalDate = new DateTime(2019, 01, 14),
                RoadTaxExpiryDate = new DateTime(2020, 01, 14),
                RoadTaxRenewalDate = new DateTime(2020, 01, 14),
                PreviousDealer = "CAR HOUSE",
                Agency = "MDIVINE",
                FinanceBank = "MAYBANK",
                PrevYearPremium = "NIL"
            };
            this.CurrentInsuranceDetails = new InsuranceDetailViewModel(insuranceDetail);
#else            
            this.CurrentInsuranceDetails = new InsuranceDetailViewModel(new MIQuotation());
#endif
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.AddInsuranceCommand = new RelayCommand(this.ExecuteAddInsuranceCommand, this.CanExecuteAddInsuranceCommand);
            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
            this.NextCommand = new RelayCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand AddInsuranceCommand { get; private set; }

        public bool CanExecuteAddInsuranceCommand()
        {
            if (this.CurrentInsuranceDetails.IsValid())
            {
                return true;
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
                InsuranceDetail = this.CurrentInsuranceDetails.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorSummaryDetail
            });
        }
        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            if (this.CurrentInsuranceDetails.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecutePreviousCommand()
        {
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Publish(new InsuranceEventArgs
            {
                InsuranceDetail = this.CurrentInsuranceDetails.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddVehicleDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            if (this.CurrentInsuranceDetails.IsValid())
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
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Publish(new InsuranceEventArgs
            {
                InsuranceDetail = this.CurrentInsuranceDetails.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorSummaryDetail
            });
        }
        #endregion Commands

        #region Properties
        public ObservableCollection<InsuranceDetailViewModel> InsuranceDetails
        {
            get { return this.parentViewModel.QuotationViewModel.InsuranceDetails; }
            set
            {
                this.parentViewModel.QuotationViewModel.InsuranceDetails = value;
                OnPropertyChanged();
            }
        }

        public InsuranceDetailViewModel CurrentInsuranceDetails
        {
            get { return this.parentViewModel.QuotationViewModel.CurrentInsuranceDetail; }
            set
            {
                this.parentViewModel.QuotationViewModel.CurrentInsuranceDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties
    }
}
