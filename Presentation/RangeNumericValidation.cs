using CalcMaui.Presentation.Validation;

namespace CalcMaui.Presentation;

public class RangeNumericValidation : Behavior<Entry>
{
    public event EventHandler<string> OnError;

    public string MinNumber
    {
        get => (string)GetValue(MinNumProperty);
        set => SetValue(MinNumProperty, value);
    }

    public string MaxNumber
    {
        get => (string)GetValue(MaxNumProperty);
        set => SetValue(MaxNumProperty, value);
    }

    public static readonly BindableProperty MinNumProperty =
        BindableProperty.Create(nameof(MinNumber), typeof(string), typeof(RangeNumericValidation));

    public static readonly BindableProperty MaxNumProperty =
        BindableProperty.Create(nameof(MinNumber), typeof(string), typeof(RangeNumericValidation));
    // public static readonly BindableProperty MinProperty =
    //     BindableProperty.CreateAttached("MinProperty", typeof(double), typeof(MinNumericValidation), false,
    //         propertyChanged: OnAttachBehaviorChanged);
    //
    // public static double GetMinProperty(BindableObject view)
    // {
    //     return (double)view.GetValue(MinProperty);
    // }
    //
    // public static void SetMinProperty(BindableObject view, double value)
    // {
    //     view.SetValue(MinProperty, value);
    // }
    //
    // static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
    // {
    //     Entry entry = view as Entry;
    //     if (entry == null)
    //     {
    //         return;
    //     }
    //
    //     double attachBehavior = (double)newValue;
    // }

    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs args)
    {
        var rangeValidationObject = new ValidationObject<string>
        {
            Value = args.NewTextValue
        };
        
        rangeValidationObject.Validations.Add(new NumberRangeRule<string>(Convert.ToDouble(MinNumber), Convert.ToDouble(MaxNumber))
        {
            ValidationMessage = "Number is not within range"
        });
        var isValid = rangeValidationObject.Validate();

        // ((Entry)sender).TextColor = result >= minNum && result <= maxNum ? Colors.Black : Colors.Red;
        if (isValid) return;
        var errMessage = string.Join(",", rangeValidationObject.Errors);
        OnError?.Invoke(this, errMessage);
    }
}