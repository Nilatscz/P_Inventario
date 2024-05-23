//using GameKit;
using Newtonsoft.Json;
using P_Inventario.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;

namespace P_Inventario.Views;

public partial class Vtrabajadores : ContentPage
{
    private const string url = "http://192.168.1.208/P_inventario/wsusuarios.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Mtrabajadores> est;
    public Vtrabajadores()
	{
		InitializeComponent();
        ListTrabajadores();

    }
    public async void ListTrabajadores()
    {
        try
        {
            using (HttpClient client = new HttpClient());
            {
                string url = "http://192.168.1.208/P_inventario/wsusuarios.php";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Mtrabajadores> mostrar = JsonConvert.DeserializeObject<List<Mtrabajadores>>(content);
                    est = new ObservableCollection<Mtrabajadores>(mostrar);

                }
                else
                {
                    await DisplayAlert("Error", "No se puede optener Usuarios", "ok");
                }
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", $"No se puede optener Usuarios: (ex.Message)", "ok");
        }

    }

    private void BtnLoginTrabajadores_Clicked(object sender, EventArgs e)
    {
        if ((string.IsNullOrEmpty(TxtUsuariotra.Text)) || (string.IsNullOrEmpty(TxtContraseñatra.Text)))
        {
            DisplayAlert("Atencion", "Llene los campos solicitados: ", "continuar");
        } else
        {
              
        int c = 0;
        foreach (var login in est)
        {          
                if ((login.nombre == TxtUsuariotra.Text) && (login.password == TxtContraseñatra.Text))
                { 
                    
                    Navigation.PushAsync(new VinveTrabajadores());
                    c = 1;
                    break;

                }
                else
                {
                    c = 0;
                }               
            
        }
            if (c == 0)
            {
                DisplayAlert("Atencion", "usuario o contraseña incorrectas: ", "continuar");

            }
           
        } 
    }
}