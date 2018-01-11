using MahApps.Metro.Controls;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;

namespace Quotation.Shell.Views
{
    /// <summary>
    /// Interaktionslogik für ShellSettingsFlyout.xaml
    /// </summary>
    public partial class ShellSettingsFlyout : Flyout, IFlyoutView
    {
        public ShellSettingsFlyout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The flyout name
        /// </summary>
        public string FlyoutName
        {
            get { return FlyoutNames.ShellSettingsFlyout; }
        }
    }
}
