using Newtonsoft.Json;
namespace P_Inventario.Views;
using System.Collections.ObjectModel;
using P_Inventario.Models;
public partial class VinveTrabajadores : ContentPage
{
    private const string url = "http://192.168.1.67/P_inventario/wsinventario.php";
    private readonly HttpClient invent = new HttpClient();
    private ObservableCollection<Minventario> est;
    public VinveTrabajadores(string usu)
	{
		InitializeComponent();
        DisplayAlert("Bienvenido", "Stock de Invantaro", "Continuar");
        ListaInventario();
        lbltraconectado.Text = "Usuario conectado: "+usu;

    }
    public async void ListaInventario()
    {
        var contebt = await invent.GetStringAsync(url);
        List<Minventario> verinven = JsonConvert.DeserializeObject<List<Minventario>>(contebt);
        est = new ObservableCollection<Minventario>(verinven);
        listainventario.ItemsSource = est;

    }
   
}