namespace LouisApp.Pages;

public partial class MonstersPage : ContentPage
{
    public MonstersPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ViewModels.MonstersViewModel vm)
        {
            await vm.LoadMonstersAsync();
        }
    }
    private async void OnMonsterSelected(object sender, SelectionChangedEventArgs e)
    {
    }
}