using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.MotorInsuranceModule.Views;

namespace Quotation.MotorInsuranceModule
{
    public class MotorInsuranceModule : PrismBaseModule
    {
        public MotorInsuranceModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            // Tiles
            regionManager.RegisterViewWithRegion(RegionNames.TileRegion, typeof(MotorInsuranceTiles));
            regionManager.RegisterViewWithRegion(RegionNames.TileRegion, typeof(RecentQuotation));

            //// Register Views
            //Prism.Unity.UnityExtensions.RegisterTypeForNavigation<Views.ModuleAPopup>(unityContainer, PopupNames.ModuleAPopup);
        }

        public override void Initialize()
        {

        }
    }
}