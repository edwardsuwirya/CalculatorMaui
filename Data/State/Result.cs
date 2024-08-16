namespace CalcMaui.Data.State;

public readonly struct Result<T>
{
    public readonly ResultState State;
    public T Value { get; }
    public Exception? Exception { get; }

    public Result(T value)
    {
        Value = value;
        Exception = null;
        State = ResultState.Success;
    }

    public Result(Exception exception)
    {
        Value = default!;
        Exception = exception;
        State = ResultState.Failure;
    }

    
}