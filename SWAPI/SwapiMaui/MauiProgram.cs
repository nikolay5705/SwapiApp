using Microsoft.Extensions.Logging;
using SWAPI.Caching;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.DataManager.Starships;
using SWAPI.Models.Entities;
using SWAPI.Services.People;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SwapiMaui.ViewModels;

namespace SwapiMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddScoped<IPeopleManager, PeopleManager>();
        builder.Services.AddScoped<IPlanetsManager, PlanetsManager>();
        builder.Services.AddScoped<IStarshipsManager, StarshipsManager>();

        builder.Services.AddScoped<IPeopleService, PeopleService>();
        builder.Services.AddScoped<IPlanetsService, PlanetService>();
        builder.Services.AddScoped<IStarshipsService, StarshipsService>();
        builder.Services.AddScoped<IRequestService, RequestService>();

        builder.Services.AddSingleton<IRepository<PersonEntity>, MemoryRepository<PersonEntity>>();
        builder.Services.AddSingleton<IRepository<PlanetEntity>, MemoryRepository<PlanetEntity>>();
        builder.Services.AddSingleton<IRepository<StarshipEntity>, MemoryRepository<StarshipEntity>>();

        // ViewModels
        builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}