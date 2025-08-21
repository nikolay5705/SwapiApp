using System.Collections.ObjectModel;
using SWAPI.DataManager.People;
using SWAPI.Mappers;
using SWAPI.Models.Entities;

namespace SwapiMaui.ViewModels.PersonItemViewModel;

public class PersonItemViewModel : ViewModelBase
{
    private readonly IPeopleManager _peopleManager;

    public PersonItemViewModel(IPeopleManager peopleManager)
    {
        _peopleManager = peopleManager;
    }

    public ObservableCollection<PersonEntity> People { get; } = new();

    public async Task LoadPeopleAsync()
    {
        People.Clear();
        var listOfPeople = await _peopleManager.GetPeopleAsync();

        if (listOfPeople?.Any() == true)
        {
            foreach (var person in listOfPeople)
                People.Add(person.ToEntity());
        }
    }
}