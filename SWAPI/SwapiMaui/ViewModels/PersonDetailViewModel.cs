using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.VisualBasic.CompilerServices;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.Utils;

namespace SwapiMaui.ViewModels;

public class PersonDetailViewModel : ViewModelBase
{
    private readonly IPeopleManager _peopleManager;

    private readonly IPlanetsManager _planetManager;

    public PersonDetailViewModel(string personId, IPeopleManager? peopleManager, IPlanetsManager? planetManager)
    {
        _peopleManager = peopleManager;
        _planetManager = planetManager;
        SelectedPersonId = personId;
        OnNavigatedTo();
    }

    public PersonItemViewModel SelectedPerson { get; set; }

    public string SelectedPersonId { get; } = string.Empty;

    public string HomeWorldId { get; set; } = string.Empty;

    public string Homeworld { get; set; } = string.Empty;

    public string Climate { get; set; } = string.Empty;

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

            var detailsAboutPlanet = await _planetManager.GetPlanetDetailsAsync(SelectedPerson.HomeWorldId);
            Homeworld = detailsAboutPlanet.Name;
            Climate = detailsAboutPlanet.Climate;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}