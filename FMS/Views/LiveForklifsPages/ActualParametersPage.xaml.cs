using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy ActualParametersPage.xaml
    /// </summary>
    public partial class ActualParametersPage : Page
    {
        public ActualParametersPage(ActualParametersPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
