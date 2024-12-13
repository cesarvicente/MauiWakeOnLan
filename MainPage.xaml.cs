namespace MauiWakeOnLan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnWakeLan_Clicked(object sender, EventArgs e)
        {
            var computer = new Models.Device()
            {
                Name = "Cesar PC",
                MacAddress = "04:D4:C4:56:31:64",
                HostName = "192.168.3.100",
            };
            computer.Wake();
        }

        private void btnWakeWan_Clicked(object sender, EventArgs e)
        {
            var computer = new Models.Device()
            {
                Name = "Cesar PC",
                MacAddress = "04:D4:C4:56:31:64",
                HostName = "cv.tplinkdns.com",
                Port = 3000,
            };
            string retorno = computer.Wake();

            DisplayAlert(string.Empty, retorno, "OK");

        }
    }

}
