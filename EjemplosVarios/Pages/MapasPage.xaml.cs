using Microsoft.Maui.Maps;

namespace EjemplosVarios.Pages;

public partial class MapasPage : ContentPage
{
	public MapasPage()
	{
		InitializeComponent();
		//var estado = Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>().Result;
		//if (estado != PermissionStatus.Granted) { }

		// Ubicación inicial
		Location location = new Location(-16.506882576768685, -68.12752451923136);
		MapSpan mapSpan = new MapSpan(location, 0.01,0.01);
        mimapa.MoveToRegion(mapSpan);
    }
}