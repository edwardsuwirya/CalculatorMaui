namespace CalcMaui.Exceptions;

public class CalcResultException : Exception
{
    public string Content { get; }

    public CalcResultException()
    {
    }

    public CalcResultException(string content)
    {
        Content = content;
    }
}