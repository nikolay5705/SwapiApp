using SWAPI.DataManager.People;

namespace SwapiMaui.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(IPeopleManager peopleManager)
    {
        PeopleViewModel = new PersonItemViewModel.PersonItemViewModel(peopleManager);
    }

    public PersonItemViewModel.PersonItemViewModel PeopleViewModel { get; }

    public async Task LoadAllDataAsync()
    {
        await PeopleViewModel.LoadPeopleAsync();
    }
}