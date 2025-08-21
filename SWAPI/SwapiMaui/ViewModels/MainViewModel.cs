using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SWAPI.Caching;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.DataManager.Starships;
using SWAPI.Mappers;
using SWAPI.Models.Dtos;
using SWAPI.Models.Entities;
using SWAPI.Services.People;
using SWAPI.Services.Planets;
using SWAPI.Services.Requests;
using SWAPI.Services.Starships;
using SwapiMaui;
using SwapiMaui.ViewModels;

namespace SwapiMaui.ViewModels;

public class MainViewModel(IPeopleService peopleService) : ViewModelBase
{
    public ObservableCollection<PersonDto> People { get; } = new();

    public async Task LoadPeopleAsync()
    {
        People.Clear();
        var listOfPeople = await peopleService.GetPeopleAsync();

        if (listOfPeople?.Any() == true)
        {
            foreach (var person in listOfPeople)
                People.Add(person);
        }
    }
}