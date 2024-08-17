namespace CalcMaui.Presentation.Pages;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}