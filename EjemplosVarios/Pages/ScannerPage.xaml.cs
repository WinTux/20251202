using ZXing.Net.Maui;

namespace EjemplosVarios.Pages;

public partial class ScannerPage : ContentPage
{
	public ScannerPage()
	{
		InitializeComponent();
        lectorCodigo.Options = new BarcodeReaderOptions()
        {
            AutoRotate = true,
            Formats = BarcodeFormats.All,
            TryHarder = true,
            Multiple = false
        };

    }
	async void OnCodigoBarrasDetectado(object sender, BarcodeDetectionEventArgs e)
	{
        //await DisplayAlert("Código de barras detectado", $"Tipo: {e}\nValor: {e.Value}", "OK");
        
		Dispatcher.Dispatch(() => {
            resultadoCodigo.Text = $"Tipo: {e.Results[0].Format}\nValor: {e.Results[0].Value}";
        });
    }
}