using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcMaui.Presentation.Validation;

namespace CalcMaui.Presentation;

public partial class SignUpPage : ContentPage
{
    private readonly ValidationObject<string> _userName = new();
    private readonly ValidationObject<string> _password = new();

    public SignUpPage()
    {
        InitializeComponent();
        _userName.Validations.Add(new IsNotNullOrEmptyRule<string>());
        _password.Validations.Add(new IsNotNullOrEmptyRule<string>());
        _password.Validations.Add(new TextLengthRangeRule<string>(6, 8));
        _password.Validations.Add(new PasswordComplexityRule<string>());
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Validate();
    }

    private void Validate()
    {
        _userName.Value = EntryUserName.Text;
        _password.Value = EntryPassword.Text;
        if (!_userName.Validate())
        {
            LabelUserNameError.Text = _userName.ToStringError();
            LabelUserNameError.IsVisible = true;
        }
        else
        {
            LabelUserNameError.Text = string.Empty;
            LabelUserNameError.IsVisible = false;
        }


        if (!_password.Validate())
        {
            LabelPasswordError.Text = _password.ToStringError();
            LabelPasswordError.IsVisible = true;
        }
        else
        {
            LabelPasswordError.Text = string.Empty;
            LabelPasswordError.IsVisible = false;
        }
    }
}