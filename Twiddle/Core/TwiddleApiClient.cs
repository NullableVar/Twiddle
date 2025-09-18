namespace Twiddle.Core;

public class TwiddleApiClient
{
    private readonly HttpClient _httpClient;

    public TwiddleApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.ClientBaseAddress);
    }
    
    
}