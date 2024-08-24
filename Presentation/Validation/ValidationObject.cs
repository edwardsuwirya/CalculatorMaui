namespace CalcMaui.Presentation.Validation;

public class ValidationObject<T>
{
    public IEnumerable<string> Errors { get; private set; } = [];
    private bool _isValid = true;
    public T Value;

    public List<IValidationRule<T>> Validations = [];

    public bool Validate()
    {
        // Errors = Validations.Where(v => v.CheckValidity(Value)).Select(v => v.ValidationMessage).ToArray();
        Errors =
            from v in Validations
            where v.CheckValidity(Value) == false
            select v.ValidationMessage;

        _isValid = !Errors.Any();
        return _isValid;
    }

    public string ToStringError()
    {
        return string.Join(",", Errors);
    }
}