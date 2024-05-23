
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

    private async void btngaleria_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            var result = await mediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please select a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                // Aquí puedes hacer lo que necesites con el stream de la imagen
                // Por ejemplo, mostrarla en un Image control
                var image = new Image
                {
                    Source = ImageSource.FromStream(() => stream)
                };
                // Asumiendo que tienes un StackLayout en tu XAML llamado `Layout`
                Layout.Children.Add(image);
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Feature not supported on device
        }
        catch (PermissionException pEx)
        {
            // Permissions not granted
        }
        catch (Exception ex)
        {
            // Something went wrong
        }
    
}
}