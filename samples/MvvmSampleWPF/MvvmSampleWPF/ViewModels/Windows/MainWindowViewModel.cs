using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmSampleWPF.Views.Pages;
using Wpf.Ui.Controls;

namespace MvvmSampleWPF.ViewModels.Windows
{
    public partial class MainWindowViewModel(IServiceProvider serviceProvider) : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        [ObservableProperty]
        private ObservableCollection<object> _menuItems =
       [
           new NavigationViewItem("Introduction", SymbolRegular.Play24,typeof(IntroductionPage)),
            new NavigationViewItemSeparator(),
            new NavigationViewItem()
            {
                Content = "Building Blocks",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Play24 },
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("ObservableObject", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("ObservableValidator", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("Inversion of control", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("Collections", SymbolRegular.Play24, typeof(IntroductionPage))
                },
            },
            new NavigationViewItem()
            {
                Content = "Putting things together",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Play24 },
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("Setting up the viewmodels", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem(){
                        Content = "Putting things together",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Play24 },
                MenuItemsSource = new object[]{
                    new NavigationViewItem("Building the settings service", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("Building the Reddit service", SymbolRegular.Play24, typeof(IntroductionPage))
                }
                    },
                    new NavigationViewItem("Building the UI", SymbolRegular.Play24, typeof(IntroductionPage))
                },
                TargetPageType=typeof(IntroductionPage)
            }


       ];


    }
}
