using MaterialDesignThemes.Wpf;
using Quotation.Core;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Interfaces;
using Quotation.LoginModule.Events;
using Quotation.LoginModule.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Windows.Input;
using Quotation.Core.Utilities;

namespace Quotation.LoginModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private UserManagementDb userManagementDb = null;
        private List<GroupDetail> groupDetails = null;
        private ObservableCollection<UserViewModel> users = new ObservableCollection<UserViewModel>();

        public UserManagementViewModel(UserManagementDb userManagementDb)
        {
            this.userManagementDb = userManagementDb;
            SubscribeEvents();
            IntializeCommands();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            string errorMessage = string.Empty;

            var groupdataset = this.userManagementDb.LoadComboDetails("GROUP", out errorMessage);
            groupDetails = GetGroupDetails(groupdataset);

            var userdataset = userManagementDb.LoadComboDetails("USER", out errorMessage);
            var userDetails = GetUserDetails(userdataset);

            this.Users = new ObservableCollection<UserViewModel>(userDetails.Select(ud => new UserViewModel(userManagementDb, groupDetails, ud)));
        }

        private List<UserGroupDetail> GetUserDetails(DataSet dataset)
        {
            List<UserGroupDetail> userDetails = new List<UserGroupDetail>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    userDetails = dataTable.AsEnumerable().Select(row => new UserGroupDetail
                    {
                        UserID = (int)row.Field<long>("UserID"),
                        UserName = row.Field<string>("UserName"),
                        Name = row.Field<string>("Name"),
                        GroupID = (int)row.Field<long>("GroupID")
                    }).ToList();
                }
            }
            return userDetails;
        }

        private List<GroupDetail> GetGroupDetails(DataSet dataset)
        {
            List<GroupDetail> groupDetails = new List<GroupDetail>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    groupDetails = dataTable.AsEnumerable().Select(row => new GroupDetail
                    {
                        GroupID = (int)row.Field<long>("GroupID"),
                        GroupName = row.Field<string>("GroupName")
                    }).ToList();
                }
            }
            return groupDetails;
        }

        #region Properties
        public ObservableCollection<UserViewModel> Users
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
            this.DashboardCommand = new RelayCommand(this.ExecuteDashboardCommand, this.CanExecuteDashboardCommand);
            this.AddUserCommand = new RelayCommand(this.ExecuteAddUserCommand, this.CanExecuteAddUserCommand);
        }

        public ICommand DashboardCommand { get; private set; }

        public bool CanExecuteDashboardCommand()
        {
            return true;
        }

        public void ExecuteDashboardCommand()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Publish(new DashboardEventArgs
            {
            });
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
                DataContext = new AddUserDialogViewModel(new UserViewModel(this.userManagementDb, groupDetails))
            };

            var result = await DialogHost.Show(view, "UserDialog", ExtendedOpenedEventHandler);
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

        private async void OnUserAccountEvent(UserAccountEventArg arg)
        {
            if (arg != null && arg.User != null)
            {
                string loggedInUserName = IdentityUtility.GetLoggedInUserName();
                switch (arg.ActionType)
                {
                    case UserAccountAction.UserAdded:
                        {
                            var userDetail = new UserDetail()
                            {
                                UserID = 0,
                                Name = arg.User.Name,
                                UserName = arg.User.Username,
                                Password = arg.User.Password,
                                GroupID = arg.User.SelectedGroup.GroupID
                            };
                            var errorInfo = this.userManagementDb.UpdateUser(userDetail, "ADD", loggedInUserName);
                            if (errorInfo.Code == 0)
                            {
                                this.Users.Add(arg.User);
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New User", errorInfo.Info);
                            }
                            break;
                        }
                    case UserAccountAction.UserEdited:
                        {
                            var userDetail = new UserDetail()
                            {
                                UserID = arg.User.ID,
                                UserName = arg.User.Name,
                                //Password = arg.User.Password,
                                GroupID = arg.User.SelectedGroup.GroupID
                            };
                            var errorInfo = this.userManagementDb.UpdateUser(userDetail, "EDIT", loggedInUserName);
                            if (errorInfo.Code == 0)
                            {
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Edit User", errorInfo.Info);
                            }
                            break;
                        }
                    case UserAccountAction.UserDeleted:
                        {
                            var userDetail = new UserDetail()
                            {
                                UserID = arg.User.ID,
                                Name = arg.User.Name,
                                UserName = arg.User.Username,
                                Password = arg.User.Password,
                                GroupID = arg.User.SelectedGroup.GroupID
                            };
                            var errorInfo = this.userManagementDb.UpdateUser(userDetail, "DELETE", loggedInUserName);
                            if (errorInfo.Code == 0)
                            {
                                this.Users.Remove(arg.User);
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Delete User", errorInfo.Info);
                            }
                            break;
                        }
                    case UserAccountAction.OperationFailed:
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("User Operation", "Unable to perform this operation");
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}
