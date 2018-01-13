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
    public class SearchQuotationViewModel : ViewModelBase
    {
        public SearchQuotationViewModel()
        {
            this.IntializeCommands();
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
        }
        #endregion Commands
    }
}
