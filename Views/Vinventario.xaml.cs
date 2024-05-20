namespace P_Inventario.Views;

using Newtonsoft.Json;
using P_Inventario.Models;
using System.Collections.ObjectModel;

public partial class Vinventario : ContentPage
{
    private const string url = "http://192.168.100.9/P_inventario/wsinventario.php";
    private readonly HttpClient invent = new HttpClient();
    private ObservableCollection<Minventario> est;
    
    
    public Vinventario()
	{
		InitializeComponent();
        DisplayAlert("Bienvenido", "Vista de invetario, para administradores", "Continuar");
        ListaInventario();
       
    }
    public async void ListaInventario()
    {
        var contebt = await invent.GetStringAsync(url);
        List<Minventario> verinven = JsonConvert.DeserializeObject<List<Minventario>>(contebt);
        est = new ObservableCollection<Minventario>(verinven);
        listainventario.ItemsSource = est;
       
    }

    
    private void listainventario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    var obMinventario = (Minventario)e.SelectedItem;
       Navigation.PushAsync(new VActualizarEliminar(obMinventario));
    }

    private  void btnRegistro_newProduct_Clicked(object sender, EventArgs e)
    {
       
        
        Navigation.PushAsync(new Views.RegistroPro());
      
       
    }
}