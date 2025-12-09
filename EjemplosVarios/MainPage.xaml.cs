namespace EjemplosVarios
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnBotonRelojClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.RelojPage));
        }
        async void OnBotonScannerClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.ScannerPage));
        }

        async void OnBotonTrazosClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.TrazosPage));
        }
        async void OnBotonMapasClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.MapasPage));
        }
        async void OnBotonVideosClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.VideosPage));
        }
        async void OnBotonGridClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.GridPage));
        }
        async void OnBotonGrid2Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.Grid2Page));
        }
    }
}
