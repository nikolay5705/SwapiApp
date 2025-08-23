using System.Collections.ObjectModel;
using SWAPI.DataManager.People;
using SWAPI.Mappers;
using SWAPI.Models.Entities;

namespace SwapiMaui.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IPeopleManager _peopleManager;

    public MainViewModel(IPeopleManager peopleManager)
    {
        _peopleManager = peopleManager;
        OnNavigatedTo();
    }

    public ObservableCollection<PersonItemViewModel> People { get; } = new();

    protected override async Task InitializeAsync()
    {
        try
        {
            People.Clear();
            var listOfPeople = await _peopleManager.GetPeopleAsync();

            if (listOfPeople?.Any() == true)
            {
                foreach (var person in listOfPeople)
                    People.Add(new PersonItemViewModel(person));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
}