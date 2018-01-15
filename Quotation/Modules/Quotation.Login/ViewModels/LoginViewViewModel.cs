using Prism.Commands;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using Quotation.Infrastructure;

namespace Quotation.LoginModule.ViewModels
{
    public class LoginViewViewModel : ViewModelBase
    {
        private string _user;
        private string _password;
        private string _error = string.Empty;

        public LoginViewViewModel()
        {
            this.IntializeCommands();

#if DEBUG
            User = "admin";
            Password = "admin";
#endif
        }

        //#region ** IDataErrorInfo

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        var err = string.Empty;

        //        if (columnName == "User" && string.IsNullOrEmpty(User))
        //            err = "User name cannot be empty";
        //        else if (columnName == "Password" && string.IsNullOrEmpty(User))
        //            err = "Password cannot be empty";

        //        return err;
        //    }
        //}

        //#endregion

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged();
            }
        }
        private void IntializeCommands()
        {
            this.LoginCommand = new RelayCommand(this.ExecuteLoginCommand, this.CanExecuteLoginCommand);
        }

        public ICommand LoginCommand { get; private set; }

        public bool CanExecuteLoginCommand()
        {
            return true;
        }

        public void ExecuteLoginCommand()
        {
            //this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.DashboardWindow);
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
        }

    }
}
