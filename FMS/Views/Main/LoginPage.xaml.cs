using FMS.ViewModels.Main;
using System.Windows.Controls;

namespace FMS.Views.Main
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage(LoginPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
