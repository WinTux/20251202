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
    }
}
