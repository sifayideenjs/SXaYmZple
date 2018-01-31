using MaterialDesignThemes.Wpf;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Quotation.LoginModule.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Practices.Unity;

namespace Quotation.LoginModule.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private UserManagementDb dbContext = null;
        private int id = 0;
        private string name = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;
        private int groupId = 0;
        private List<GroupViewModel> groups = new List<GroupViewModel>();
        private GroupViewModel selectedGroup = null;

        public UserViewModel(UserManagementDb userManagementDb, List<GroupDetail> groupDetails)
        {
            this.dbContext = userManagementDb;
            this.password = "User123";
            this.groups = new List<GroupViewModel>(groupDetails.Select(gd => new GroupViewModel(userManagementDb, gd)));

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
            this.ResetComand = new AnotherCommandImplementation(ExecuteResetCommand, CanExecuteResetCommand);
            this.DeleteCommand = new RelayCommand(this.ExecuteDeleteCommand, this.CanExecuteDeleteCommand);
        }

        public UserViewModel(UserManagementDb userManagementDb, List<GroupDetail> groupDetails, UserGroupDetail userGroupDetail)
        {
            this.dbContext = userManagementDb;
            this.id = userGroupDetail.UserID;
            this.name = userGroupDetail.Name;
            this.username = userGroupDetail.UserName;
            this.groupId = userGroupDetail.GroupID;
            this.groups = new List<GroupViewModel>(groupDetails.Select(gd => new GroupViewModel(userManagementDb, gd)));

            string errorMessage = string.Empty;
            var userdataset = userManagementDb.GetUserDetails(this.id, out errorMessage);
            var userDetail = GetUserDetail(userdataset);
            if (userDetail != null)
            {
                this.password = userDetail.Password;
                //this.SelectedGroup = this.Groups.SingleOrDefault(g => g.GroupID == userDetail.GroupID);
            }

            this.SelectedGroup = this.Groups.SingleOrDefault(g => g.GroupID == userGroupDetail.GroupID);

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
            this.ResetComand = new AnotherCommandImplementation(ExecuteResetCommand, CanExecuteResetCommand);
            this.DeleteCommand = new RelayCommand(this.ExecuteDeleteCommand, this.CanExecuteDeleteCommand);
        }

        private UserDetail GetUserDetail(DataSet dataset)
        {
            UserDetail userDetail = null;
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    userDetail = new UserDetail
                    {
                        UserID = (int)dataTable.Rows[0].Field<long>("UserID"),
                        UserName = dataTable.Rows[0].Field<string>("UserName"),
                        Password = dataTable.Rows[0].Field<string>("Password"),
                        GroupID = (int)dataTable.Rows[0].Field<long>("GroupID")
                    };
                }
            }
            return userDetail;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
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

        public List<GroupViewModel> Groups
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

        public GroupViewModel SelectedGroup
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

        #region ICommand
        public ICommand SaveCommand { get; private set; }

        public bool CanExecuteSaveCommand()
        {
            return true;
        }

        public void ExecuteSaveCommand()
        {
            this.EventAggregator.GetEvent<UserAccountEvent>().Publish(new UserAccountEventArg
            {
                User = this,
                ActionType = UserAccountAction.UserEdited
            });
            Flipper.FlipCommand.Execute(true, null);
        }

        public ICommand DeleteCommand { get; private set; }

        public bool CanExecuteDeleteCommand()
        {
            return true;
        }

        public void ExecuteDeleteCommand()
        {
            this.EventAggregator.GetEvent<UserAccountEvent>().Publish(new UserAccountEventArg
            {
                User = this,
                ActionType = UserAccountAction.UserDeleted
            });
        }

            #region Reset Comand
            public ICommand ResetComand { get; set; }
            public bool CanExecuteResetCommand(object parameter)
            {
                if (parameter == null) return false;
                if (parameter is DockPanel)
                {
                    var panel = parameter as DockPanel;
                    var passwordBox = panel.Children.OfType<PasswordBox>().FirstOrDefault();
                    string clearTextPassword = passwordBox.Password;
                    if (string.IsNullOrEmpty(clearTextPassword))
                    {
                        return false;
                    }
                    else return true;
                }
                else return false;
            }

            private async void ExecuteResetCommand(object parameter)
            {
                var panel = parameter as DockPanel;
                var passwordBox = panel.Children.OfType<PasswordBox>().FirstOrDefault();
                string clearTextPassword = passwordBox.Password;

                if (IsSaveComplete == true)
                {
                    IsSaveComplete = false;
                    return;
                }

                if (SaveProgress != 0) return;

                var started = DateTime.Now;
                IsSaving = true;

                var userDetail = new UserDetail()
                {
                    UserID = this.ID,
                    Name = this.Name,
                    UserName = this.Username,
                    Password = clearTextPassword,
                    GroupID = this.groupId
                };
                var errorInfo = this.dbContext.UpdateUser(userDetail, "RESET", this.Username);
                if (errorInfo.Code == 0)
                {
                }
                else
                {
                    await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Reset Password", errorInfo.Info);
                }

                new DispatcherTimer(
                    TimeSpan.FromMilliseconds(50),
                    DispatcherPriority.Normal,
                    new EventHandler((o, e) =>
                    {
                        var totalDuration = started.AddSeconds(3).Ticks - started.Ticks;
                        var currentProgress = DateTime.Now.Ticks - started.Ticks;
                        var currentProgressPercent = 100.0 / totalDuration * currentProgress;

                        SaveProgress = currentProgressPercent;

                        if (SaveProgress >= 100)
                        {
                            passwordBox.Password = string.Empty;
                            IsSaveComplete = true;
                            IsSaving = false;
                            SaveProgress = 0;
                            ((DispatcherTimer)o).Stop();
                        }

                    }), Dispatcher.CurrentDispatcher);
            }

            private bool _isSaving;
            public bool IsSaving
            {
                get { return _isSaving; }
                private set { _isSaving = value; OnPropertyChanged(); }
            }

            private bool _isSaveComplete;
            public bool IsSaveComplete
            {
                get { return _isSaveComplete; }
                private set { _isSaveComplete = value; OnPropertyChanged(); }
            }

            private double _saveProgress;
            public double SaveProgress
            {
                get { return _saveProgress; }
                private set { _saveProgress = value; OnPropertyChanged(); }
            }
            #endregion

        #endregion //ICommand
    }
}
