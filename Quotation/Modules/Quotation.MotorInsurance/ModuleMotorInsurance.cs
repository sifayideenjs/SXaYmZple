using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsurance.Views;

namespace Quotation.MotorInsurance
{
    public class ModuleMotorInsurance : PrismBaseModule
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unityContainer">The Unity container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ModuleMotorInsurance(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            // Titlebar
            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));

            // Flyouts
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));
            regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C2Flyout));

            // Tiles
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));

            // Register Views
            Prism.Unity.UnityExtensions.RegisterTypeForNavigation<Views.ModuleAPopup>(unityContainer, PopupNames.ModuleAPopup);
        }
    }
}