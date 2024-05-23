using Newtonsoft.Json;
namespace P_Inventario.Views;
using System.Collections.ObjectModel;
using P_Inventario.Models;
public partial class VinveTrabajadores : ContentPage
{
    private const string url = "http://192.168.1.208/P_inventario/wsinventario.php";
    private readonly HttpClient invent = new HttpClient();
    private ObservableCollection<Minventario> est;
    public VinveTrabajadores()
	{
		InitializeComponent();
        DisplayAlert("Bienvenido", "Stock de Invantaro", "Continuar");
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
}