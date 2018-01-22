using MaterialDesignThemes.Wpf;
using Quotation.Core;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class AddUserDialogViewModel : ViewModelBase, IDataErrorInfo
    {
        private string name = string.Empty;
        private string username = string.Empty;
        private bool isAdministrator = false;

        public AddUserDialogViewModel()
        {
            IntializeCommands();
        }

        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdministrator
        {
            get { return isAdministrator; }
            set
            {
                isAdministrator = value;
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
            if (string.IsNullOrEmpty(this.Name) == false && string.IsNullOrEmpty(this.Username) == false) return true;
            else return false;
        }

        public void ExecuteAddCommand()
        {
            this.EventAggregator.GetEvent<UserAccountEvent>().Publish(new UserAccountEventArg
            {
                Username = this.Username,
                ActionType = "UserAdd"
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

        #region Validation
        public string Error
        {
            get;
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            switch (propertyName)
            {
                case "Name":
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        validationMessage = "Please enter Name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
                case "Username":
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        validationMessage = "Please enter User Name";
                    }
                    else
                    {
                        validationMessage = string.Empty;
                    }
                    break;
            }

            return validationMessage;
        }
        #endregion //Validation
    }
}
