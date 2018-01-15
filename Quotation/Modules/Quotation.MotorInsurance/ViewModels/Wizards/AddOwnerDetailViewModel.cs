using Prism.Commands;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.MotorInsuranceModule.ViewModels.Wizards
{
    public class AddOwnerDetailViewModel : ViewModelBase
    {
        private CreateQuotationViewModel parentViewModel = null;

        public AddOwnerDetailViewModel(CreateQuotationViewModel parentViewModel)
        {
            this.parentViewModel = parentViewModel;
#if DEBUG
            DataAccess.Models.OwnerDetail ownerDetail = new DataAccess.Models.OwnerDetail()
            {
                Name = "Sifayideen",
                NRIC = "YYY-ZZZ1",
                DateOfBirth = new DateTime(1983, 5, 7),
                Gender = "MALE",
                MaritalStatus = true,
                Occupation = "Software Engineer",
                LicenseDate = DateTime.Now,
                Email = "sifayideen@gmail.com",
                Address = "Chennai",
                RenewalRemindDays = 7
            };

            this.OwnerDetail = new OwnerDetailViewModel(ownerDetail);
#else            
            this.OwnerDetail = new OwnerDetailViewModel(new DataAccess.Models.OwnerDetail());
#endif
            this.IntializeCommands();
        }

        #region Commands
        private void IntializeCommands()
        {
            this.CancelCommand = new RelayCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
            this.AddOwnerCommand = new RelayCommand(this.ExecuteAddOwnerCommand, this.CanExecuteAddOwnerCommand);
            this.NextCommand = new RelayCommand(this.ExecuteNextCommand, this.CanExecuteNextCommand);
        }

        public ICommand CancelCommand { get; private set; }

        public bool CanExecuteCancelCommand()
        {
            return true;
        }

        public void ExecuteCancelCommand()
        {
            this.EventAggregator.GetEvent<CancelEvent>().Publish(new Events.CancelEventArgs
            {
            });
        }

        public ICommand AddOwnerCommand { get; private set; }

        public bool CanExecuteAddOwnerCommand()
        {
            if(this.OwnerDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteAddOwnerCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new OwnerEventArgs
            {
                OwnerDetail = this.OwnerDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddDriverDetail
            });
        }

        public ICommand NextCommand { get; private set; }

        public bool CanExecuteNextCommand()
        {
            if (this.OwnerDetail.IsValid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteNextCommand()
        {
            this.EventAggregator.GetEvent<AddOwnerEvent>().Publish(new OwnerEventArgs
            {
                OwnerDetail = this.OwnerDetail.Model,
                RegionName = RegionNames.MotorWizardRegion,
                Source = WindowNames.MotorAddDriverDetail
            });
        }
        #endregion Commands

        #region Properties
        public OwnerDetailViewModel OwnerDetail
        {
            get { return this.parentViewModel.QuotationViewModel.OwnerDetail; }
            set
            {
                this.parentViewModel.QuotationViewModel.OwnerDetail = value;
                OnPropertyChanged();
            }
        }

        public bool IsOwnerCreated
        {
            get { return this.parentViewModel.QuotationViewModel.IsOwnerCreated; }
            set
            {
                this.parentViewModel.QuotationViewModel.IsOwnerCreated = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties
    }
}
