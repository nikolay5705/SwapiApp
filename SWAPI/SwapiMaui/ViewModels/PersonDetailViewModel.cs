using CommunityToolkit.Mvvm.ComponentModel;
using SWAPI.DataManager.People;

namespace SwapiMaui.ViewModels;

public class PersonDetailViewModel : ViewModelBase
{
    private readonly IPeopleManager _peopleManager;

    public PersonDetailViewModel(string personId, IPeopleManager peopleManager)
    {
        _peopleManager = peopleManager;
        SelectedPersonId = personId;
        OnNavigatedTo();
    }

    public PersonItemViewModel SelectedPerson { get; set; }

    private string SelectedPersonId { get; } = string.Empty;

    protected override async Task InitializeAsync()
    {
        try
        {
            var detailsAboutPerson = await _peopleManager.GetPeopleDetailsAsync(SelectedPersonId);
            SelectedPerson = new PersonItemViewModel(detailsAboutPerson);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
}