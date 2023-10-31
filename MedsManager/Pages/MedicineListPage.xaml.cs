using MedsManager.ViewModels;

namespace MedsManager.Pages;

public partial class MedicineListPage : ContentPage
{
	public MedicineListPage()
	{
		InitializeComponent();
		BindingContext = new MedicineListPageViewModel();
	}
}