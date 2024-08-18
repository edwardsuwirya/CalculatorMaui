namespace CalcMaui.Presentation.Navigation;

public interface IAppNavigation
{
    Task InitializeAsync();
    public Task NavigateTo(string route, IDictionary<string, object>? parameters);
    public Task PushModal(Page page);
    public Task PopModal();
}