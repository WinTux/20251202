namespace EjemplosVarios.Pages;

public partial class VideosPage : ContentPage
{
	public VideosPage()
	{
		InitializeComponent();
        video4.Volume = 0.2;
    }
	public void OnBotonClicked(object sender, EventArgs e)
	{
		if (video4.CurrentState == CommunityToolkit.Maui.Core.MediaElementState.Playing)
			video4.Pause();
        else
			video4.Play();
        // video4.Position = TimeSpan.FromSeconds(10);
    }
	public void OnVolumenDownclicked(object sender, EventArgs e)
	{
		if (video4.Volume > 0)
			video4.Volume -= 0.1;
    }
	public void OnVolumenUpclicked(object sender, EventArgs e) { 
		if (video4.Volume < 1)
			video4.Volume += 0.1;
    }
}