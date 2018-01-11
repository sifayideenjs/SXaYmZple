using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.TravelInsurance.Views;

namespace Quotation.TravelInsurance
{
    public class ModuleTravelInsurance : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ModuleTravelInsurance(IUnityContainer unityContainer, IRegionManager regionManager) :
            base(unityContainer, regionManager)
        {
            // Titlebar
            regionManager.RegisterViewWithRegion(RegionNames.LeftWindowCommandsRegion, typeof(LeftTitlebarCommands));

            // Flyouts
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));

            // Tiles
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));
        }
    }
}