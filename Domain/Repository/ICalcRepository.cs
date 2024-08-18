using CalcMaui.Data.State;
using CalcMaui.Domain.Model;

namespace CalcMaui.Domain.Repository;

public interface ICalcRepository
{
    public Task<Result<MathCalculation>> DoCalculate(MathCalculation mathCalculation);
}