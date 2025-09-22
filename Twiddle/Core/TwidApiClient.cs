using System.Net.Http.Json;
using Twiddle.Models;

namespace Twiddle.Core;

public class TwidApiClient
{
    private readonly HttpClient _httpClient;

    public TwidApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(Constants.ClientBaseAddress)
        };
    }

    public async Task<(bool, string)> GetAllAsync()
    {
        var resp = await _httpClient.GetAsync("api/Twid");
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }

    public async Task<(bool, string)> GetByIdAsync(Guid id)
    {
        var resp = await _httpClient.GetAsync($"api/Twid/{id}");
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }

    public async Task<(bool, string)> GetByUserIdAsync(Guid userId)
    {
        var resp = await _httpClient.GetAsync($"api/Twid/User/{userId}");
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }

    public async Task<(bool, string)> CreateAsync(TwidModel twidModel)
    {
        var resp = await _httpClient.PostAsJsonAsync("api/Twid", twidModel);
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }

    public async Task<(bool, string)> UpdateAsync(TwidModel twidModel)
    {
        if (twidModel.Id == Guid.Empty)
            return (false, "TwidModel must have a valid Id for update");

        var resp = await _httpClient.PutAsJsonAsync($"api/Twid/{twidModel.Id}", twidModel);
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }
}