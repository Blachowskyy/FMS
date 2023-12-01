using FMS.ViewModels.LiveForkliftsPages;
using System.Windows.Controls;

namespace FMS.Views.LiveForklifsPages
{
    /// <summary>
    /// Logika interakcji dla klasy SafetyDataPage.xaml
    /// </summary>
    public partial class SafetyDataPage : Page
    {
        public SafetyDataPage(SafetyDataPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
