using System.Net;

namespace P_Inventario.Views;

public partial class Vregmecanico : ContentPage
{
	public Vregmecanico()
	{
		InitializeComponent();
	}

    private void btnAgregarUsuanew_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtnombre_usuario.Text);
            parametros.Add("email", txtaEmail.Text);
            parametros.Add("password", txtcontranewusuario.Text);
            cliente.UploadValues("http://192.168.100.9/P_inventario/wsusuarios.php", "POST", parametros);
            DisplayAlert("Positivo", "Usuario Restro. ", "realice prueba de ingreso");

            Navigation.PushAsync(new Views.Vtrabajadores());
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
}