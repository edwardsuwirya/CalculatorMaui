using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalcMaui.ViewModels;

public class CalcViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _displayText = "0";
    private string _operator = "";
    private bool _isFinish;
    private bool _isLoading;

    private int _num1 = 0;
    private int _num2 = 0;

    public string DisplayText
    {
        get => _displayText;
        set
        {
            _displayText = value;
            OnPropertyChanged();
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public string Operator
    {
        get => _operator;
        set
        {
            _num1 = int.Parse(DisplayText);
            DisplayText = "0";
            _operator = value;
        }
    }


    public ICommand DigitCommand { get; private set; }
    public ICommand OperatorCommand { get; private set; }
    public ICommand CalculateCommand { get; private set; }


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

        CalculateCommand = new Command(() =>
        {
            _num2 = int.Parse(DisplayText);
            DisplayText = Calculate(_num1, _num2, Operator).ToString();
            Reset();
            _isFinish = true;
        });
    }

    private void Reset()
    {
        _num1 = 0;
        _num2 = 0;
        _operator = "";
    }
    
    private int Calculate(int value1, int value2, string mathOperator)
    {
        return mathOperator switch
        {
            "+" => value1 + value2,
            "-" => value1 - value2,
            "/" => value1 / value2,
            "*" => value1 * value2,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}