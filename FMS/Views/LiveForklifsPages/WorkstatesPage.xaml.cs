using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy WorkstatesPage.xaml
    /// </summary>
    public partial class WorkstatesPage : Page
    {
        public WorkstatesPage(WorkstatesPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
