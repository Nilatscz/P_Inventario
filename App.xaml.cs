using Microsoft.Maui.Controls;
using Plugin;
namespace P_Inventario

 
{
    
    public partial class App : Application
    {
        private readonly IMediaPicker mediaPicker;

        public App(IMediaPicker mediaPicker)
        {
            InitializeComponent();

           
            this.mediaPicker = mediaPicker;
            MainPage = new NavigationPage(new Views.Vpantalla_Inicio(mediaPicker));
        }
    }
}
