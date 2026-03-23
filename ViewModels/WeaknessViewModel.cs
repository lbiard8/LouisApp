using System.Collections.ObjectModel;
using LouisApp.Models;
using LouisApp.Services;
using System.Linq;

namespace LouisApp.ViewModels;

public class WeaknessViewModel : BindableObject
{
    private readonly MonsterService _service = new();
    private List<Monster> _allMonsters = new();
    private string _selectedElement = "Fire";
    private string _lastSearchText = "";

    public ObservableCollection<MonsterWeakness> FilteredMonsters { get; set; } = new();

    private string _weaponDamage = "100";
    public string WeaponDamage
    {
        get => _weaponDamage;
        set
        {
            _weaponDamage = value;
            OnPropertyChanged();
            Search(_lastSearchText);
        }
    }


    public async Task InitAsync()
    {
        if (_allMonsters.Count > 0) return;
        _allMonsters = await _service.GetMonstersAsync();
        Search("");
    }

    public string SelectedElement
    {
        get => _selectedElement;
        set
        {
            _selectedElement = value;
            OnPropertyChanged();
            Search(_lastSearchText);
        }
    }

    public void Search(string text)
    {
        _lastSearchText = text;

        var results = string.IsNullOrWhiteSpace(text)
            ? _allMonsters
            : _allMonsters.Where(m => m.Name.ToLower().Contains(text.ToLower())).ToList();

        FilteredMonsters.Clear();
        double.TryParse(WeaponDamage, out double baseDamage);

        foreach (var m in results)
        {
            var bestWeakness = m.Weaknesses?
                .OrderByDescending(w => w.Stars)
                .FirstOrDefault();

            string topElement = bestWeakness?.Element ?? "Physique";
            int topStars = bestWeakness?.Stars ?? 0;
            var match = m.Weaknesses?
                .FirstOrDefault(w => w.Element.ToLower() == SelectedElement.ToLower());

            int starsForMyWeapon = match?.Stars ?? 0;
            double multiplier = 1.0;
            if (starsForMyWeapon == 3) multiplier = 1.35;
            else if (starsForMyWeapon == 2) multiplier = 1.15; 
            else if (starsForMyWeapon == 1) multiplier = 1.05; 
            else if (SelectedElement != "Physique") multiplier = 0.85; 

            var tempVm = new MonsterItemViewModel(m);

            FilteredMonsters.Add(new MonsterWeakness
            {
                Name = m.Name,
                WeakElement = $"{topElement.ToUpper()} (★{topStars})",
                ElementColor = GetElementColor(topElement),
                FinalDamage = baseDamage * multiplier,
                MonsterImage = tempVm.MonsterImage
            });
        }
    }

    private Color GetElementColor(string element)
    {
        return element.ToLower() switch
        {
            "fire" => Color.FromArgb("#B22222"), 
            "water" => Color.FromArgb("#1E90FF"), 
            "thunder" => Color.FromArgb("#DAA520"), 
            "ice" => Color.FromArgb("#00CED1"),
            "dragon" => Color.FromArgb("#8B008B"),

            "poison" => Color.FromArgb("#4B0082"),
            "sleep" => Color.FromArgb("#4682B4"), 
            "paralysis" => Color.FromArgb("#E9967A"),
            "blast" => Color.FromArgb("#A52A2A"), 
            "stun" => Color.FromArgb("#BDB76B"),
        };
    }
}