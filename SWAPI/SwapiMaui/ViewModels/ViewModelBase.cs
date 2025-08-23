using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SwapiMaui.ViewModels;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    private bool _isInitialized;

    protected ViewModelBase()
    {
        InitCommand = new AsyncRelayCommand(InitializeAsync);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public IAsyncRelayCommand InitCommand { get; }

    public virtual async Task OnNavigatedToAsync()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        await InitCommand.ExecuteAsync(null);
    }

    protected virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}