namespace EjemplosVarios
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Pages.RelojPage), typeof(Pages.RelojPage));
        }
    }
}
