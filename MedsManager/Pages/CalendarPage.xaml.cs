using MedsManager.ViewModels;

namespace MedsManager.Pages;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
		BindingContext = new CalendarPageViewModel();
	}
}