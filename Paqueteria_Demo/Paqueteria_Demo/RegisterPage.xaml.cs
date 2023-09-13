using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Paqueteria_Demo.Models;
using System.Text;

namespace Paqueteria_Demo;

public partial class RegisterPage : ContentPage
{
    public string Code;
	public RegisterPage()
	{
		InitializeComponent();
	}

    public RegisterPage(string code)
    {
        InitializeComponent();
        this.Code = code;
        SetCode(code);
    }

    private async void LanzaScanner(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BarcodeScannerPage());
    }

    public void SetCode(string Codigo)
    {
        lblCode.Text = $"{Codigo}";
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        Paquete oPaquete = new Paquete
        {
            cajon = int.Parse(lblCajon.Text),
            tracking = lblCode.Text,
            nombre = lblNombre.Text,
            tipo = lblTipo.Text,
            precio = decimal.Parse(lblPrecio.Text)
        };

        Uri RequestUri = new Uri("http://paqueteria.somee.com/api/Paquete/Guardar");

        var client = new HttpClient();

        var json = JsonConvert.SerializeObject(oPaquete);

        var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(RequestUri, contentJson);

        if(response.StatusCode == HttpStatusCode.OK)
        {
            await DisplayAlert("Correcto", "Se guardo correctamente la informacion", "OK");

            lblCajon.Text = "";
            lblCode.Text = "";
            lblNombre.Text = "";
            lblTipo.Text = "";
            lblPrecio.Text = "";
        }
        else
        {
            await DisplayAlert("Error", "No se guardo correctamente la informacion", "OK");
        }
    }
}