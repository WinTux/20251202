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
            Routing.RegisterRoute(nameof(Pages.GridPage), typeof(Pages.GridPage));
            Routing.RegisterRoute(nameof(Pages.Grid2Page), typeof(Pages.Grid2Page));
            Routing.RegisterRoute(nameof(Pages.ArchivosPage), typeof(Pages.ArchivosPage));
            Routing.RegisterRoute(nameof(Pages.CamaraPage), typeof(Pages.CamaraPage));
            Routing.RegisterRoute(nameof(Pages.Camara2Page), typeof(Pages.Camara2Page));
            Routing.RegisterRoute(nameof(Pages.MicPage), typeof(Pages.MicPage));
        }
    }
}
