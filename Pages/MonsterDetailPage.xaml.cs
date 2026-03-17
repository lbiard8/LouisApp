using LouisApp.Models;
using LouisApp.ViewModels;

namespace LouisApp.Pages;

public partial class MonsterDetailPage : ContentPage
{
    public MonsterDetailPage(Monster monster)
    {
        InitializeComponent();
        BindingContext = new MonsterItemViewModel(monster);
    }
}