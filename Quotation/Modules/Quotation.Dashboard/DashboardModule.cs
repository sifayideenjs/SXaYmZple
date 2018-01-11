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
            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));

            //// Flyouts
            //regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));
            //regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C2Flyout));

            //// Tiles
            //regionManager.RegisterViewWithRegion(RegionNames.TileRegion, typeof(Dashboard));

            //// Register Views
            //Prism.Unity.UnityExtensions.RegisterTypeForNavigation<Views.ModuleAPopup>(unityContainer, PopupNames.ModuleAPopup);
        }
    }
}