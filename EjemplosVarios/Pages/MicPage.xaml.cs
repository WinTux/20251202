using EjemplosVarios.Models;
using EjemplosVarios.Tools;
using Plugin.Maui.Audio;

namespace EjemplosVarios.Pages;

public partial class MicPage : ContentPage
{
	private readonly IAudioManager audioManager;
	private readonly IAudioRecorder audioRecorder;
	private readonly AudioDatabase database;
    public MicPage(IAudioManager audioManager, AudioDatabase database)
	{
		InitializeComponent();
		this.audioManager = audioManager;
		audioRecorder = audioManager.CreateRecorder();
		this.database = database;
    }
	private async void OnGrabarClic(object sender, EventArgs e)
	{
		if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted) return;
		if (audioRecorder.IsRecording) { 
			var audioGrabado = await audioRecorder.StopAsync();
			btnGrabar.Text = "Grabar";
			//var reproductor = AudioManager.Current.CreatePlayer(audioGrabado.GetAudioStream());
			//reproductor.Play();

			await Task.Run(async () => { 
				var rutaArch = await GuardarArchivoAsync(audioGrabado.GetAudioStream());
				var registro = new GrabacionAudio { 
					Nombre = $"Grabación {DateTime.Now:HH:mm:ss}",
					Ruta = rutaArch,
					FechaGrabacion = DateTime.Now
                };
                await database.GuardarGrabacionAsync(registro);
            });
			LlenarTabla();
		}
		else
		{
			await audioRecorder.StartAsync();
			btnGrabar.Text = "Detener";
        }
	}
	private async Task<string> GuardarArchivoAsync(Stream stream)
	{
		string nombreArchivo = $"grabacion_{DateTime.Now:yyyyMMdd_HHmmss}.wav";
		string rutaArchivo = Path.Combine(FileSystem.AppDataDirectory, nombreArchivo);
		using var fileStream = File.Create(rutaArchivo);
		await stream.CopyToAsync(fileStream);
		return rutaArchivo;
    }
	private async void LlenarTabla() { 
		listaGrab.ItemsSource = await database.GetGrabacionesAsync();
    }
	private async void OnPlayClicked(object sender, EventArgs e)
	{
		int id = (int)((Button)sender).CommandParameter;
		var grabacion = await database.GetGrabacionAsync(id);
		if (grabacion != null && File.Exists(grabacion.Ruta))
		{
			var reproductor = AudioManager.Current.CreatePlayer(grabacion.Ruta);
			reproductor.Play();
		}
		else { 
			await DisplayAlert("Error", "No se encontró la grabación.", "OK");
			return;
        }
    }
	private async void OnRenombrarCompletado(object sender, EventArgs e)
	{
		var entry = (Entry)sender;
		if (entry.BindingContext is GrabacionAudio grabacion) { 
			grabacion.Nombre = entry.Text;
			await database.ModificarGrabacionAsync(grabacion);
        }
    }
	private async void OnEliminarClicked(object sender, EventArgs e)
	{
        int id = (int)((Button)sender).CommandParameter;
        var grabacion = await database.GetGrabacionAsync(id);
		bool confirmacion = await DisplayAlert("Confirmar", $"¿Eliminar la grabación '{grabacion.Nombre}'?", "Sí", "No");
		if (!confirmacion) return;
		if(File.Exists(grabacion.Ruta))
			File.Delete(grabacion.Ruta);
		await database.BorrarGrabacionAsync(grabacion);
        LlenarTabla();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
		LlenarTabla();
    }
}