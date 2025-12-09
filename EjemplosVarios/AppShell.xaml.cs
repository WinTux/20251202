namespace EjemplosVarios
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Pages.RelojPage), typeof(Pages.RelojPage));
            Routing.RegisterRoute(nameof(Pages.ScannerPage), typeof(Pages.ScannerPage));
            Routing.RegisterRoute(nameof(Pages.TrazosPage), typeof(Pages.TrazosPage));
            Routing.RegisterRoute(nameof(Pages.MapasPage), typeof(Pages.MapasPage));
            Routing.RegisterRoute(nameof(Pages.VideosPage), typeof(Pages.VideosPage));
        }
    }
}
