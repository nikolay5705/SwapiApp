using SwapiMaui.ViewModels;

namespace SwapiMaui.Pages;

public partial class PersonDetailPage : ContentPage
{
    public PersonDetailPage(PersonDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}