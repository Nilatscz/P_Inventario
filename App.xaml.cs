using Microsoft.Maui.Controls;
using Plugin;
namespace P_Inventario

 
{
    
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.Vinventario());
        }
    }
}
