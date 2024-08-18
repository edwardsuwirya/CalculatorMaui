using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace CalcMaui.Data.RequestClient;

public class RequestClient : IRequestClient
{
    private readonly HttpClient _httpClient;

    public RequestClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<TResult?> PostAsync<TResult, TMessage>(string uri, TMessage data)
    {
        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _httpClient.PostAsync(uri, content).ConfigureAwait(false);
        HandleResponse(response);
        var result = await response.Content.ReadFromJsonAsync<TResult>().ConfigureAwait(false);
        return result;
    }

    public async Task<TResult?> GetAsync<TResult>(string uri)
    {
        var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);

        HandleResponse(response);

        var result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    private void HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(
                $"Response status code does not indicate success: {(int)response.StatusCode} ({response.StatusCode}).");
    }
}