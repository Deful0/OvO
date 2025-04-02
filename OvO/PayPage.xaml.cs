using OvO;
using OvO.ViewModels;

namespace OvO;

public partial class PayPage : ContentPage
{
	public PayPage()
	{
		InitializeComponent();
        BindingContext = new PayViewModel();
    }
}