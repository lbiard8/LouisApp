using System.Collections.ObjectModel;
using LouisApp.Models;
using LouisApp.Services;

namespace LouisApp.ViewModels;

public class MonstersViewModel
{
    private readonly MonsterService _service = new MonsterService();
    public ObservableCollection<MonsterItemViewModel> Monsters { get; set; } = new();
    private bool _isApiLoaded = false;

    public async Task LoadMonstersAsync()
    {
        if (_isApiLoaded) return;

        var monstersFromApi = await _service.GetMonstersAsync();

        foreach (var monster in monstersFromApi)
        {
            Monsters.Add(new MonsterItemViewModel(monster));
        }
        _isApiLoaded = true;
    }

    public void AddCustomMonster(Monster newMonster)
    {
        Monsters.Insert(0, new MonsterItemViewModel(newMonster));
    }
}