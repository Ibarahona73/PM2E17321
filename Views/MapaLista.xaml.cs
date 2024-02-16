using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using PM2E17321.Models;
using static Android.Icu.Text.Transliterator;
using static PM2E17321.Views.Mapa;

namespace PM2E17321.Views;


public partial class MapaLista : ContentPage
{    

    public MapaLista()
	{
		InitializeComponent();
            
        
    }

    private async void ubicaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Sitios selectedLocation)
        {
            bool goToLocation = await DisplayAlert("Confirmación", $"¿Desea ir a la localización {selectedLocation.Desc}?", "Sí", "No");

            if (goToLocation)
            {
                await Navigation.PushAsync(new Mapa(selectedLocation.Latitud, selectedLocation.Longitud, selectedLocation.Desc));
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ubicaciones.ItemsSource = await App.Database.GetListSitios();
    }

    
}