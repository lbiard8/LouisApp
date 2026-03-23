using System.Text.Json.Serialization;

namespace LouisApp.Models;
public class Monster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string CustomImagePath { get; set; }
    [JsonPropertyName("weaknesses")]
    public List<Weakness> Weaknesses { get; set; } = new();
}
public class Weakness
{
    public string Element { get; set; }
    public int Stars { get; set; }
    public string Condition { get; set; }
}