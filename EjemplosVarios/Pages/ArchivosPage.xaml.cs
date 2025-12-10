using System.Runtime.CompilerServices;

namespace EjemplosVarios.Pages;

public partial class ArchivosPage : ContentPage
{
	public ArchivosPage()
	{
		InitializeComponent();
	}
	async void OnElegirArchivoClic(object sender, EventArgs e)
	{
		var resultado = await FilePicker.PickAsync(new PickOptions
		{
			PickerTitle = "Elige un archivo de imagen",
			FileTypes = FilePickerFileType.Images
		});
		if (resultado == null)
			return;
		else { 
			var stream = await resultado.OpenReadAsync();
			imagen.Source = ImageSource.FromStream(() => stream);
        }
    }
    async void OnElegirArchivo2Clic(object sender, EventArgs e)
    {
        var resultados = await FilePicker.PickMultipleAsync(new PickOptions
        {
            PickerTitle = "Elige un archivo de imagen",
            FileTypes = FilePickerFileType.Images
        });
        if (resultados == null)
            return;
        else
        {
            foreach (var item in resultados) { 
                await DisplayAlert("Archivo elegido", $"Nombre: {item.FileName}, Path: {item.FullPath}", "Aceptar");
            }
        }
    }
}