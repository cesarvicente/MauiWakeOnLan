using Microsoft.Maui.Controls;

namespace MauiWakeOnLan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            carouselView.ItemsSource = LoadButtons();
        }

        private void btnWakeLan_Clicked()
        {
            carouselView.IsEnabled = false;
            var computer = new Models.Device()
            {
                Name = "Cesar PC",
                MacAddress = "04:D4:C4:56:31:64",
                HostName = "192.168.3.100",
            };
            computer.Wake();
            AnimateIcon();
            carouselView.IsEnabled = true;
        }

        private void btnWakeWan_Clicked()
        {
            carouselView.IsEnabled = false;
            var computer = new Models.Device()
            {
                Name = "Cesar PC",
                MacAddress = "04:D4:C4:56:31:64",
                HostName = "cv.tplinkdns.com",
                Port = 3000,
            };
            string retorno = computer.Wake();
            AnimateIcon();
            carouselView.IsEnabled = true;
        }

        private List<Button> LoadButtons()
        {
            return new List<Button> 
            { 
                new Button
                {
                    Text = "Wake WAN",
                    ImageSource = "icon_wan.png",
                    Command = new Command(btnWakeWan_Clicked),
                },
                new Button
                {
                    Text = "Wake LAN",
                    ImageSource = "icon_lan.png",
                    Command = new Command(btnWakeLan_Clicked),
                }
            };
        }

        private async void AnimateIcon()
        {
            await imagePC.TranslateTo(10, 0, 25); 
            await imagePC.TranslateTo(-10, 0, 50);
            await imagePC.TranslateTo(10, 0, 25);
            await imagePC.TranslateTo(-10, 0, 50);
            await imagePC.TranslateTo(10, 0, 25);
            await imagePC.TranslateTo(-10, 0, 50);
            await imagePC.TranslateTo(0, 0, 50);
        }
    }
}
