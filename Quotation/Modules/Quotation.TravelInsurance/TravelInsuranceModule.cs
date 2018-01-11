using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.TravelInsuranceModule.Views;

namespace Quotation.TravelInsuranceModule
{
    public class TravelInsuranceModule : PrismBaseModule
    {
        public TravelInsuranceModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            //// Titlebar
            //regionManager.RegisterViewWithRegion(RegionNames.LeftWindowCommandsRegion, typeof(LeftTitlebarCommands));

            //// Flyouts
            //regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));

            // Tiles
            regionManager.RegisterViewWithRegion(RegionNames.TileRegion, typeof(TravelInsuranceTiles));
        }
    }
}