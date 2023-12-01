using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy AutoModeStartupPage.xaml
    /// </summary>
    public partial class AutoModeStartupPage : Page
    {
        public AutoModeStartupPage(AutoModeStartupPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
