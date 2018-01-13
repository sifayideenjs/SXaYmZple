using Prism.Commands;
using Quotation.Infrastructure.Base;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class AddInsuranceDetailViewModel : ViewModelBase
    {
        public AddInsuranceDetailViewModel()
        {
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.AddInsuranceCommand = new DelegateCommand(this.ExecuteAddInsuranceCommand, this.CanExecuteAddInsuranceCommand);
            this.PreviousCommand = new DelegateCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
            this.NextCommand = new DelegateCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand AddInsuranceCommand { get; private set; }

        public bool CanExecuteAddInsuranceCommand()
        {
            return true;
        }

        public void ExecuteAddInsuranceCommand()
        {
            this.EventAggregator.GetEvent<AddInsuranceEvent>().Publish(new AddInsuranceEventArgs
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
            });
        }
        #endregion Commands
    }
}
