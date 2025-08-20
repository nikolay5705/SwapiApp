using SwapiMaui.ViewModels;

namespace SwapiMaui;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.People == null || !_viewModel.People.Any())
        {
            await _viewModel.LoadPeopleAsync();
        }
    }
}