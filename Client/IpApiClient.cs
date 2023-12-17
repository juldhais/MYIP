namespace MYIP.Client;

public class IpApiClient(HttpClient httpClient)
{
    private const string BASE_URL = "http://ip-api.com";
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IpApiResponse?> Get(string? ipAddress, CancellationToken ct)
    {
        var route = $"{BASE_URL}/json/{ipAddress}";
        var response = await _httpClient.GetFromJsonAsync<IpApiResponse>(route, ct);
        return response;
    }
}
