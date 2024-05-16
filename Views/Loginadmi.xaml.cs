//using Microsoft.UI.Xaml.Automation.Peers;
//using Java.Util;
using Newtonsoft.Json;
using P_Inventario.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;

namespace P_Inventario.Views;

public partial class Loginadmi : ContentPage
{
    private const string url = "http://192.168.1.188/P_inventario/wsloginadmi.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<ListUsuarios> est;
    
    
    public Loginadmi()
	{
		InitializeComponent();
        
        ListUsuarioss();
    }
    public async void ListUsuarioss()
    {
        try
        {
            using (HttpClient client = new HttpClient()) ;
            {
                string url = "http://192.168.1.188/P_inventario/wsloginadmi.php";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<ListUsuarios> mostrar = JsonConvert.DeserializeObject<List<ListUsuarios>>(content);
                    est = new ObservableCollection<ListUsuarios>(mostrar);
                 
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
         
    private void Ingrear_Clicked(object sender, EventArgs e)
    {
        if ((string.IsNullOrEmpty(TxtUsuario.Text)) || (string.IsNullOrEmpty(TxtContraseña.Text)))
        {
            DisplayAlert("Atencion", "Llene los campos solicitados: ", "continuar");
        }
        else
        {

            int c = 0;
            foreach (var login in est)
            {
                if ((login.nombre == TxtUsuario.Text) && (login.password == TxtContraseña.Text))
                {
                    Navigation.PushAsync(new Vinventario());
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