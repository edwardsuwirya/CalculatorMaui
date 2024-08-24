namespace CalcMaui.Presentation;

public class OnlyNumericBehavior : Behavior<Entry>
{
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
        var senderEntry = sender as Entry;
        var txt = senderEntry?.Text ?? String.Empty;
        if (senderEntry is null) return;
        try
        {
            double.Parse(args.NewTextValue);
        }
        catch (Exception e)
        {
            if (txt.Length > 0) senderEntry.Text = txt.Remove(txt.Length - 1);
        }
    }
}