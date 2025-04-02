using System.Security.Principal;
using OvO.ViewModels;

namespace OvO
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }
}
