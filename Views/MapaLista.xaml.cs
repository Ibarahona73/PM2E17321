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

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        //validacion que si no hay sitios guardados pues que tire que no hay datos que borrar
        var sitios = await App.Database.GetListSitios();

        if (sitios.Count == 0)
        {
            await DisplayAlert("Alerta", "No hay sitios para borrar.", "Aceptar");
            return;
        }

        //Creame una variable options que almacena todos los datos que tiene que esta previamente
        //guardados en un array

        var options = sitios.Select(s => s.Desc).ToArray();
        var selectedSitio = await DisplayActionSheet("Selecciona un sitio para borrar", "Cancelar", null, options);

        if (selectedSitio == "Cancelar")
            return;

        //confirmacion de si desea borrar o no el sitio seleccionado eesto por si selecciono el que no debia
        var confirmarBorrar = await DisplayAlert("Confirmación", $"¿Estás seguro de borrar el sitio {selectedSitio}?", "Sí", "No");

        //procede a borrar el sitio y dar el mensaje de borrado correctamente
        if (confirmarBorrar)
        {
            var sitioABorrar = sitios.FirstOrDefault(s => s.Desc == selectedSitio);
            if (sitioABorrar != null)
            {
                await App.Database.DeleteSitios(sitioABorrar);
                await DisplayAlert("Éxito", "Sitio borrado correctamente.", "Aceptar");
                ubicaciones.ItemsSource = await App.Database.GetListSitios();
            }
        }
    }



    private void btnActua_Clicked(object sender, EventArgs e)
    {

    }
}

