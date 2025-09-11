using System.Collections.ObjectModel;
using System.Windows.Input;
using SWAPI.DataManager.People;
using SWAPI.DataManager.Planets;
using SWAPI.Mappers;
using SWAPI.Models;
using SWAPI.Models.Entities;
using SwapiMaui.Pages;

namespace SwapiMaui.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IPeopleManager _peopleManager;

    private readonly IPlanetsManager _planetsManager;

    private string _searchText = string.Empty;

    private List<PersonItemViewModel> _allPeople = new();

    public MainViewModel(IPeopleManager peopleManager, IPlanetsManager planetsManager)
    {
        _peopleManager = peopleManager;
        _planetsManager = planetsManager;
        GoToDetailCommand = new Command<PersonItemViewModel>(async person =>
        {
            if (person == null)
                return;
            var detailPage =
                new PersonDetailPage(new PersonDetailViewModel(person.Id, _peopleManager, _planetsManager));
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        });

        OnNavigatedTo();
    }

    public ObservableCollection<PersonItemViewModel> People { get; } = new();

    public ICommand GoToDetailCommand { get; }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                FilterPeople(_searchText);
            }
        }
    }

    protected override async Task InitializeAsync()
    {
        try
        {
            People.Clear();
            var listOfPeople = await _peopleManager.GetPeopleAsync();

            if (listOfPeople?.Any() == true)
            {
                _allPeople = listOfPeople
                    .Select(p => new PersonItemViewModel(p))
                    .ToList();

                foreach (var person in _allPeople)
                    People.Add(person);
                bool flag = true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }

    private void FilterPeople(string text)
    {
        People.Clear();

        var filtered = string.IsNullOrWhiteSpace(text)
            ? _allPeople
            : _allPeople.Where(p =>
                p.Name.Contains(text, StringComparison.OrdinalIgnoreCase));

        foreach (var person in filtered)
            People.Add(person);
    }
}