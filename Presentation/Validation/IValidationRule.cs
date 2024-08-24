namespace CalcMaui.Presentation.Validation;

public interface IValidationRule<T>
{
    string ValidationMessage { get; set; }
    bool CheckValidity(T value);
}