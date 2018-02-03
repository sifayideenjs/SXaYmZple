using MaterialDesignThemes.Wpf;
using Quotation.Core;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.LoginModule.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class AddUserDialogViewModel : ViewModelBase
    {
        private UserViewModel userViewModel = null;

        public AddUserDialogViewModel(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
            IntializeCommands();
        }

        #region Properties
        public UserViewModel User
        {
            get { return userViewModel; }
            set
            {
                userViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.AddCommand = new RelayCommand<object>(this.ExecuteAddCommand, this.CanExecuteAddCommand);
            this.CancelCommand = new RelayCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
        }

        public ICommand AddCommand { get; private set; }

        public bool CanExecuteAddCommand(object parameter)
        {
            if (string.IsNullOrEmpty(this.User.Name) == false && string.IsNullOrEmpty(this.User.Username) == false && this.User.SelectedGroup != null)
            {
                PasswordBox passwordBox = parameter as PasswordBox;
                string clearTextPassword = passwordBox.Password;
                if (string.IsNullOrEmpty(clearTextPassword)) return false;
                else return true;
            }
            else return false;
        }

        public void ExecuteAddCommand(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;

            this.User.Password = clearTextPassword;

            this.EventAggregator.GetEvent<UserAccountEvent>().Publish(new UserAccountEventArg
            {
                User = this.User,
                ActionType = UserAccountAction.UserAdded
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
