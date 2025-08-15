using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SwapiMaui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        IncreaseCommand = new RelayCommand(Increase);
        DecreaseCommand = new RelayCommand(Decrease);
    }

    public int Count { get; set; } = 0;

    public IRelayCommand IncreaseCommand { get; }

    public IRelayCommand DecreaseCommand { get; }

    private void Increase() => Count++;

    private void Decrease() => Count--;
}