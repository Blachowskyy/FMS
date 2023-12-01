using FMS.ViewModels.Main;
using System.Windows.Controls;

namespace FMS.Views.Main
{
    /// <summary>
    /// Logika interakcji dla klasy LiveForklfitsPage.xaml
    /// </summary>
    public partial class LiveForklfitsPage : Page
    {
        public LiveForklfitsPage(LiveForkliftsPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
