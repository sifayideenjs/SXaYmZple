using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.DashboardModule.Views;

namespace Quotation.DashboardModule
{
    public class DashboardModule : PrismBaseModule
    {
        public DashboardModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            // Titlebar
            //regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(UsernameTitlebarCommands));
            //regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
        }
    }
}