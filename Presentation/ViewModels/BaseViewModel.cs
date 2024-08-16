using CalcMaui.Presentation.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalcMaui.Presentation.ViewModels;

public partial class BaseViewModel(IAppNavigation navigation) : ObservableObject
{
    protected IAppNavigation Navigation { get; } = navigation;

    protected async void OnLoadingModal()
    {
        await Navigation.PushModal(new LoadingPage());
    }

    protected async void OnDismissLoadingModal()
    {
        await Navigation.PopModal();
    }
}