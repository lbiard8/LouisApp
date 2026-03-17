using System.Collections.ObjectModel;
using LouisApp.Models;
using LouisApp.Services;

namespace LouisApp.ViewModels;

public class MonstersViewModel
{
    private readonly MonsterService _service = new MonsterService();
    public ObservableCollection<MonsterItemViewModel> Monsters { get; set; } = new();

    public async Task LoadMonstersAsync()
    {
        var monstersFromApi = await _service.GetMonstersAsync();

        Monsters.Clear();
        foreach (var monster in monstersFromApi)
        {
            Monsters.Add(new MonsterItemViewModel(monster));
        }
    }
}