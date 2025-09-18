using System.Net.Http.Json;
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

    public async Task<(bool, string)> LoginAsync(UserModel userModel)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/User/login", userModel);

        if (responseMessage.IsSuccessStatusCode)
            return (true, await responseMessage.Content.ReadAsStringAsync());
        
        return (false, await responseMessage.Content.ReadAsStringAsync());
    }

    public async Task<(bool, string)> RegisterAsync(UserModel userModel)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync("api/User/register", userModel);

        if (responseMessage.IsSuccessStatusCode)
            return (true, await responseMessage.Content.ReadAsStringAsync());
        
        return (false, await responseMessage.Content.ReadAsStringAsync());
    }
    
    public async Task<(bool, string)> GetUserByIdAsync(Guid id)
    {
        var resp = await _httpClient.GetAsync($"api/user/{id}");
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }
}