using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SwapiMaui.ViewModels;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}