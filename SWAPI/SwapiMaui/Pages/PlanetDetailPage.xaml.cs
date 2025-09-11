using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiMaui.ViewModels;

namespace SwapiMaui.Pages;

public partial class PlanetDetailPage : ContentPage
{
    public PlanetDetailPage(PersonDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}