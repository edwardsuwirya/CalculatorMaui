using CalcMaui.ViewModels;

namespace CalcMaui;

public partial class CalcPage : ContentPage
{
    public CalcPage()
    {
        InitializeComponent();
        BindingContext = new CalcViewModel();
    }
}