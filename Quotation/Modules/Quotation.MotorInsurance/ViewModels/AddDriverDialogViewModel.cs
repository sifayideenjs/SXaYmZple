using MaterialDesignThemes.Wpf;
using Quotation.Infrastructure;
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
    class AddDriverDialogViewModel : ViewModelBase
    {
        private DriverDetailViewModel driverDetail = null;

        public AddDriverDialogViewModel(DriverDetailViewModel driverDetailViewModel)
        {
            this.driverDetail = driverDetailViewModel;
            IntializeCommands();
        }

        #region Properties
        public DriverDetailViewModel DriverDetail
        {
            get { return driverDetail; }
            set
            {
                driverDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.AddCommand = new RelayCommand(this.ExecuteAddCommand, this.CanExecuteAddCommand);
            this.CancelCommand = new RelayCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
        }

        public ICommand AddCommand { get; private set; }

        public bool CanExecuteAddCommand()
        {
            return this.DriverDetail.IsValid();
        }

        public void ExecuteAddCommand()
        {
            this.EventAggregator.GetEvent<AddDriverEvent>().Publish(new DriverEventArgs
            {
                DriverDetail =this.DriverDetail.Model
            });
            DialogHost.CloseDialogCommand.Execute(true, null);
        }

        public ICommand CancelCommand { get; private set; }

        public bool CanExecuteCancelCommand()
        {
            return true;
        }

        public void ExecuteCancelCommand()
        {
            DialogHost.CloseDialogCommand.Execute(false, null);
        }
        #endregion Commands
    }
}