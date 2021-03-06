﻿using Prism.Regions;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Interfaces;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class ViewQuotationViewModel : ViewModelBase, INavigationAware
    {
        QuotationDb quotationDb = null;
        private string quotationNo = string.Empty;

        public ViewQuotationViewModel(QuotationDb quotationDb)
        {
            this.quotationDb = quotationDb;
            this.IntializeCommands();
            this.SubscribeEvents();
        }

        public QuotationViewModel QuotationViewModel { get; set; }

        public string QuotationNo
        {
            get
            {
                return quotationNo;
            }
            set
            {
                quotationNo = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
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

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            return true;
        }

        public void ExecutePrintQuotationCommand()
        {
            NavigationParameters navParameters = new NavigationParameters();
            navParameters.Add("ReportDataSet", this.QuotationViewModel.QuotationDataSet);

            this.RegionManager.RequestNavigate(RegionNames.MotorQuotationRegion, PopupNames.ReportModule_Motor, navParameters);
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<OpenQuotationEvent>().Unsubscribe(OnOpenQuotationEvent);
            this.EventAggregator.GetEvent<OpenQuotationEvent>().Subscribe(OnOpenQuotationEvent);
        }

        private void OnOpenQuotationEvent(QuotationEventArgs arg)
        {
            if(arg != null && arg.QuotationDataSet != null && arg.QuotationDataSet.Tables.Count == 4 && arg.QuotationDataSet.Tables[0].Rows.Count > 0)
            {
                QuotationViewModel = new QuotationViewModel(quotationDb, arg.QuotationDataSet);
                if (this.QuotationViewModel != null)
                {
                    string qNo = this.QuotationViewModel.CurrentInsuranceDetail.InsuranceQtnNo;
                    QuotationNo = string.Format("Quotation No : {0}", qNo);
                }
                ClearRegions(arg.RegionName);
                this.RegionManager.RequestNavigate(arg.RegionName, arg.Source);
            }
            else
            {

            }
        }
        #endregion //EventAggregation

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                //QuotationViewModel = new QuotationViewModel(quotationDb);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (navigationContext.NavigationService.Region.Name == RegionNames.MainRegion)
            {
                (QuotationViewModel as IViewModel).UnSubscribeEvents();
                QuotationViewModel = null;
            }
        }
        #endregion //INavigationAware

        private void ClearRegions(string regionName)
        {
            if (this.RegionManager.Regions.ContainsRegionWithName(regionName))
            {
                IRegion region = this.RegionManager.Regions[regionName];
                if (region != null)
                {
                    var views = region.Views;
                    foreach (var view in views)
                    {
                        region.Remove(view);
                    }
                }
            }
        }
    }
}
