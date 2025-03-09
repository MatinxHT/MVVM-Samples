using MvvmSampleWPF.Services.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using Wpf.Ui;
using MvvmSampleWPF.ViewModels.Windows;
using MvvmSampleWPF.Views.Pages;

namespace MvvmSampleWPF.Views.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : IWindow
{
    public MainWindow(INavigationService navigationService, ISnackbarService snackbarService, IContentDialogService contentDialogService, MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
        navigationService.SetNavigationControl(RootNavigationView);
        snackbarService.SetSnackbarPresenter(SnackbarPresenter);
        contentDialogService.SetDialogHost(RootContentDialog);
    }

    private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
    {
        if (sender is not Wpf.Ui.Controls.NavigationView navigationView)
        {
            return;
        }

        RootNavigationView.SetCurrentValue(
            NavigationView.HeaderVisibilityProperty,
            navigationView.SelectedItem?.TargetPageType != typeof(IntroductionPage)
                ? Visibility.Visible
                : Visibility.Collapsed
        );
    }
}
