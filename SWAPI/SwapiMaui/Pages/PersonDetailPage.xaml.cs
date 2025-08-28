using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiMaui.ViewModels;

namespace SwapiMaui.Pages;

public partial class PersonDetailPage : ContentPage
{
    public PersonDetailPage(PersonDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}