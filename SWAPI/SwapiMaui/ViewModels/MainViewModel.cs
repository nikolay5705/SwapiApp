using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAPI.Caching;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.DataManager.Starships;
using SWAPI.Mappers;
using SWAPI.Models.Entities;
using SWAPI.Services.People;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SwapiMaui;
using SwapiMaui.ViewModels;

namespace SwapiMaui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IPeopleService _peopleService;

    public MainViewModel(IPeopleService peopleService)
    {
        _peopleService = peopleService;

        People = new ObservableCollection<PersonEntity>();
    }

    public ObservableCollection<PersonEntity> People { get; set; }

    public async Task LoadPeopleAsync()
    {
        await GetPeopleAsync();
    }

    private async Task GetPeopleAsync()
    {
        var listOfPeople = await _peopleService.GetPeopleAsync();

        People.Clear();

        if (listOfPeople?.Any() == true)
        {
            foreach (var person in listOfPeople)
            {
                People.Add(person.ToEntity());
            }
        }
    }
}