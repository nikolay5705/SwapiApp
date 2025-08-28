using SWAPI.DataManager.People;
using SWAPI.Mappers;
using SWAPI.Models;

namespace SwapiMaui.ViewModels;

public class PersonDetailViewModel : ViewModelBase
{
    public PersonDetailViewModel(PersonItemViewModel person)
    {
        SelectedPerson = person;
    }

    public PersonItemViewModel SelectedPerson { get; }

    // private readonly IPeopleManager _peopleManager;
    //
    // public PersonDetailViewModel(IPeopleManager peopleManager, string personId)
    // {
    //     _peopleManager = peopleManager;
    //     LoadPerson(personId);
    // }
    //
    // public PersonItemViewModel SelectedPerson { get; set; }
    //
    // private async void LoadPerson(string personId)
    // {
    //     var details = await _peopleManager.GetPeopleDetailsAsync(personId);
    //     SelectedPerson = new PersonItemViewModel(details.ToModel());
    // }
}