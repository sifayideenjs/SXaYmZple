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
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Utilities;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using Quotation.Infrastructure.Models;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class RecentQuotationViewModel : ViewModelBase
    {
        QuotationDb quotationDb = null;
        private string recentFileName = "MotorData.xml";
        private ObservableCollection<RecentItemViewModel> recentItems;

        public RecentQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.Initializate();
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        #region Properties
        public ObservableCollection<RecentItemViewModel> RecentItems
        {
            get
            {
                return recentItems;
            }
            set
            {
                recentItems = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.OpenQuotationCommand = new RelayCommand<RecentItemViewModel>(this.ExecuteOpenQuotationCommand, this.CanExecuteOpenQuotationCommand);
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

        public bool CanExecuteOpenQuotationCommand(RecentItemViewModel recentItem)
        {
            return true;
        }

        public async void ExecuteOpenQuotationCommand(RecentItemViewModel recentItem)
        {
            string errorMessage = string.Empty;
            string quotationNo = recentItem.Model.QuotationNo;
            //DataSet quotationDataSet = quotationDb.GetNRICDetails(nric, out errorMessage);

            DataSet quotationDataSet = quotationDb.GetMIQuoationDetails(quotationNo, out errorMessage);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Open Recent Item", errorMessage);
                return;
            }
            else if(quotationDataSet != null && quotationDataSet.Tables.Count == 4 && quotationDataSet.Tables[0].Rows.Count > 0)
            {
                this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorViewQuotation);
                this.EventAggregator.GetEvent<OpenQuotationEvent>().Publish(new QuotationEventArgs
                {
                    QuotationDataSet = quotationDataSet,
                    RegionName = RegionNames.MotorQuotationRegion,
                    Source = WindowNames.MotorSummaryDetail
                });
            }
            else
            {
                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Open Recent Item", "Quotation record does not exist");
                return;
            }
        }
        #endregion Commands

        #region Methods
        private void Initializate()
        {
            //string errorMessage = string.Empty;
            //var ownerDetails = this.quotationDb.GetAllOwnerDetails(out errorMessage);
            //this.Quotations = new ObservableCollection<OwnerDetailViewModel>(ownerDetails.Select(q => new OwnerDetailViewModel(q)));

            recentItems = new ObservableCollection<RecentItemViewModel>();
            var recentListModel = RecentListUtility.ReadRecentList(recentFileName);
            if (recentListModel != null)
            {
                this.RecentItems = new ObservableCollection<RecentItemViewModel>(recentListModel.RecentList.Select(ri => new RecentItemViewModel(ri)));
            }
        }
        #endregion //Methods

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<NewQuotationEvent>().Subscribe(OnNewQuotationEvent);
        }

        private void OnNewQuotationEvent(QuotationEventArgs arg)
        {
            if (arg != null && arg.QuotationDataSet != null && arg.QuotationDataSet.Tables.Count == 5)
            {
                var recentItem = new RecentItem() { OwnerName = arg.OwnerName, NRIC = arg.NRICNumber, QuotationNo = arg.QuotationNumber, CreatedDateTime = DateTime.Now, IsAvailable = true };
                RecentListUtility.AddRecentData(recentItem, recentFileName);

                if(this.RecentItems.Count == 0) this.RecentItems.Add(new RecentItemViewModel(recentItem));
                else if (this.RecentItems.Count > 0) this.RecentItems.Insert(0, new RecentItemViewModel(recentItem));
            }
        }
        #endregion //EventAggregation
    }

    public class RecentItemViewModel
    {
        private RecentItem model = null;
        public RecentItemViewModel(RecentItem model)
        {
            this.model = model;
        }

        public RecentItem Model
        {
            get { return this.model; }
        }
    }
}
