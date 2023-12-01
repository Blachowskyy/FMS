using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy ErrorsPage.xaml
    /// </summary>
    public partial class ErrorsPage : Page
    {
        public ErrorsPage(ErrorsPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
