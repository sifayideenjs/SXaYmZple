using Prism.Commands;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class QuotationsViewModel : ViewModelBase
    {
        private ObservableCollection<QuotationViewModel> quotations = new ObservableCollection<QuotationViewModel>();
        private QuotationViewModel selectedQuotation;

        public QuotationsViewModel(ObservableCollection<QuotationViewModel> quotations)
        {
            this.Quotations = quotations;
            IntializeCommands();
        }

        public ObservableCollection<QuotationViewModel> Quotations
        {
            get { return quotations; }
            set
            {
                quotations = value;
                OnPropertyChanged();
            }
        }

        public QuotationViewModel SelectedQuotation
        {
            get { return selectedQuotation; }
            set
            {
                if (Equals(value, selectedQuotation)) return;
                selectedQuotation = value;
                OnPropertyChanged();
            }
        }

        private void IntializeCommands()
        {
            this.NewQuotationCommand = new RelayCommand(this.ExecuteNewQuotationCommand, this.CanExecuteNewQuotationCommand);
            this.EditQuotationCommand = new RelayCommand(this.ExecuteEditQuotationCommand, this.CanExecuteEditQuotationCommand);
            this.DeleteQuotationCommand = new RelayCommand(this.ExecuteDeleteQuotationCommand, this.CanExecuteDeleteQuotationCommand);
        }

        public ICommand NewQuotationCommand { get; set; }
        public ICommand EditQuotationCommand { get; set; }
        public ICommand DeleteQuotationCommand { get; set; }

        public bool CanExecuteNewQuotationCommand()
        {
            return true;
        }

        public void ExecuteNewQuotationCommand()
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.MotorCreateQuotation);
            this.RegionManager.RequestNavigate(RegionNames.MotorWizardRegion, WindowNames.MotorAddOwnerDetail);
        }

        public bool CanExecuteEditQuotationCommand()
        {
            //if (SelectedQuotation != null) return true;
            //else return false;
            return true;
        }

        public void ExecuteEditQuotationCommand()
        {
        }

        public bool CanExecuteDeleteQuotationCommand()
        {
            //if (SelectedQuotation != null) return true;
            //else return false;
            return true;
        }

        public void ExecuteDeleteQuotationCommand()
        {
            Quotations.Remove(selectedQuotation);
            SelectedQuotation = null;
        }
    }
}
