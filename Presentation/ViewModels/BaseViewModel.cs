using CalcMaui.Presentation.Navigation;
using CalcMaui.Presentation.Pages;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalcMaui.Presentation.ViewModels;

public abstract class BaseViewModel(IAppNavigation navigation) : ObservableObject
{
    private IAppNavigation Navigation { get; } = navigation;

    protected async void OnLoadingModal()
    {
        await Navigation.PushModal(new LoadingPage());
    }

    protected async void OnDismissLoadingModal()
    {
        await Navigation.PopModal();
    }
}