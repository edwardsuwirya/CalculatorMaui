using CalcMaui.Presentation.Navigation;

namespace CalcMaui.Presentation.Pages;

public partial class AppShell : Shell
{
    private readonly IAppNavigation _appNavigation;

    public AppShell(IAppNavigation appNavigation)
    {
        _appNavigation = appNavigation;
        InitializeComponent();
    }

    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is not null)
        {
            await _appNavigation.InitializeAsync();
        }
    }
}