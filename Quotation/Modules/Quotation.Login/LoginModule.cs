using Microsoft.Practices.Unity;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.LoginModule.ViewModels;
using Quotation.LoginModule.Views;

namespace Quotation.LoginModule
{
    public class LoginModule : PrismBaseModule
    {
        public LoginModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            //unityContainer.RegisterType<LoginViewViewModel>();
            // Tiles
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(LoginView));
            regionManager.RegisterViewWithRegion(RegionNames.TileRegion, typeof(LoginViewTiles));

            // Titlebar
            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(UsernameTitlebar));
            regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebar));
        }
    }
}