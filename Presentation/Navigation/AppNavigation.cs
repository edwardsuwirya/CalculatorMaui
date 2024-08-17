namespace CalcMaui.Presentation.Navigation;

public class AppNavigation : IAppNavigation
{
    private INavigation PageNav
    {
        get
        {
            var pageNavigation = Application.Current?.MainPage?.Navigation;
            if (pageNavigation is not null)
            {
                return pageNavigation;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public Task NavigateTo(string route, IDictionary<string, object>? parameters)
    {
        return parameters is null ? Shell.Current.GoToAsync(route) : Shell.Current.GoToAsync(route, parameters);
    }

    public Task PushModal(Page page)
    {
        return PageNav.PushModalAsync(page);
    }

    public Task PopModal()
    {
        return PageNav.PopModalAsync();
    }
}