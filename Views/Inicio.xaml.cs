namespace PM2E17321.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnSitios_Clicked(object sender, EventArgs e)
    {
        var Sitios = new Mapa();
        await Navigation.PushAsync(Sitios);

    }

    private void btnSalir_Clicked(object sender, EventArgs e)
    {
        
    }
}