﻿using FMS.ViewModels.Main;
using System.Windows.Controls;

namespace FMS.Views.Main
{
    /// <summary>
    /// Logika interakcji dla klasy UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage(UsersPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
