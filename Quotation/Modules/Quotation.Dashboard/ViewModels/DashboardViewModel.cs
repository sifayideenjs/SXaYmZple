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

namespace Quotation.DashboardModule.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            // Initialize commands
            this.IntializeCommands();
        }

        #region Commands

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void IntializeCommands()
        {
            this.ShowModuleAPopupCommand = new RelayCommand(this.ShowModuleAPopup, this.CanShowModuleAPoupup);
            this.ShowModuleAMessageCommand = new RelayCommand(this.ShowModuleAMessage, this.CanShowModuleAMessage);
        }

        /// <summary>
        /// Show popup
        /// </summary>
        public ICommand ShowModuleAPopupCommand { get; private set; }

        public bool CanShowModuleAPoupup()
        {
            return true;
        }

        public void ShowModuleAPopup()
        {
            this.RegionManager.RequestNavigate(RegionNames.SubMainRegion, PopupNames.ModuleAPopup);
        }

        /// <summary>
        /// Show popup
        /// </summary>
        public ICommand ShowModuleAMessageCommand { get; private set; }

        public bool CanShowModuleAMessage()
        {
            return true;
        }

        /// <summary>
        /// Show message
        /// </summary>
        public void ShowModuleAMessage()
        {
            this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Module A Message", "This is a message from Module A");
        }

        #endregion Commands
    }
}