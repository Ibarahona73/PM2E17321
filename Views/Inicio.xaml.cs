namespace PM2E17321.Views;

public partial class Inicio : ContentPage

{

    FileResult photo;
    public Inicio()
	{
        InitializeComponent();
    }

    public String GetImage64()
    {
        if (photo != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray();

                String Base64 = Convert.ToBase64String(data);

                return Base64;
            }
        }
        return null;
    }

    public byte[] GetImageArray()
    {
        if (photo == null)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray();
                return data;
            }
        }
        return null;
    }

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        var lugar = new Models.Sitios
        {
            Latitud = Latitud.GetValue,
            Latitud = Latitud.GetValue,
            Desc = Descripcion.Text,
            foto = GetImage64()
        };

        if (await App.Database.StoreSitios(lugar) > 0)
        {
            await DisplayAlert("Aviso", "Registro ingresado con exito!!", "OK");
        }
    }

    private async void btnSitios_Clicked(object sender, EventArgs e)
    {
        var Sitios = new MapaLista();
        await Navigation.PushAsync(Sitios);

    }

    private async void btnSalir_Clicked(object sender, EventArgs e)
    {
        
    }

    private async void btnFoto_Clicked(object sender, EventArgs e)
    {
        photo = await MediaPicker.CapturePhotoAsync();

        if (photo != null)
        {
            string path = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using Stream sourcephoto = await photo.OpenReadAsync();
            using FileStream Streamlocal = File.OpenWrite(path);

            foto.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);

            await sourcephoto.CopyToAsync(Streamlocal);
        }
    }
}