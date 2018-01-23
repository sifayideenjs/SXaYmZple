using MaterialDesignThemes.Wpf;
using Quotation.Core;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Events;
using Quotation.LoginModule.Models;
using Quotation.LoginModule.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class GroupManagementViewModel : ViewModelBase
    {
        private ObservableCollection<GroupViewModel> groups = new ObservableCollection<GroupViewModel>();

        public GroupManagementViewModel()
        {
            SubscribeEvents();
            IntializeCommands();
#if DEBUG
            List<GroupRoleViewModel> roles1 = new List<GroupRoleViewModel>() { new GroupRoleViewModel("Super-Administrator", true), new GroupRoleViewModel("Administrator", true), new GroupRoleViewModel("User", true) };
            GroupViewModel group1 = new GroupViewModel("Group1", roles1);
            this.Groups.Add(group1);

            List<GroupRoleViewModel> roles2 = new List<GroupRoleViewModel>() { new GroupRoleViewModel("Super-Administrator", false), new GroupRoleViewModel("Administrator", true), new GroupRoleViewModel("User", true) };
            GroupViewModel group2 = new GroupViewModel("Group2", roles2);
            this.Groups.Add(group2);

            List<GroupRoleViewModel> roles3 = new List<GroupRoleViewModel>() { new GroupRoleViewModel("Super-Administrator", false), new GroupRoleViewModel("Administrator", false), new GroupRoleViewModel("User", true) };
            GroupViewModel group3 = new GroupViewModel("Group3", roles3);
            this.Groups.Add(group3);
#endif
        }

        #region Properties
        public ObservableCollection<GroupViewModel> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void IntializeCommands()
        {
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.AddGroupCommand = new RelayCommand(this.ExecuteAddGroupCommand, this.CanExecuteAddGroupCommand);
        }

        public ICommand DashboardCommand { get; private set; }

        public bool CanExecuteDashboardCommand()
        {
            return true;
        }

        public void ExecuteDashboardCommand()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Publish(new DashboardEventArgs { });
        }

        public ICommand AddGroupCommand { get; private set; }

        public bool CanExecuteAddGroupCommand()
        {
            return true;
        }

        public async void ExecuteAddGroupCommand()
        {
            var view = new AddUserDialog
            {
                DataContext = new AddUserDialogViewModel()
            };

            var result = await DialogHost.Show(view, "GroupDialog", ExtendedOpenedEventHandler);
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
        }
        #endregion Commands

        #region EventAggregation
        private void SubscribeEvents()
        {
            //this.EventAggregator.GetEvent<UserAccountEvent>().Subscribe(OnUserAccountEvent);
        }
        #endregion //EventAggregation
    }

    public class UserViewModel : ViewModelBase
    {
        private string name = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;
        private List<GroupRoleViewModel> groups = new List<GroupRoleViewModel>();
        private GroupRoleViewModel selectedGroup = null;

        public UserViewModel(string name, string username, string password, List<GroupRoleViewModel> groups)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.groups = groups;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public List<GroupRoleViewModel> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
                OnPropertyChanged();
            }
        }

        public GroupRoleViewModel SelectedGroup
        {
            get
            {
                return selectedGroup;
            }
            set
            {
                selectedGroup = value;
                OnPropertyChanged();
            }
        }
    }

    public class GroupViewModel : ViewModelBase
    {
        private string name = string.Empty;
        private bool isModified = false;
        private List<GroupRoleViewModel> roles = new List<GroupRoleViewModel>();

        public GroupViewModel(string name, List<GroupRoleViewModel> roles)
        {
            this.name = name;
            this.roles = roles;
            this.roles.ForEach(r => r.Parent = this);
            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool IsModified
        {
            get
            {
                return isModified;
            }
            set
            {
                isModified = value;
                OnPropertyChanged();
            }
        }

        public List<GroupRoleViewModel> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }

        public bool CanExecuteSaveCommand()
        {
            return IsModified;
        }

        public void ExecuteSaveCommand()
        {
        }
    }

    public class GroupRoleViewModel : ViewModelBase
    {
        private string name = string.Empty;
        private bool isSelected = false;

        public GroupRoleViewModel(string name, bool isSelected)
        {
            this.name = name;
            this.isSelected = isSelected;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                if (Parent != null) Parent.IsModified = true;
                OnPropertyChanged();
            }
        }

        public GroupViewModel Parent { get; set; }
    }
}
