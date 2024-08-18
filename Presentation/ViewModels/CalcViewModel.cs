using CalcMaui.Data.State;
using CalcMaui.Domain.Model;
using CalcMaui.Domain.Repository;
using CalcMaui.Presentation.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalcMaui.Presentation.ViewModels;

public partial class CalcViewModel : BaseViewModel
{
    private string _operatorText = "";
    private bool _isFinish;

    private int _num1 = 0;
    private int _num2 = 0;

    [ObservableProperty] private string _displayText = "0";

    public AsyncRelayCommand CalculateAsyncRelayCommand { get; }
    private readonly ICalcRepository _calcRepository;

    public CalcViewModel(IAppNavigation navigation, ICalcRepository repository) : base(navigation)
    {
        CalculateAsyncRelayCommand = new AsyncRelayCommand(AsyncCalculate);
        _calcRepository = repository;
    }

    [RelayCommand]
    private void Digit(string num)
    {
        if (_isFinish)
        {
            DisplayText = "0";
            _isFinish = false;
        }

        DisplayText += num;
        if (DisplayText.StartsWith("0"))
        {
            DisplayText = DisplayText.Substring(1);
        }
    }

    [RelayCommand]
    private void Operator(string opr)
    {
        _num1 = int.Parse((string)DisplayText);
        DisplayText = "0";
        _operatorText = opr;
    }

    [RelayCommand]
    private void Calculate()
    {
        _num2 = int.Parse((string)DisplayText);
        // DisplayText = DoCalculate(_num1, _num2, _operatorText).ToString();
        Reset();
        _isFinish = true;
    }

    private async Task AsyncCalculate()
    {
        try
        {
            OnLoadingModal();
            _num2 = int.Parse((string)DisplayText);

            var matchCalc = new MathCalculation
            {
                Num1 = _num1,
                Num2 = _num2,
                Opr = _operatorText
            };
            var r = await _calcRepository.DoCalculate(matchCalc);
            r.DisplayResult(successAction: () =>
            {
                DisplayText = r.Value.Result.ToString();
                OnDismissLoadingModal();
            }, failureAction: () =>
            {
                DisplayText = r.Exception?.Message ?? string.Empty;
                OnDismissLoadingModal();
            });
            Reset();
            _isFinish = true;
        }
        catch (Exception e)
        {
            OnDismissLoadingModal();
        }
    }

    private void Reset()
    {
        _num1 = 0;
        _num2 = 0;
        _operatorText = "";
    }
}