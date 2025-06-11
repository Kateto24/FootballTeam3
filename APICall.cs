public interface IApiService
{
    Task<string> GetDataAsync(string url);
}

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync(string url)
    {
        return await _httpClient.GetStringAsync(url);
    }
}
