namespace LouisApp.Pages;

public partial class WeaknessPage : ContentPage
{
    private ViewModels.WeaknessViewModel _vm;
    public WeaknessPage()
    {
        InitializeComponent();
        _vm = new ViewModels.WeaknessViewModel();
        BindingContext = _vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitAsync();
    }

    private void OnElementChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex != -1)
        {
            _vm.SelectedElement = (string)picker.SelectedItem;
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _vm.Search(e.NewTextValue);
    }
}