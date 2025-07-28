namespace MauiWakeOnLan;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Current!.UserAppTheme = AppTheme.Dark;
        return new Window(new MainPage()) { Width = 270, Height = 270};
    }
}