using Quotation.Infrastructure;
using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotation.LoginModule.ViewModels
{
    public class LicenseViewViewModel : ViewModelBase
    {
        #region Fields
        private string _licenseFilePath = string.Empty;
        private string _warningMessage = string.Empty;
        #endregion //Fields

        #region Constructor
        public LicenseViewViewModel()
        {
            InitialilzeCommands();
        }
        #endregion //Constructor

        #region Properties
        public string LicenseFilePath
        {
            get { return _licenseFilePath; }
            set
            {
                _licenseFilePath = value;
                OnPropertyChanged();
            }
        }

        public string WarningMessage
        {
            get { return _warningMessage; }
            set
            {
                _warningMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region Commands
        private void InitialilzeCommands()
        {
            this.BrowseLicenseFileCommand = new RelayCommand(ExecuteBrowseLicenseFileCommand);
            this.ActivateLicenseCommand = new RelayCommand(ExecuteActivateLicenseCommand, CanExecuteActivateLicenseCommand);
            this.NavigateCommand = new RelayCommand(ExecuteNavigateCommand, CanExecuteNavigateCommand);
        }

        public ICommand BrowseLicenseFileCommand { get; set; }

        private void ExecuteBrowseLicenseFileCommand()
        {
            Microsoft.Win32.OpenFileDialog openDialog = new Microsoft.Win32.OpenFileDialog();
            openDialog.Title = "Browse for License File";
            openDialog.DefaultExt = ".licx";
            openDialog.Filter = "License File|*.licx";
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                this.LicenseFilePath = openDialog.FileName;
            }
        }

        public ICommand ActivateLicenseCommand { get; set; }

        private bool CanExecuteActivateLicenseCommand()
        {
            if (string.IsNullOrEmpty(this.LicenseFilePath)) return false;
            else
            {
                var extn = Path.GetFileNameWithoutExtension(this.LicenseFilePath).ToUpper();
                if (extn == ".LICX") return true;
                else return false;
            }
        }

        private void ExecuteActivateLicenseCommand()
        {

        }

        public ICommand NavigateCommand { get; set; }

        private bool CanExecuteNavigateCommand()
        {
            return false;
        }

        private void ExecuteNavigateCommand()
        {

        }
        #endregion //Commands
    }
}
