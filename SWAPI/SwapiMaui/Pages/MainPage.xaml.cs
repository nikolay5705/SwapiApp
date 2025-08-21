using SWAPI.Services.People;
using SwapiMaui.ViewModels;

namespace SwapiMaui;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(IPeopleService peopleService)
    {
        InitializeComponent();
        _viewModel = new MainViewModel(peopleService);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadPeopleAsync();
    }
}