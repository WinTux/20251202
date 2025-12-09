namespace EjemplosVarios.Pages;

public partial class GridPage : ContentPage
{
	public GridPage()
	{
		InitializeComponent();
	}
    async void OnPosicionCambiada(object sender, ValueChangedEventArgs e)
    {
        Dispatcher.Dispatch(() => {
            video.SeekTo(TimeSpan.FromSeconds((int)e.NewValue));
        });
    }
}