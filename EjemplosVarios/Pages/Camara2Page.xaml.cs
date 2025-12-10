using CommunityToolkit.Maui.Core;

namespace EjemplosVarios.Pages;

public partial class Camara2Page : ContentPage
{
	public Camara2Page()
	{
		InitializeComponent();
	}
	async void OnTomarFotoClic(object sender, EventArgs e) { 
		await camara.CaptureImage(CancellationToken.None);

    }
    async void OnCapturaTomada(object sender, MediaCapturedEventArgs e)
    {
		Dispatcher.Dispatch(() => { 
			imagen.Source = ImageSource.FromStream(() => e.Media);
			return;
        });
    }
}