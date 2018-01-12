using Prism.Commands;
using Quotation.Infrastructure.Base;
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
        }

        #region Commands
        private void IntializeCommands()
        {
            this.CreateOwnerCommand = new DelegateCommand(this.ExecuteCreateOwnerCommand, this.CanExecuteCreateOwnerCommand);
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
    }
}
