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
    public class AddOwnerDetailViewModel : ViewModelBase
    {
        public AddOwnerDetailViewModel()
        {
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.CancelCommand = new DelegateCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
            this.AddOwnerCommand = new DelegateCommand(this.ExecuteAddOwnerCommand, this.CanExecuteAddOwnerCommand);
            this.NextCommand = new DelegateCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand CancelCommand { get; private set; }

        public bool CanExecuteCancelCommand()
        {
            return true;
        }

        public void ExecuteCancelCommand()
        {
            this.EventAggregator.GetEvent<CancelEvent>().Publish(new CancelEventArgs
            {
            });
        }

        public ICommand AddOwnerCommand { get; private set; }

        public bool CanExecuteAddOwnerCommand()
        {
            return true;
        }

        public void ExecuteAddOwnerCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new AddOwnerEventArgs
            {
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
                Source = WindowNames.MotorAddVehicleDetail
            });
        }
        #endregion Commands
    }
}
