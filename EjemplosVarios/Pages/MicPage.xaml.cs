using Plugin.Maui.Audio;

namespace EjemplosVarios.Pages;

public partial class MicPage : ContentPage
{
	private readonly IAudioManager audioManager;
	private readonly IAudioRecorder audioRecorder;
    public MicPage(IAudioManager audioManager)
	{
		InitializeComponent();
		this.audioManager = audioManager;
		audioRecorder = audioManager.CreateRecorder();
    }
	private async void OnGrabarClic(object sender, EventArgs e)
	{
		if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted) return;
		if (audioRecorder.IsRecording) { 
			var audioGrabado = await audioRecorder.StopAsync();
			btnGrabar.Text = "Grabar";
			var reproductor = AudioManager.Current.CreatePlayer(audioGrabado.GetAudioStream());
			reproductor.Play();
		}
		else
		{
			await audioRecorder.StartAsync();
			btnGrabar.Text = "Detener";
        }
	}
}