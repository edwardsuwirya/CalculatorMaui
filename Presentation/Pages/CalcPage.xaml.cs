using CalcMaui.Domain.Repository;
using CalcMaui.Presentation.Navigation;
using CalcMaui.Presentation.ViewModels;

namespace CalcMaui.Presentation.Pages;

public partial class CalcPage : ContentPage
{
    public CalcPage(IAppNavigation nav, ICalcRepository repository)
    {
        InitializeComponent();
        BindingContext = new CalcViewModel(nav, repository);
    }
}