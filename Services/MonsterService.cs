using System.Net.Http.Json;
using LouisApp.Models;

namespace LouisApp.Services;

public class MonsterService
{
    private readonly HttpClient _httpClient;

    public MonsterService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Monster>> GetMonstersAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Monster>>("https://mhw-db.com/monsters");
            return response ?? new List<Monster>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erreur API : {ex.Message}");
            return new List<Monster>();
        }
    }
}