using Plugin.Media;
using System.Net;

using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;

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
            cliente.UploadValues("http://192.168.1.208/P_inventario/wsinventario.php", "POST", parametros);
            DisplayAlert("Positivo", "producto registrado. ", "continuar a vista inventario");

            Navigation.PushAsync(new Views.Vinventario());
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }

   

    private void btnVergaleria_Clicked(object sender, EventArgs e)
    {

    }
}