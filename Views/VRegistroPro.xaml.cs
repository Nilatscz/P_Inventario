using Plugin.Media;
using System.Net;

using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.Maui.Platform;
#endif


namespace P_Inventario.Views;

public partial class RegistroPro : ContentPage
{
    public RegistroPro()
    {
        InitializeComponent();
    }

    private void btnAgregarPro_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre_producto", txtnombre_producto.Text);
            parametros.Add("cantidad", txtacantidad.Text);
            parametros.Add("precio", txtprecio.Text);
            cliente.UploadValues("http://192.168.100.9/P_inventario/wsinventario.php", "POST", parametros);
            DisplayAlert("Positivo", "producto registrado. ", "continuar a vista inventario");

            Navigation.PushAsync(new Views.Vinventario());
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }

    private async void btnCamara_Clicked(object sender, EventArgs e)
    {
        await CrossMedia.Current.Initialize();
        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        {
            await DisplayAlert("No Cámara", "Cámara no conecta", " Continuar");
            return;
        }
        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        {
            Directory = "Sample",
            Name = "text.jpg",
            SaveToAlbum = true,
            CompressionQuality = 75,
            CustomPhotoSize = 50,
            PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
            MaxWidthHeight = 2000,
            DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
        });
        if (file == null)
        {
            await DisplayAlert("Error", "No se tomó ninguna foto.", "OK");
            return;
        }

        await DisplayAlert("Éxito", $"Su foto se guardó en: {file.Path}", "OK");

        // Mostrar la imagen en la UI (por ejemplo, en un Image control)
        Imagen.Source = Microsoft.Maui.Controls.ImageSource.FromStream(() =>
        {
            var stream = file.GetStream();
            return stream;
        });
    }


    private async void btnVgaleria_Clicked(object sender, EventArgs e)
    {
        if (!CrossMedia.Current.IsPickPhotoSupported)
        {
            await DisplayAlert("Foto no soportada", "so pudo abrir galeria ", "OK");
            return;
        }
        var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        {
            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
        });
        if (file == null)
        {
            return;

            Imagen.Source = Microsoft.Maui.Controls.ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}