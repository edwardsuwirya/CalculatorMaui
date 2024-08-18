using CalcMaui.Data.RequestClient;
using CalcMaui.Domain.Model;

namespace CalcMaui.Data.Remote;

public class CalcService(IRequestClient requestClient) : ICalcService
{
    private const string BaseUrl = "/calcApps/api/v1/calculation";

    public Task<MathCalculation?> CalcAsync(MathCalculation mathCalculation)
    {
        var uri = $"{GlobalSetting.Instance.BaseCalcEndpoint}{BaseUrl}";
        return requestClient.PostAsync<MathCalculation, MathCalculation>(uri, mathCalculation);
        // var uri = new Uri(string.Format("", string.Empty));
        // try
        // {
        //     var json = JsonSerializer.Serialize(mathCalculation, _serializerOptions);
        //     var content = new StringContent(json, Encoding.UTF8, "application/json");
        //
        //     var response = await httpClient.PostAsync("", content);
        //     if (!response.IsSuccessStatusCode)
        //         throw new HttpRequestException(
        //             $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).");
        //     
        //     var result = await response.Content.ReadAsStringAsync();
        //     return int.Parse(result);
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
    }
}