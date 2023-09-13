using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Paqueteria_Demo;

public partial class EntregarPage : ContentPage
{
	public EntregarPage()
	{
		InitializeComponent();
	}

    public class PaqueteAPI
    {
        public int cajon { get; set; }
        public string tracking { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public decimal precio { get; set; }
    }

    private async void btnBuscar_Clicked(object sender, EventArgs e)
    {
        string cajon = lblBuscar.Text;
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("http://paqueteria.somee.com/api/Paquete/Obtener/"+cajon);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");
        var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<PaqueteAPI>>(content);
            ListDemo.ItemsSource = resultado;
        }
    }
}