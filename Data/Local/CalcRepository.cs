using CalcMaui.Data.State;
using CalcMaui.Domain.Repository;

namespace CalcMaui.Data.Local;

public class CalcRepository : ICalcRepository
{
    public async Task<Result<long>> DoCalculate(int num1, int num2, string op)
    {
        await Task.Delay(2000);
        try
        {
            var result = op switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "/" => num1 / num2,
                "*" => num1 * num2,
                _ => throw new ArgumentOutOfRangeException()
            };
            return new Result<long>(result);
        }
        catch (Exception e)
        {
            return new Result<long>(e);
        }
    }
}