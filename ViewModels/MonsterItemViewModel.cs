using LouisApp.Models;

namespace LouisApp.ViewModels;
public class MonsterItemViewModel
{
    public Monster Monster { get; }

    public MonsterItemViewModel(Monster monster)
    {
        Monster = monster;
    }

    public ImageSource MonsterImage
    {
        get
        {
            if (!string.IsNullOrEmpty(Monster.CustomImagePath))
            {
                return ImageSource.FromFile(Monster.CustomImagePath);
            }

            string formattedName = Monster.Name.Replace(" ", "_");

            if (Monster.Name.Contains("Safi'jiiva"))
                formattedName = "Safijiiva";
            else if (Monster.Name.Contains("Xeno'jiiva"))
                formattedName = "Xenojiiva";

            if (formattedName == "Kestodon")
                formattedName = "Kestodon_Male";

            string prefix = "MHW";
            string[] iceborneMonsters = { "Zinogre", "Namielle", "Viper Tobi-Kadachi", "Rajang", "Stygian Zinogre", "Safi'jiiva" };

            if (iceborneMonsters.Contains(Monster.Name))
            {
                prefix = "MHWI";
            }

            return $"https://raw.githubusercontent.com/CrimsonNynja/monster-hunter-DB/master/icons/{prefix}-{formattedName}_Icon.png";
        }
    }
}