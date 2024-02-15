namespace PM2E17321.Views;

public partial class MapaLista : ContentPage
{
	public MapaLista()
	{
		InitializeComponent();
	}

    private void ubicaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    /* protected override async void OnAppearing()
    {
        base.OnAppearing();
        ubicaciones.ItemsSource = await App.Database.GetListPersons();
    } */
}