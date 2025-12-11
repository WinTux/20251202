using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace EjemplosVarios.Pages;

public partial class Camara2Page : ContentPage
{
    private ICameraProvider cameraProvider;
    public Camara2Page(ICameraProvider cameraProvider)
	{
		InitializeComponent();
        this.cameraProvider = cameraProvider;
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
	async void OnZoomOutClicked(object sender, EventArgs e)
	{
		camara.ZoomFactor += -0.1f;
    }
    async void OnZoomInClicked(object sender, EventArgs e)
    {
        camara.ZoomFactor += 0.1f;
    }
    async void OnFlashClic(object sender, EventArgs e)
    {
        //camara.CameraFlashMode = camara.CameraFlashMode == CameraFlashMode.On ? CameraFlashMode.Off : CameraFlashMode.On;
        if(camara.CameraFlashMode == CameraFlashMode.On)
        {
            info.Text = "Flash desactivado";
            camara.CameraFlashMode = CameraFlashMode.Off;
        }
        else if (camara.CameraFlashMode == CameraFlashMode.Off)
        {
            info.Text = "Flash Automático";
            camara.CameraFlashMode = CameraFlashMode.Auto;
        }
        else if (camara.CameraFlashMode == CameraFlashMode.Auto)
        {
            info.Text = "Flash activado";
            camara.CameraFlashMode = CameraFlashMode.On;
        }
    }
    async void OnDesactivarClic(object sender, EventArgs e)
    {
        camara.StopCameraPreview();
    }
    async void OnActivarClic(object sender, EventArgs e)
    {
        camara.StartCameraPreview(CancellationToken.None);
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await cameraProvider.RefreshAvailableCameras(CancellationToken.None);
        Debug.WriteLine("Cámaras disponibles:");
        Debug.WriteLine(cameraProvider.AvailableCameras.Count);
        foreach (var cam in cameraProvider.AvailableCameras) { 
            Debug.WriteLine($"- Nombre: {cam.Name} Posición: ({cam.Position}); Soporte flash: {cam.IsFlashSupported}; max zoom: {cam.MaximumZoomFactor}, min zoom: {cam.MinimumZoomFactor}");
            foreach(var res in cam.SupportedResolutions)
            {
                Debug.WriteLine($"   - Resolución: {res.ToString()}");
            }
        }

        //camara.SelectedCamera = cameraProvider.AvailableCameras.FirstOrDefault();
        //camara.SelectedCamera = cameraProvider.AvailableCameras.Where(c => c.IsFlashSupported).FirstOrDefault();// select * from producto p where p.precio >= 100;
        camara.SelectedCamera = cameraProvider.AvailableCameras.Where(c => c.Position == CameraPosition.Front)
            .FirstOrDefault();
    }
}