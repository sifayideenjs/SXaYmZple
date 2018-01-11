using MahApps.Metro.Controls;
using Prism.Regions;
using Quotation.Infrastructure.Constants;
using System.Windows;

namespace Quotation.Shell.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            // The RegionManager.RegionName attached property XAML-Declaration doesn't work for this scenario (object declarated outside the logical tree)
            // theses objects are not part of the logical tree, hence the parent that has the region manager to use (the Window) cannot be found using LogicalTreeHelper.FindParent 
            // therefore the regionManager is never found and cannot be assigned automatically by Prism.  This means we have to handle this ourselves
            if (regionManager != null)
            {
                SetRegionManager(regionManager, this.leftWindowCommandsRegion, RegionNames.LeftWindowCommandsRegion);
                SetRegionManager(regionManager, this.rightWindowCommandsRegion, RegionNames.RightWindowCommandsRegion);
                SetRegionManager(regionManager, this.flyoutsControlRegion, RegionNames.FlyoutRegion);
            }
        }

        void SetRegionManager(IRegionManager regionManager, DependencyObject regionTarget, string regionName)
        {
            RegionManager.SetRegionName(regionTarget, regionName);
            RegionManager.SetRegionManager(regionTarget, regionManager);
        }
    }
}
