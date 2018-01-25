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
            this.AddCommand = new RelayCommand(this.ExecuteAddCommand, this.CanExecuteAddCommand);
            this.CancelCommand = new RelayCommand(this.ExecuteCancelCommand, this.CanExecuteCancelCommand);
        }

        public ICommand AddCommand { get; private set; }

        public bool CanExecuteAddCommand()
        {
            if (string.IsNullOrEmpty(this.User.Name) == false && string.IsNullOrEmpty(this.User.Username) == false && this.User.SelectedGroup != null) return true;
            else return false;
        }

        public void ExecuteAddCommand()
        {
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
