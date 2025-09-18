using Twiddle.Models;

namespace Twiddle.Core;

public class TwiddleApiClient
{
    private readonly HttpClient _httpClient;

    public TwiddleApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.ClientBaseAddress);
    }

    public async Task<(bool,string)> LoginAsync(UserModel userModel)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("user/login", userModel);

        if (responseMessage.IsSuccessStatusCode)
            return (true, await responseMessage.Content.ReadAsStringAsync());
        
        return (false, await responseMessage.Content.ReadAsStringAsync());
    }

    public async Task RegisterAsync(UserModel userModel)
    {
        
    }
}