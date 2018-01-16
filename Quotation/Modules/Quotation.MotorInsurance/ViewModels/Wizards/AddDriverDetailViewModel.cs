using Prism.Commands;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.CreateWizards
{
    public class AddDriverDetailViewModel : ViewModelBase
    {
        private CreateQuotationViewModel parentViewModel = null;

        public AddDriverDetailViewModel(CreateQuotationViewModel parentViewModel)
        {
            this.parentViewModel = parentViewModel;
            this.DriverDetails = new ObservableCollection<DriverDetailViewModel>();
#if DEBUG
            DataAccess.Models.DriverDetail driverDetail = new DataAccess.Models.DriverDetail()
            {
                Name = "Kasim",
                DriverNRIC = "YYY",
                DateOfBirth = new DateTime(1984, 4, 11),
                Gender = "MALE",
                MaritalStatus = true,
                Occupation = "Software Engineer",
                LicenseDate = DateTime.Now
            };
            //this.DriverDetails.Add(new DriverDetailViewModel(driverDetail));
            this.CurrentDriverDetail = new DriverDetailViewModel(driverDetail);
#else            
            this.CurrentDriverDetail = new DriverDetailViewModel(new DriverDetail());
#endif
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.AddDriverCommand = new RelayCommand(this.ExecuteAddDriverCommand, this.CanExecuteAddDriverCommand);
            this.EditDriverCommand = new RelayCommand(this.ExecuteEditDriverCommand, this.CanExecuteEditDriverCommand);
            this.DeleteDriverCommand = new RelayCommand(this.ExecuteDeleteDriverCommand, this.CanExecuteDeleteDriverCommand);
            this.SaveDriverCommand = new RelayCommand(this.ExecuteSaveDriverCommand, this.CanExecuteSaveDriverCommand);

            this.PreviousCommand = new RelayCommand(this.ExecutePreviousCommand, this.CanExecutePreviousCommand);
            this.NextCommand = new RelayCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand AddDriverCommand { get; private set; }

        public bool CanExecuteAddDriverCommand()
        {
            if (this.CurrentDriverDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddDriverCommand()
        {
            //this.EventAggregator.GetEvent<AddDriverEvent>().Publish(new DriverEventArgs
            //{
            //    DriverDetail = this.CurrentDriverDetail.Model
            //});

            this.DriverDetails.Add(new DriverDetailViewModel(new DriverDetail()
            {
                Name = CurrentDriverDetail.Name,
                DriverNRIC = CurrentDriverDetail.NRIC,
                DateOfBirth = CurrentDriverDetail.DateOfBirth,
                Gender = CurrentDriverDetail.Gender,
                MaritalStatus = CurrentDriverDetail.MaritalStatus,
                Occupation = CurrentDriverDetail.Occupation,
                LicenseDate = CurrentDriverDetail.LicenseDate
            }));
            this.CurrentDriverDetail.ClearDetail();
        }

        public ICommand EditDriverCommand { get; private set; }

        public bool CanExecuteEditDriverCommand()
        {
            return true;
        }

        public void ExecuteEditDriverCommand()
        {
        }

        public ICommand DeleteDriverCommand { get; private set; }

        public bool CanExecuteDeleteDriverCommand()
        {
            if (this.SelectedDriverDetail != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteDeleteDriverCommand()
        {
            //this.EventAggregator.GetEvent<DeleteDriverEvent>().Publish(new DriverEventArgs
            //{
            //    DriverDetail = this.SelectedDriverDetail.Model
            //});

            this.DriverDetails.Remove(this.SelectedDriverDetail);
            this.SelectedDriverDetail = null;
        }

        public ICommand SaveDriverCommand { get; private set; }

        public bool CanExecuteSaveDriverCommand()
        {
            bool isValid = true;
            foreach(var dDetail in this.DriverDetails)
            {
                if (dDetail.IsValid() == false)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public void ExecuteSaveDriverCommand()
        {
            this.EventAggregator.GetEvent<SaveDriverEvent>().Publish(new DriverEventArgs
            {
                DriverDetails = this.DriverDetails.Select(dd => dd.Model).ToList(),
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddVehicleDetail
            });
        }

        public ICommand PreviousCommand { get; private set; }

        public bool CanExecutePreviousCommand()
        {
            return true;
        }

        public void ExecutePreviousCommand()
        {
            this.EventAggregator.GetEvent<SaveDriverEvent>().Publish(new DriverEventArgs
            {
                DriverDetails = this.DriverDetails.Select(dd => dd.Model).ToList(),
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddOwnerDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            return true;
        }

        public void ExecuteNextCommand()
        {
            this.EventAggregator.GetEvent<SaveDriverEvent>().Publish(new DriverEventArgs
            {
                DriverDetails = this.DriverDetails.Select(dd => dd.Model).ToList(),
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddVehicleDetail
            });
        }
        #endregion Commands

        #region Properties
        public ObservableCollection<DriverDetailViewModel> DriverDetails
        {
            get { return this.parentViewModel.QuotationViewModel.DriverDetails; }
            set
            {
                this.parentViewModel.QuotationViewModel.DriverDetails = value;
                OnPropertyChanged();
            }
        }

        public DriverDetailViewModel CurrentDriverDetail
        {
            get { return this.parentViewModel.QuotationViewModel.CurrentDriverDetail; }
            set
            {
                this.parentViewModel.QuotationViewModel.CurrentDriverDetail = value;
                OnPropertyChanged();
            }
        }

        public DriverDetailViewModel SelectedDriverDetail
        {
            get { return this.parentViewModel.QuotationViewModel.SelectedDriverDetail; }
            set
            {
                this.parentViewModel.QuotationViewModel.SelectedDriverDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties
    }
}
