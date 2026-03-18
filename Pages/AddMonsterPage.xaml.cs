using LouisApp.Models;
using LouisApp.ViewModels;
namespace LouisApp.Pages;

public partial class AddMonsterPage : ContentPage
{
    private readonly ViewModels.MonstersViewModel _viewModel;
    string selectedImagePath = "";

    public AddMonsterPage(MonstersViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Sélectionnez l'image du monstre",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            selectedImagePath = result.FullPath;
            ImagePreview.Source = ImageSource.FromFile(selectedImagePath);
            ImagePreview.IsVisible = true;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryName.Text) || PickerType.SelectedIndex == -1)
        {
            await DisplayAlertAsync("Erreur", "Le nom et la taille sont obligatoires", "OK");
            return;
        }

        var newMonster = new Monster
        {
            Name = EntryName.Text,
            Type = PickerType.SelectedItem.ToString(),
            Description = EditorDesc.Text,
            CustomImagePath = selectedImagePath
        };

        _viewModel.AddCustomMonster(newMonster);
        EntryName.Text = string.Empty;
        EditorDesc.Text = string.Empty;
        PickerType.SelectedIndex = -1;
        selectedImagePath = string.Empty;
        ImagePreview.Source = null;
        ImagePreview.IsVisible = false;
        await Shell.Current.GoToAsync("//MonstersPage");
    }
}