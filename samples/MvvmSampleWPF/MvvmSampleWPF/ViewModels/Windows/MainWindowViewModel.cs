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
                Icon = new SymbolIcon { Symbol = SymbolRegular.TableSettings24 },
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem(){
                         Content = "Source generators",
                Icon = new SymbolIcon { Symbol = SymbolRegular.ApprovalsApp20 },
                MenuItemsSource = new object[]{
                     new NavigationViewItem("[ObservableProperty]", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("[RelayCommand]", SymbolRegular.VehicleShip24, typeof(IntroductionPage)),
                    new NavigationViewItem("[INotifyPropertyChanged ]", SymbolRegular.ArrowSortDownLines16, typeof(IntroductionPage))
                }
                    },
                    new NavigationViewItem("ObservableObject", SymbolRegular.Accessibility24, typeof(IntroductionPage)),
                    new NavigationViewItem("ObservableValidator", SymbolRegular.ScanDash16, typeof(IntroductionPage)),
                    new NavigationViewItem("Inversion of control", SymbolRegular.Tabs20, typeof(IntroductionPage)),
                    new NavigationViewItem("Collections", SymbolRegular.SurfaceEarbuds24, typeof(IntroductionPage))
                },
            },
            new NavigationViewItem()
            {
                Content = "Putting things together",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Apps24 },
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("Setting up the viewmodels", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem(){
                        Content = "Creating a Service",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Play24 },
                MenuItemsSource = new object[]{
                    new NavigationViewItem("Settings Service", SymbolRegular.Play24, typeof(IntroductionPage)),
                    new NavigationViewItem("Reddit service", SymbolRegular.Play24, typeof(IntroductionPage))
                }
                    },
                    new NavigationViewItem("Building the UI", SymbolRegular.Play24, typeof(IntroductionPage))
                },
                TargetPageType=typeof(IntroductionPage)
            }


       ];


    }
}
