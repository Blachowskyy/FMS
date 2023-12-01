using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy LidarLocPage.xaml
    /// </summary>
    public partial class LidarLocPage : Page
    {
        public LidarLocPage(LidarLocPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
