namespace MauiWakeOnLan
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

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
                Port = 3000,
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
            computer.Wake();
        }
    }

}
