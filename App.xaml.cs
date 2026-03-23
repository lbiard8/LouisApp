using Plugin.Maui.Audio;

namespace LouisApp;
public partial class App : Application
{
    private IAudioPlayer _player;
    public App(IAudioManager audioManager)
    {
        InitializeComponent();
        MainPage = new AppShell();
        PlayBackgroundMusic(audioManager);
    }

    private async void PlayBackgroundMusic(IAudioManager audioManager)
    {
        
        using var stream = await FileSystem.OpenAppPackageFileAsync("mhwi_seliana.wav");
        _player = audioManager.CreatePlayer(stream);
        _player.Loop = true;
        _player.Volume = 0.3;
        _player.Play();
        
    }

    protected override void OnSleep()
    {
        if (_player != null && _player.IsPlaying)
        {
            _player.Pause();
        }
    }

    protected override void OnResume()
    {
        if (_player != null && !_player.IsPlaying)
        {
            _player.Play();
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(MainPage);
    }
}