using System;
using System.Collections.Generic;
using System.Text;

namespace LouisApp.Models;
public class Monster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string ImageUrl
    {
        get
        {
            string formattedName = Name.Replace(" ", "_");

            if (formattedName.Contains("Safi'jiiva"))
                formattedName = "Safijiiva";
            else if (Name.Contains("Xeno'jiiva"))
            {
                formattedName = "Xenojiiva";
            }

            if (formattedName == "Kestodon")
                formattedName = "Kestodon_Male";

            string prefix = "MHW";

            string[] iceborneMonsters = { "Zinogre", "Namielle", "Viper Tobi-Kadachi", "Rajang", "Stygian Zinogre", "Safi'jiiva"};

            if (iceborneMonsters.Contains(Name))
            {
                prefix = "MHWI";
            }

            return $"https://raw.githubusercontent.com/CrimsonNynja/monster-hunter-DB/master/icons/{prefix}-{formattedName}_Icon.png";
        }
    }
}