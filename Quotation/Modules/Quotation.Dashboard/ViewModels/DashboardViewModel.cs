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
using Quotation.Infrastructure.Events;

namespace Quotation.DashboardModule.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel()
        {
            SubscribeEvents();
        }

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<DashboardEvent>().Subscribe(OnDashboardView);
        }

        private void OnDashboardView(DashboardEventArgs arg)
        {
            this.RegionManager.RequestNavigate(RegionNames.MainRegion, WindowNames.Dashboard);
        }
        #endregion //EventAggregation
    }
}