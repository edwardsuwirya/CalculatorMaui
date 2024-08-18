namespace CalcMaui.Data.RequestClient;

public interface IRequestClient
{
    Task<TResult?> PostAsync<TResult, TMessage>(string uri, TMessage data);
    Task<TResult?> GetAsync<TResult>(string uri);
}