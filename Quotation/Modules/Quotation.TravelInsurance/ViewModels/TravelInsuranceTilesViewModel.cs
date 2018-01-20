using Prism.Commands;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Quotation.Infrastructure;

namespace Quotation.TravelInsuranceModule.ViewModels
{
    public class TravelInsuranceTilesViewModel : ViewModelBase
    {
        public TravelInsuranceTilesViewModel()
        {
            //this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.CreateQuotationCommand = new RelayCommand(this.ExecuteCreateQuotationCommand, this.CanExecuteCreateQuotationCommand);
            this.RecentQuotationCommand = new RelayCommand(this.ExecuteRecentQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.SearchQuotationCommand = new RelayCommand(this.ExecuteSearchQuotationCommand, this.CanExecuteSearchQuotationCommand);
            this.ExpiringQuotationCommand = new RelayCommand(this.ExecuteExpiringQuotationCommand, this.CanExecuteExpiringQuotationCommand);
        }

        public ICommand CreateQuotationCommand { get; private set; }
        public ICommand RecentQuotationCommand { get; private set; }
        public ICommand SearchQuotationCommand { get; private set; }
        public ICommand ExpiringQuotationCommand { get; private set; }

        public bool CanExecuteCreateQuotationCommand()
        {
            return true;
        }

        public void ExecuteCreateQuotationCommand()
        {
           // this.RegionManager.RequestNavigate(RegionNames.SubMainRegion, PopupNames.ModuleAPopup);
        }

        public bool CanExecuteRecentQuotationCommand()
        {
            return true;
        }

        public void ExecuteRecentQuotationCommand()
        {
            this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Module A Message", "This is a message from Module A");
        }

        public bool CanExecuteSearchQuotationCommand()
        {
            return true;
        }

        public void ExecuteSearchQuotationCommand()
        {
            //this.RegionManager.RequestNavigate(RegionNames.SubMainRegion, PopupNames.ModuleAPopup);
        }

        public bool CanExecuteExpiringQuotationCommand()
        {
            return true;
        }

        public void ExecuteExpiringQuotationCommand()
        {
            this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Module A Message", "This is a message from Module A");
        }
        #endregion Commands
    }
}
