namespace CalcMaui.Data.State;

public static class ResultStateExt
{
    public static void DisplayResult<T>(this Result<T> result, Action successAction, Action failureAction)
    {
        switch (result.State)
        {
            case ResultState.Success:
                successAction();
                break;
            case ResultState.Failure:
                failureAction();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}