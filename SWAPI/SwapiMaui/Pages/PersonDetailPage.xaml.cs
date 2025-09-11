using SwapiMaui.ViewModels;

namespace SwapiMaui.Pages;

public partial class PersonDetailPage : ContentPage
{
    private PersonDetailViewModel _viewModel;

    public PersonDetailPage(PersonDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new PlanetDetailPage(_viewModel));
    }
}