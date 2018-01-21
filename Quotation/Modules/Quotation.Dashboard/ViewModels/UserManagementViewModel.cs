using MaterialDesignThemes.Wpf;
using Quotation.DashboardModule.Events;
using Quotation.DashboardModule.Views;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.DashboardModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private ObservableCollection<string> users = new ObservableCollection<string>();
        public UserManagementViewModel()
        {
            SubscribeEvents();
            IntializeCommands();
        }

        #region Properties
        public ObservableCollection<string> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.AddUserCommand = new RelayCommand(this.ExecuteAddUserCommand, this.CanExecuteAddUserCommand);
        }

        public ICommand AddUserCommand { get; private set; }

        public bool CanExecuteAddUserCommand()
        {
            return true;
        }

        public async void ExecuteAddUserCommand()
        {
            var view = new AddUserDialog
            {
                DataContext = new AddUserDialogViewModel()
            };
            
            var result = await DialogHost.Show(view, "RootDialog", ExtendedOpenedEventHandler);
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<UserAccountEvent>().Subscribe(OnUserAccountEvent);
        }

        private void OnUserAccountEvent(UserAccountEventArg arg)
        {
            if (arg != null)
            {
                switch (arg.ActionType)
                {
                    case "UserAdd":
                        {
                            this.Users.Add(arg.Username);
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}