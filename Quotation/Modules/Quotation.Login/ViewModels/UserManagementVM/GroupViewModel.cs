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
    public class GroupViewModel : ViewModelBase
    {
        private UserManagementDb userManagementDb = null;
        private int groupId = 0;
        private string name = string.Empty;
        private bool isModified = false;
        private List<GroupFormViewModel> forms = new List<GroupFormViewModel>();

        public GroupViewModel(UserManagementDb userManagementDb)
        {
            this.userManagementDb = userManagementDb;

            string errorMessage;
            var formdataset = userManagementDb.LoadComboDetails("FORM", out errorMessage);
            var formDetails = GetFormDetails(formdataset);

            this.Forms = new List<GroupFormViewModel>(formDetails.Select(fd => new GroupFormViewModel(fd.FormID, fd.CustomeText, this)));

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
        }

        public GroupViewModel(UserManagementDb userManagementDb, GroupDetail groupDetail)
        {
            this.userManagementDb = userManagementDb;
            this.groupId = groupDetail.GroupID;
            this.name = groupDetail.GroupName;

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);
        }

        //public GroupViewModel(UserManagementDb userManagementDb, GroupDetail groupDetail)
        //{
        //    this.userManagementDb = userManagementDb;
        //    this.groupId = groupDetail.GroupID;
        //    this.name = groupDetail.GroupName;

        //    this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);

        //    string errorMessage = string.Empty;
        //    var groupDetailDataSet = userManagementDb.GetGroupDetails(groupId, out errorMessage);
        //    var groupFormRights = GetGroupFormRights(groupDetailDataSet);

        //    var formdataset = userManagementDb.LoadComboDetails("FORM", out errorMessage);
        //    var formDetails = GetFormDetails(formdataset);

        //    this.forms = new List<GroupFormViewModel>(formDetails.Select(fd => new GroupFormViewModel(fd.FormID, fd.FormName, this)));
        //    foreach (var form in forms)
        //    {
        //        if (groupFormRights.Any(gfr => gfr.FormID == form.ID))
        //        {
        //            form.IsSelected = true;
        //        }
        //    }
        //}

        public GroupViewModel(UserManagementDb userManagementDb, GroupDetail groupDetail, List<FormDetail> formDetails)
        {
            this.userManagementDb = userManagementDb;
            this.groupId = groupDetail.GroupID;
            this.name = groupDetail.GroupName;

            this.SaveCommand = new RelayCommand(this.ExecuteSaveCommand, this.CanExecuteSaveCommand);

            string errorMessage = string.Empty;
            var groupDetailDataSet = userManagementDb.GetGroupDetails(groupId, out errorMessage);
            var groupFormRights = GetGroupFormRights(groupDetailDataSet);

            this.forms = new List<GroupFormViewModel>(formDetails.Select(fd => new GroupFormViewModel(fd.FormID, fd.CustomeText, this)));
            foreach (var form in forms)
            {
                if (groupFormRights.Any(gfr => gfr.FormID == form.ID))
                {
                    form.IsSelected = true;
                }
            }
        }

        private List<GroupFormRight> GetGroupFormRights(DataSet dataset)
        {
            List<GroupFormRight> groupFormRights = new List<GroupFormRight>();
            if (dataset != null && dataset.Tables.Count == 3)
            {
                DataTable dataTable = dataset.Tables[2];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    groupFormRights = dataTable.AsEnumerable().Select(row => new GroupFormRight
                    {
                        GroupID = (int)row.Field<long>("GroupID"),
                        FormID = (int)row.Field<long>("FormID"),
                        Options = row.Field<string>("Options")
                    }).ToList();
                }
            }
            return groupFormRights;
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
                        FormName = row.Field<string>("FormName"),
                        CustomeText = row.Field<string>("CustomeText")
                    }).ToList();
                }
            }
            return formDetails;
        }

        public int GroupID
        {
            get
            {
                return groupId;
            }
            set
            {
                groupId = value;
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

        public List<GroupFormViewModel> Forms
        {
            get
            {
                return forms;
            }
            set
            {
                forms = value;
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
            this.EventAggregator.GetEvent<GroupAccountEvent>().Publish(new GroupAccountEventArg
            {
                Group = this,
                ActionType = GroupAccountAction.GroupEdited
            });
        }
    }
}
