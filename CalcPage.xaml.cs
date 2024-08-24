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

    private void OnButtonAdditionClick(Object s, EventArgs e)
    {
        AssignToNumber("+");
    }

    private void OnButtonSubtractionClick(Object s, EventArgs e)
    {
        AssignToNumber("-");
    }

    private void OnButtonDivisionClick(Object s, EventArgs e)
    {
        AssignToNumber("/");
    }

    private void OnButtonMultiplicationClick(Object s, EventArgs e)
    {
        AssignToNumber("*");
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

    private void OnButtonNum1Click(Object s, EventArgs e)
    {
        ParsingNumber("1");
    }

    private void OnButtonNum2Click(Object s, EventArgs e)
    {
        ParsingNumber("2");
    }

    private void OnButtonNum3Click(Object s, EventArgs e)
    {
        ParsingNumber("3");
    }

    private void OnButtonNum4Click(Object s, EventArgs e)
    {
        ParsingNumber("4");
    }

    private void OnButtonNum5Click(Object s, EventArgs e)
    {
        ParsingNumber("5");
    }

    private void OnButtonNum6Click(Object s, EventArgs e)
    {
        ParsingNumber("6");
    }

    private void OnButtonNum7Click(Object s, EventArgs e)
    {
        ParsingNumber("7");
    }

    private void OnButtonNum8Click(Object s, EventArgs e)
    {
        ParsingNumber("8");
    }

    private void OnButtonNum9Click(Object s, EventArgs e)
    {
        ParsingNumber("9");
    }

    private void OnButtonNum0Click(Object s, EventArgs e)
    {
        ParsingNumber("0");
    }

    private void RangeNumericValidation_OnError(object? sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}