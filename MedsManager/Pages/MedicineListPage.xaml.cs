using MedsManager.ViewModels;

namespace MedsManager.Pages;

public partial class MedicineListPage : ContentPage
{
    public MedicineListPage(MedicineListPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}