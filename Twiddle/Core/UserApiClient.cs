using System.Net.Http.Json;
using Twiddle.Models;

namespace Twiddle.Core;

public class UserApiClient
{
    private readonly HttpClient _httpClient;

    public UserApiClient()
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
    
    public async Task<(bool, string)> GetUserByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return (false, "Email must be provided");

        var encoded = System.Net.WebUtility.UrlEncode(email.Trim());
        var response = await _httpClient.GetAsync($"api/User/by-email?email={encoded}");
        var content = await response.Content.ReadAsStringAsync();

        return (response.IsSuccessStatusCode, content);
    }
}