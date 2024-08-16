namespace CalcMaui.Presentation.Navigation;

public class AppNavigation(INavigation appNavigation) : IAppNavigation
{
    public Task NavigateTo(string route, IDictionary<string, object>? parameters)
    {
        return parameters is null ? Shell.Current.GoToAsync(route) : Shell.Current.GoToAsync(route, parameters);
    }

    public Task PushModal(Page page)
    {
        return appNavigation.PushModalAsync(page);
    }

    public Task PopModal()
    {
        return appNavigation.PopModalAsync();
    }
}