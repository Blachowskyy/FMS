using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ForkliftConfigurationPage.xaml
    /// </summary>
    public partial class ForkliftConfigurationPage : Page
    {
        public ForkliftConfigurationPage(ForkliftConfigurationPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
