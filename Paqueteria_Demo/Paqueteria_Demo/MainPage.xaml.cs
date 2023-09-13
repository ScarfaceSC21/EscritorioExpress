namespace Paqueteria_Demo;

public partial class MainPage : ContentPage
{
    string cod = String.Empty;
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ib_entrega_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EntregarPage());
    }

    private async void ib_escaner_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}

