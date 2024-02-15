namespace PM2E17321.Views;

public partial class MapaLista : ContentPage
{
	public MapaLista()
	{
		InitializeComponent();
	}

    private async void ubicaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ubicaciones.ItemsSource = await App.Database.GetListSitios();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        var aitios = new Views.Mapa();
        await Navigation.PushAsync(aitios);
    }
}