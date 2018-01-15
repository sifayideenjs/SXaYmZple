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
using Quotation.DataAccess;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class RecentQuotationViewModel : ViewModelBase
    {
        QuotationDb quotationDb = null;
        private ObservableCollection<OwnerDetailViewModel> quotations;

        public RecentQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            Initializate();
            this.IntializeCommands();
        }

        public QuotationsViewModel QuotationsViewModel { get; set; }

        private void Initializate()
        {
            string errorMessage = string.Empty;
            var ownerDetails = this.quotationDb.GetAllOwnerDetails(out errorMessage);
            this.Quotations = new ObservableCollection<OwnerDetailViewModel>(ownerDetails.Select(q => new OwnerDetailViewModel(q)));
        }

        public ObservableCollection<OwnerDetailViewModel> Quotations
        {
            get
            {
                return quotations;
            }
            set
            {
                quotations = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
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
        #endregion Commands
    }
}
