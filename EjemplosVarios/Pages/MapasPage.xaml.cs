using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Diagnostics;

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

		// Añadir un pin
		mimapa.Pins.Add(new Pin { 
			Label = "EDUCOMSER S.R.L.",
			Address = "Av. 16 de Julio - Edif. 16 de Julio - Piso 1",
			Type = PinType.SearchResult,
			Location = new Location(-16.5017347743173, -68.13291452547053)
        });

		// Tipo de mapa
		mimapa.MapType = MapType.Street;//Satellite, Hybrid, Street
    }

	async void OnMapaClic(object o, MapClickedEventArgs e) { 
		Debug.WriteLine($"Mapa clic en: {e.Location.Latitude}, {e.Location.Longitude}");
		Polygon recuadro = new Polygon
		{
			StrokeColor = Colors.Red,
			StrokeWidth = 8,
			FillColor = Color.FromArgb("#88FF0000"),
			Geopath = {
				new Location(-16.50225088791845, -68.13117972652347),
				new Location(-16.502476379822436, -68.13103179109238),
				new Location(-16.502569122384052, -68.13117593330729),
				new Location(-16.502356359970783, -68.13134093821121)
            }
		};
		mimapa.MapElements.Add(recuadro);

		// Añadir una ruta simple 
		Polyline polyline = new Polyline { 
			StrokeColor = Colors.Blue,
			StrokeWidth = 15,
			Geopath = {
                new Location(-16.502189660752368, -68.13119992923833),
                new Location(-16.501927798770385, -68.13068784505172),
                new Location(-16.502989792376212, -68.12967505633117),
                new Location(-16.503833563969422, -68.13102164808286)
            }
        };
		mimapa.MapElements.Add(polyline);

		// Añadir un círculo
		Circle circulo = new Circle { 
			StrokeColor = Colors.Red,
			StrokeWidth = 6,
			FillColor = Color.FromArgb("#8800FF00"),
			Center = new Location(-16.509310212164916, -68.12424898072229),
			Radius = Distance.FromMeters(50)
        };
		mimapa.MapElements.Add(circulo);

		Circle circulo2 = new Circle {
            StrokeColor = Colors.Red,
            StrokeWidth = 3,
            FillColor = Color.FromArgb("#8800FF00"),
            Center = new Location(e.Location.Latitude, e.Location.Longitude),
            Radius = Distance.FromMeters(30)
        };
        mimapa.MapElements.Add(circulo2);
    }
}