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
using Quotation.LoginModule.Models;
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

namespace Quotation.LoginModule.ViewModels
{
    public class GroupManagementViewModel : ViewModelBase
    {
        #region Fields
        private UserManagementDb userManagementDb = null;
        private ObservableCollection<GroupViewModel> groups = new ObservableCollection<GroupViewModel>();
        #endregion //Fields

        #region Constructor
        public GroupManagementViewModel(UserManagementDb userManagementDb)
        {
            this.userManagementDb = userManagementDb;
            SubscribeEvents();
            IntializeCommands();
            InitializeGroups();
        }
        #endregion //Constructor

        #region Methods
        private void InitializeGroups()
        {
            string errorMessage = string.Empty;

            var formdataset = userManagementDb.LoadComboDetails("FORM", out errorMessage);
            var formDetails = GetFormDetails(formdataset);

            var groupdataset = this.userManagementDb.LoadComboDetails("GROUP", out errorMessage);
            var groupDetails = GetGroupDetails(groupdataset);

            this.Groups = new ObservableCollection<GroupViewModel>(groupDetails.Select(gd => new GroupViewModel(userManagementDb, gd, formDetails)));
        }

        private List<FormDetail> GetFormDetails(DataSet dataset)
        {
            List<FormDetail> formDetails = new List<FormDetail>();
            if (dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    formDetails = dataTable.AsEnumerable().Select(row => new FormDetail
                    {
                        FormID = (int)row.Field<long>("FormID"),
                        FormName = row.Field<string>("FormName")
                    }).ToList();
                }
            }
            return formDetails;
        }

        private List<GroupDetail> GetGroupDetails(DataSet dataset)
        {
            List<GroupDetail> groupDetails = new List<GroupDetail>();
            if(dataset != null && dataset.Tables.Count > 0)
            {
                DataTable dataTable = dataset.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    groupDetails = dataTable.AsEnumerable().Select(row => new GroupDetail
                    {
                        GroupID = row.Field<string>("GroupID"),
                        GroupName = row.Field<string>("GroupName")
                    }).ToList();
                }
            }
            return groupDetails;
        }
        #endregion //Methods

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
                //DataContext = new AddUserDialogViewModel()
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
            this.EventAggregator.GetEvent<GroupAccountEvent>().Subscribe(OnGroupAccountEvent);
        }

        private async void OnGroupAccountEvent(GroupAccountEventArg arg)
        {
            if (arg != null && arg.Group != null)
            {
                switch (arg.ActionType)
                {
                    case GroupAccountAction.GroupAdded:
                        {
                            var groupDetail = new GroupDetail()
                            {
                                GroupID = "0",
                                GroupName = arg.Group.Name
                            };
                            var errorInfo = this.userManagementDb.UpdateGroup(groupDetail, "ADD", "Admin");
                            if (errorInfo.Code == 0)
                            {
                                this.Groups.Add(arg.Group);
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Group", errorInfo.Info);
                            }
                            break;
                        }
                    case GroupAccountAction.GroupEdited:
                        {
                            List<GroupFormRight> groupFormRights = new List<GroupFormRight>();
                            foreach (var form in arg.Group.Forms)
                            {
                                if (form.IsSelected)
                                {
                                    GroupFormRight groupFormRight = new GroupFormRight()
                                    {
                                        FormID = form.ID,
                                        GroupID = form.Parent.GroupID,
                                        Options = "EDIT"
                                    };

                                    groupFormRights.Add(groupFormRight);
                                }
                            }

                            var errorInfo = this.userManagementDb.UpdateGroupFormRights(groupFormRights);
                            if (errorInfo.Code == 0)
                            {
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("New Group", errorInfo.Info);
                            }
                            break;
                        }
                    case GroupAccountAction.GroupDeleted:
                        {
                            var groupDetail = new GroupDetail()
                            {
                                GroupID = "0",
                                GroupName = arg.Group.Name
                            };
                            var errorInfo = this.userManagementDb.UpdateGroup(groupDetail, "DELETE", "Admin");
                            if (errorInfo.Code == 0)
                            {
                                this.Groups.Remove(arg.Group);
                            }
                            else
                            {
                                await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Delete Group", errorInfo.Info);
                            }
                            break;
                        }
                    case GroupAccountAction.OperationFailed:
                        {
                            await this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Group Operation", "Unable to perform this operation");
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}