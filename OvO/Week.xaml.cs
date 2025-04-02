using OvO;
using OvO.ViewModels;

namespace OvO;

public partial class Week : ContentPage
{
	public Week()
	{
		InitializeComponent();
        BindingContext = new WeekViewModels();
    }

}