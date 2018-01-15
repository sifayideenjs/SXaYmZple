using Prism.Commands;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.MotorInsuranceModule.Events;
using Quotation.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class RecentQuotationViewModel : ViewModelBase
    {
        public RecentQuotationViewModel()
        {
            Initializate();
            this.IntializeCommands();
        }

        public QuotationsViewModel QuotationsViewModel { get; set; }

        private void Initializate()
        {
            var quotations = new List<MIQuotation>();
#if DEBUG
            quotations.Add(new MIQuotation() { NRIC = "XXX-YYY", InsuranceQtnNo = "123456" });
#endif
            //var quotationViewModels = new ObservableCollection<QuotationViewModel>(quotations.Select(q => new QuotationViewModel(q)));

            //QuotationsViewModel = new QuotationsViewModel(quotationViewModels);
        }

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
        }
        #endregion Commands
    }
}
