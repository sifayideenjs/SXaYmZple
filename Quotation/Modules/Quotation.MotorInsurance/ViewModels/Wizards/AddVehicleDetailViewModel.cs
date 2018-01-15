using Prism.Commands;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class AddVehicleDetailViewModel : ViewModelBase
    {
        private CreateQuotationViewModel parentViewModel = null;

        public AddVehicleDetailViewModel(CreateQuotationViewModel parentViewModel)
        {
            this.parentViewModel = parentViewModel;
#if DEBUG
            DataAccess.Models.VehicleDetail vehicleDetail = new DataAccess.Models.VehicleDetail()
            {
                Make = "TOYOTA COROLLA",
                Model = "AXIO 1.5XA",
                YearMade = "2007",
                Capacity = "1496CC",
                DateOfRegistered = DateTime.Now,
                RegNo = "SGY9152X",
                PreviousRegNo = "SGY9152X",
                ParallelImport = 1,
                OffPeakVehicle = 0,
                NCD = "10% EISTING",
                ExistingInsurer = "AXA",
                Claims = string.Empty
            };

            this.VehicleDetail = new VehicleDetailViewModel(vehicleDetail);
#else
            this.VehicleDetail = new VehicleDetailViewModel(new DataAccess.Models.VehicleDetail());
#endif
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.AddVehicleCommand = new RelayCommand(this.ExecuteAddVehicleCommand, this.CanExecuteAddVehicleCommand);
            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
            this.NextCommand = new RelayCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand AddVehicleCommand { get; private set; }

        public bool CanExecuteAddVehicleCommand()
        {
            if (this.VehicleDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddVehicleCommand()
        {
            this.EventAggregator.GetEvent<AddVehicleEvent>().Publish(new VehicleEventArgs
            {
                VehicleDetail = this.VehicleDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddInsuranceDetail
            });
        }

        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            if (this.VehicleDetail.IsValid())
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
            this.EventAggregator.GetEvent<AddVehicleEvent>().Publish(new VehicleEventArgs
            {
                VehicleDetail = this.VehicleDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddDriverDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            if (this.VehicleDetail.IsValid())
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
            this.EventAggregator.GetEvent<AddVehicleEvent>().Publish(new VehicleEventArgs
            {
                VehicleDetail = this.VehicleDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddInsuranceDetail
            });
        }
        #endregion Commands

        #region Properties
        public VehicleDetailViewModel VehicleDetail
        {
            get { return this.parentViewModel.QuotationViewModel.VehicleDetail; }
            set
            {
                this.parentViewModel.QuotationViewModel.VehicleDetail = value;
                OnPropertyChanged();
            }
        }

        public bool IsVehicalUpdated
        {
            get { return this.parentViewModel.QuotationViewModel.IsVehicalUpdated; }
            set
            {
                this.parentViewModel.QuotationViewModel.IsVehicalUpdated = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties
    }
}
