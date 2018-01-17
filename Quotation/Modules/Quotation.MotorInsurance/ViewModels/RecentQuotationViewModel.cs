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
using System.Data;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class RecentQuotationViewModel : ViewModelBase
    {
        QuotationDb quotationDb = null;
        private ObservableCollection<OwnerDetailViewModel> quotations;
        //private OwnerDetailViewModel selectedQuotation;

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

        //public OwnerDetailViewModel SelectedQuotation
        //{
        //    get
        //    {
        //        return selectedQuotation;
        //    }
        //    set
        //    {
        //        selectedQuotation = value;
        //        OnPropertyChanged();
        //    }
        //}

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.OpenQuotationCommand = new RelayCommand<OwnerDetailViewModel>(this.ExecuteOpenQuotationCommand, this.CanExecuteOpenQuotationCommand);
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

        public ICommand OpenQuotationCommand { get; private set; }

        public bool CanExecuteOpenQuotationCommand(OwnerDetailViewModel quotation)
        {
            return true;
        }

        public async void ExecuteOpenQuotationCommand(OwnerDetailViewModel quotation)
        {
            string errorMessage = string.Empty;
            string quotationNo = "1234567";
            //DataSet quotationDataSet = quotationDb.GetNRICDetails(nric, out errorMessage);

            DataSet quotationDataSet = quotationDb.GetMIQuoationDetails(quotationNo, out errorMessage);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Proposal", errorMessage);
                return;
            }
            else
            {
                this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorViewQuotation);
                this.EventAggregator.GetEvent<OpenQuotationEvent>().Publish(new QuotationEventArgs
                {
                    QuotationDataSet = quotationDataSet,
                    RegionName = RegionNames.MotorQuotationRegion,
                    Source = WindowNames.MotorSummaryDetail
                });
            }
        }
        #endregion Commands
    }
}
