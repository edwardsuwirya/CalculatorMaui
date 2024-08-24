namespace CalcMaui.Presentation.Validation;

public class NumberRangeRule<T>(double min, double max) : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Number numbers must be greater than or equal to minimum.";

    public bool CheckValidity(T value)
    {
        var str = value as string ?? string.Empty;
        var isValid = double.TryParse(str, out var result);
        if (!isValid) return false;
        if (min > max) return false;

        return !(result < min) && !(result > max);
    }
}