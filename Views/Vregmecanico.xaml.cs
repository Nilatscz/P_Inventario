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
        if (((string.IsNullOrEmpty(txtnombre_usuario.Text)) || (string.IsNullOrEmpty(txtaEmail.Text))) || (string.IsNullOrEmpty(txtcontranewusuario.Text)))
        {
            DisplayAlert("Atencion", "Llene los campos solicitados: ", "continuar");
        }
        else
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtnombre_usuario.Text);
                parametros.Add("email", txtaEmail.Text);
                parametros.Add("password", txtcontranewusuario.Text);
                cliente.UploadValues("http://192.168.1.67/P_inventario/wsusuarios.php", "POST", parametros);
                DisplayAlert("Positivo", "Usuario Restro. ", "realice prueba de ingreso");

                Navigation.PushAsync(new Views.Vtrabajadores());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}