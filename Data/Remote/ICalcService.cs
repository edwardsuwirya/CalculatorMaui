using CalcMaui.Domain.Model;

namespace CalcMaui.Data.Remote;

public interface ICalcService
{
    Task<MathCalculation?> CalcAsync(MathCalculation mathCalculation);
}