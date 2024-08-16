using CalcMaui.Data.State;

namespace CalcMaui.Domain.Repository;

public interface ICalcRepository
{
    public Task<Result<long>> DoCalculate(int num1, int num2, string op);
}