using FMS.ViewModels.Main;
using System.Windows.Controls;

namespace FMS.Views.Main
{
    /// <summary>
    /// Logika interakcji dla klasy ForkliftManagementPage.xaml
    /// </summary>
    public partial class ForkliftManagementPage : Page
    {
        public ForkliftManagementPage(ForkliftManagementPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
