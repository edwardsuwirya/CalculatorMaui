using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalcMaui.ViewModels;

public class CalcViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _displayText = "0";
    private string _operator = "";
    private string _calcOpr = "";
    private bool _isFinish;

    private int? num1;
    private int? num2;

    public string DisplayText
    {
        get => _displayText;
        set
        {
            _displayText = value;
            OnPropertyChanged();
        }
    }

    public string Operator
    {
        get => _operator;
        set
        {
            if (num1 != null)
            {
                _operator = value;
                if (!_operator.Equals("=")) return;
                num2 = int.Parse(DisplayText);
                Calculation();
                Reset();
                _isFinish = true;
            }
            else
            {
                if (!value.Equals("="))
                {
                    num1 = int.Parse(DisplayText);
                    DisplayText = "0";
                    _calcOpr = value;
                }
            }
        }
    }


    public ICommand DigitCommand { get; private set; }
    public ICommand OperatorCommand { get; private set; }

    private void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public CalcViewModel()
    {
        DigitCommand = new Command<string>((num) =>
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
        });

        OperatorCommand = new Command<string>((opr) => { Operator = opr; });
    }

    private void Reset()
    {
        num1 = null;
        num2 = null;
        _operator = "";
        _calcOpr = "";
    }

    private void Calculation()
    {
        var calcResult = 0;
        if (!num1.HasValue || !num2.HasValue) return;
        calcResult = _calcOpr switch
        {
            "+" => num1.Value + num2.Value,
            "-" => num1.Value - num2.Value,
            "/" => num1.Value / num2.Value,
            "*" => num1.Value * num2.Value,
            _ => calcResult
        };

        DisplayText = calcResult.ToString();
    }
}