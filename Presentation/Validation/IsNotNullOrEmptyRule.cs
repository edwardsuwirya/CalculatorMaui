namespace CalcMaui.Presentation.Validation;

public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Cannot be null or empty.";

    public bool CheckValidity(T value)
    {
        var str = value as string;
        var isIt = !string.IsNullOrWhiteSpace(str);
        return isIt;
    }
}