using SWAPI.Caching;
using SWAPI.DataManager.People;
using SWAPI.Models.Entities;
using SWAPI.Services.People;
using SWAPI.Services.Requests;
using SwapiMaui.ViewModels;

namespace SwapiMaui;

public partial class App : Application
{
    public App(MainPage mainPage)
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}