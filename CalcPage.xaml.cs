using CalcMaui.ViewModels;

namespace CalcMaui;

public partial class CalcPage : ContentPage
{
    private int? _num1;
    private string? _operator;
    private int? _result = 0;

    private bool _isDoneCalc;

    public CalcPage()
    {
        InitializeComponent();
        BindingContext = new CalcViewModel();
    }

    private void ParsingNumber(string sNumber)
    {
        if (sNumber == "R")
        {
            CalcResultLabel.Text = "0";
        }
        else
        {
            if (_isDoneCalc)
            {
                _isDoneCalc = false;
                CalcResultLabel.Text = int.Parse(sNumber).ToString();
            }
            else
            {
                CalcResultLabel.Text = int.Parse(CalcResultLabel.Text + sNumber).ToString();
            }
        }
    }

    private void AssignToNumber(string opr)
    {
        _num1 ??= int.Parse(CalcResultLabel.Text);
        _operator = opr;
        ParsingNumber("R");
    }
    

    private void OnButtonEqualClick(Object s, EventArgs e)
    {
        var num2 = int.Parse(CalcResultLabel.Text);
        var num1 = _num1 ??= 0;
        switch (_operator)
        {
            case "+":
                _result = num1 + num2;
                break;
            case "-":
                _result = num1 - num2;
                break;
            case "/":
                _result = num1 / num2;
                break;
            case "*":
                _result = num1 * num2;
                break;
        }

        CalcResultLabel.Text = _result.ToString() ?? "0";
        _operator = null;
        _num1 = null;
        _result = 0;
        _isDoneCalc = true;
    }
    
}