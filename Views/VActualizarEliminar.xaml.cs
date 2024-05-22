using P_Inventario.Models;
using System.Net;
using static System.Net.WebRequestMethods;

namespace P_Inventario.Views;

public partial class VActualizarEliminar : ContentPage
{
	private const string url = "http://192.168.100.9/P_inventario/wsinventario.php";
	private readonly HttpClient cliente = new HttpClient();
	private Minventario minventario;

    public VActualizarEliminar(Minventario bodega)
	{
		InitializeComponent();
        txtCodigo.Text= bodega.id.ToString();
        txtnombre_producto.Text = bodega.nombre_producto;
        txtacantidad.Text = bodega.cantidad.ToString();
        txtprecio.Text = bodega.precio.ToString();
    }

   

    private async void btnActualizarPro_Clicked(object sender, EventArgs e)
    {
        try
        {
            var parametros = new Dictionary<string, string>
    {
        { "id", txtCodigo.Text },
        { "nombre_producto", txtnombre_producto.Text },
        { "cantidad", txtacantidad.Text },
        { "precio", txtprecio.Text }
    };
            var content = new FormUrlEncodedContent(parametros);
            var response = await cliente.PutAsync
                ($"{url}?id={txtCodigo.Text}&nombre_producto={txtnombre_producto.Text}&cantidad={txtacantidad.Text}&precio={txtprecio.Text}",
                content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Producto actualizado correctamente", "Regreo a vista inventario");
                
                await Navigation.PushAsync(new Views.Vinventario());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar el estudiante", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }

    }

    private async void btnEliminarPro_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmar", "¿Estás seguro de eliminar este producto?", "Sí", "No");
        if (answer)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("id", txtCodigo.Text);
                cliente.UploadValues($"{url}?id=" + txtCodigo.Text, "DELETE", parametros);
                await DisplayAlert("Éxito", "el producto fue eliminado correctamente", "Regreso a vista inventario");
                await Navigation.PushAsync(new Views.Vinventario());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }
    }
}