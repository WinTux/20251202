using CommunityToolkit.Maui.Core;

namespace EjemplosVarios.Pages;

public partial class TrazosPage : ContentPage
{
	public TrazosPage()
	{
		InitializeComponent();
	}
	async void OnLineaDibujada(object sender, DrawingLineCompletedEventArgs e)
	{
		//await DisplayAlert("Trazos", "Has dibujado una línea.", "OK");
		var stream = await lienzo.GetImageStream(200,200);
		Dispatcher.Dispatch(() => {
            imagenTrazos.Source = ImageSource.FromStream(() => stream);

        });
    }
}