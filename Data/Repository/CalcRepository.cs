using CalcMaui.Data.Remote;
using CalcMaui.Data.State;
using CalcMaui.Domain.Model;
using CalcMaui.Domain.Repository;
using CalcMaui.Exceptions;

namespace CalcMaui.Data.Repository;

public class CalcRepository(ICalcService calcService) : ICalcRepository
{
    public async Task<Result<MathCalculation>> DoCalculate(MathCalculation mathCalculation)
    {
        // await Task.Delay(2000);
        // try
        // {
        //     var result = op switch
        //     {
        //         "+" => num1 + num2,
        //         "-" => num1 - num2,
        //         "/" => num1 / num2,
        //         "*" => num1 * num2,
        //         _ => throw new ArgumentOutOfRangeException()
        //     };
        //     return new Result<long>(result);
        // }
        // catch (Exception e)
        // {
        //     return new Result<long>(e);
        // }

        try
        {
            var r = await calcService.CalcAsync(mathCalculation);
            return r is null
                ? new Result<MathCalculation>(new CalcResultException("Result empty"))
                : new Result<MathCalculation>(r);
        }
        catch (Exception)
        {
            return new Result<MathCalculation>(new CalcResultException("Calc service failed"));
        }
    }
}