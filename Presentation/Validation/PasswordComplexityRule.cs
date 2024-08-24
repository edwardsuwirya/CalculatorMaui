namespace CalcMaui.Presentation.Validation;

public class PasswordComplexityRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Password must be complex";

    public bool CheckValidity(T value)
    {
        var sPassword = value as string ?? string.Empty;
        var charArr = sPassword.ToCharArray();
        var isCharSymbolExist = false;
        var isNumericExist = false;
        var isUppercaseExist = false;
        foreach (var c in charArr)
        {
            if ("!@#$%^&*()_+=-?/.,<>:;'{}[]".Contains(c)) isCharSymbolExist = true;
            if ("1234567890".Contains(c)) isNumericExist = true;
            if (char.IsUpper(c)) isUppercaseExist = true;
        }

        return isNumericExist && isCharSymbolExist && isUppercaseExist;
    }
}