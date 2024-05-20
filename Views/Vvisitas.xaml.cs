namespace P_Inventario.Views;

public partial class Vvisitas : ContentPage
{
	public Vvisitas()
	{
        DisplayAlert("Bienvenido"," S.G.R.C agredece tu visita: ", "continuar");
        InitializeComponent();
	}

    private void btnvisita_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VinveTrabajadores());
    }
}