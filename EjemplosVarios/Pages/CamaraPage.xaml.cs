namespace EjemplosVarios.Pages;

public partial class CamaraPage : ContentPage
{
	public CamaraPage()
	{
		InitializeComponent();
	}
	async void OnTomarFotoClic(object sender, EventArgs e) { 
		var foto = await MediaPicker.CapturePhotoAsync();
		if (foto != null) { 
			var stream = await foto.OpenReadAsync();
			imagen.Source = ImageSource.FromStream(() => stream);
        }
    }
}