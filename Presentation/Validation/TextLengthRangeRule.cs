namespace CalcMaui.Presentation.Validation;

public class TextLengthRangeRule<T>(double min, double max) : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = "Text Length must be greater than or equal to minimum.";

    public bool CheckValidity(T value)
    {
        var str = value as string ?? string.Empty;
        var strLength = str.Length;
        var numberRangeRule = new NumberRangeRule<int>(min, max);
        return numberRangeRule.CheckValidity(strLength);
    }
}