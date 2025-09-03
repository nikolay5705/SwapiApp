using System.Collections.ObjectModel;
using System.Diagnostics;
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

    public string Height { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Mass { get; set; } = string.Empty;

    public string SkinColor { get; set; } = string.Empty;

    public string EyeColor { get; set; } = string.Empty;

    protected override async Task InitializeAsync()
    {
        try
        {
            var detailsAboutPerson = await _peopleManager.GetPeopleDetailsAsync(SelectedPersonId);
            SelectedPerson = new PersonItemViewModel(detailsAboutPerson);
            Height = SelectedPerson.Height;
            Name = SelectedPerson.Name;
            Mass = SelectedPerson.Mass;
            SkinColor = SelectedPerson.SkinColor;
            EyeColor = SelectedPerson.EyeColor;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}