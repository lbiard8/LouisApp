using Microsoft.Maui.Controls;

namespace LouisApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnGifButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GifPage());
    }
}