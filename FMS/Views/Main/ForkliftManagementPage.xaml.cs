using FMS.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
