using CalcMaui.Data.Local;
using CalcMaui.Domain.Repository;
using CalcMaui.Presentation.Navigation;
using CalcMaui.Presentation.ViewModels;

namespace CalcMaui;

public partial class CalcPage : ContentPage
{
    public CalcPage()
    {
        InitializeComponent();
        IAppNavigation nav = new AppNavigation(Navigation);
        ICalcRepository repository = new CalcRepository();
        BindingContext = new CalcViewModel(nav, repository);
    }
}