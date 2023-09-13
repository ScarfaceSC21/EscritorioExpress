using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Paqueteria_Demo;

public partial class BarcodeScannerPage : ContentPage
{
    private string Codigo;
    public BarcodeScannerPage()
	{
		InitializeComponent();
        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = true
        };

        cameraBarcodeReaderView.IsTorchOn = !cameraBarcodeReaderView.IsTorchOn;

    }

    private void barcodeView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => {
            lbl.Text = $"{e.Results[0].Format}->{e.Results[0].Value}";
            cameraBarcodeReaderView.IsDetecting = false;
            Codigo = e.Results[0].Value.ToString();
            RegisterPage page = new RegisterPage(Codigo);
            Navigation.PopAsync();
        });
    }

}