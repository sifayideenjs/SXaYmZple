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

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class AddVehicleDetailViewModel : ViewModelBase
    {
        public AddVehicleDetailViewModel()
        {
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.AddVehicleCommand = new DelegateCommand(this.ExecuteAddVehicleCommand, this.CanExecuteAddVehicleCommand);
            this.PreviousCommand = new DelegateCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
            this.NextCommand = new DelegateCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand AddVehicleCommand { get; private set; }

        public bool CanExecuteAddVehicleCommand()
        {
            return true;
        }

        public void ExecuteAddVehicleCommand()
        {
            this.EventAggregator.GetEvent<AddVehicleEvent>().Publish(new AddVehicleEventArgs
            {
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
                Source = WindowNames.MotorAddOwnerDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            return true;
        }

        public void ExecuteNextCommand()
        {
            this.EventAggregator.GetEvent<NextEvent>().Publish(new NextEventArgs
            {
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorSummaryDetail
            });
        }
        #endregion Commands
    }
}
