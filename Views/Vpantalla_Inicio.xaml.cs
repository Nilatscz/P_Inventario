namespace P_Inventario.Views;

public partial class Vpantalla_Inicio : ContentPage
{
	public Vpantalla_Inicio()
	{
		InitializeComponent();
	}

    private void BtnTrabajadores_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vtrabajadores());
    }

    private void BtnInvitado_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vvisitas());
    }

    private void BtnAdmin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Loginadmi());
    }
}