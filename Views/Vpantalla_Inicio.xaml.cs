
namespace P_Inventario.Views;

public partial class Vpantalla_Inicio : ContentPage
{
    private readonly IMediaPicker mediaPicker;

    public Vpantalla_Inicio(IMediaPicker mediaPicker)
    {
        InitializeComponent();
        this.mediaPicker = mediaPicker;
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
        Navigation.PushAsync(new Loginadmi(mediaPicker));
    }

   
    private async void btncamara_Clicked(object sender, EventArgs e)
    {
 
        if (mediaPicker.IsCaptureSupported)
        {
            FileResult photo = await mediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream source = await photo.OpenReadAsync();
                using FileStream localFile = File.OpenWrite(localFilePath);
                await source.CopyToAsync(localFile);
                
            }
        }
    }
}