namespace CalcMaui.Presentation.Navigation;

public interface IAppNavigation
{
    public Task NavigateTo(string route, IDictionary<string, object>? parameters);
    public Task PushModal(Page page);
    public Task PopModal();
}