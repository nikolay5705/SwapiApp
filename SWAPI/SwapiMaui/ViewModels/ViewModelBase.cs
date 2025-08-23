using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SwapiMaui.ViewModels;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    protected ViewModelBase()
    {
        InitCommand = new AsyncRelayCommand(InitializeAsync);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public IAsyncRelayCommand InitCommand { get; }

    public virtual void OnNavigatedTo()
    {
        InitCommand.Execute(null);
    }

    protected virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}