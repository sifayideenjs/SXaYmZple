using MaterialDesignThemes.Wpf;
using Quotation.DataAccess;
using Quotation.DataAccess.Models;
using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using Quotation.LoginModule.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private int id = 0;
        private string name = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;
        private int groupId = 0;
        private List<GroupViewModel> groups = new List<GroupViewModel>();
        private GroupViewModel selectedGroup = null;

        public UserViewModel(UserManagementDb userManagementDb, List<GroupDetail> groupDetails)
        {
            this.password = "User123";
            this.groups = new List<GroupViewModel>(groupDetails.Select(gd => new GroupViewModel(userManagementDb, gd)));

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
            this.DeleteCommand = new RelayCommand(this.ExecuteDeleteCommand, this.CanExecuteDeleteCommand);
        }

        public UserViewModel(UserManagementDb userManagementDb, List<GroupDetail> groupDetails, UserGroupDetail userGroupDetail)
        {
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
        #endregion //ICommand
    }
}
