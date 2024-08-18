using CalcMaui.Presentation.Navigation;

namespace CalcMaui.Presentation.Pages;

public partial class App : Application
{
    public App(IAppNavigation navigation)
    {
        InitializeComponent();

        MainPage = new AppShell(navigation);
    }
}