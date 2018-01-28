using MaterialDesignThemes.Wpf;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.LoginModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    class AddGroupDialogViewModel : ViewModelBase
    {
        private GroupViewModel groupViewModel = null;

        public AddGroupDialogViewModel(GroupViewModel groupViewModel)
        {
            this.groupViewModel = groupViewModel;
            IntializeCommands();
        }

        #region Properties
        public GroupViewModel Group
        {
            get { return groupViewModel; }
            set
            {
                groupViewModel = value;
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
            if (string.IsNullOrEmpty(this.Group.Name) == false) return true;
            else return false;
        }

        public void ExecuteAddCommand()
        {
            this.EventAggregator.GetEvent<GroupAccountEvent>().Publish(new GroupAccountEventArg
            {
                Group = this.Group,
                ActionType = GroupAccountAction.GroupAdded
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