using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class QuotationSummaryViewModel : ViewModelBase
    {
        private CreateQuotationViewModel parentViewModel = null;

        public QuotationSummaryViewModel(CreateQuotationViewModel parentViewModel)
        {
            this.parentViewModel = parentViewModel;
            this.IntializeCommands();
        }


        #region Commands
        private void IntializeCommands()
        {
            this.EditOwnerCommand = new RelayCommand(this.ExecuteEditOwnerCommand, this.CanExecuteEditOwnerCommand);
            this.PrintQuotationCommand = new RelayCommand(this.ExecutePrintQuotationCommand, this.CanExecutePrintQuotationCommand);
        }

        public ICommand EditOwnerCommand { get; private set; }

        public bool CanExecuteEditOwnerCommand()
        {
            return true;
        }

        public void ExecuteEditOwnerCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.DialogPopupRegion, WindowNames.MotorAddOwnerDetail);
        }

        public ICommand PrintQuotationCommand { get; private set; }

        public bool CanExecutePrintQuotationCommand()
        {
            return true;
        }

        public void ExecutePrintQuotationCommand()
        {
        }
        #endregion Commands

        #region Properties

        public QuotationViewModel QuotationViewModel
        {
            get { return this.parentViewModel.QuotationViewModel; }
            set
            {
                this.parentViewModel.QuotationViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties
    }
}
