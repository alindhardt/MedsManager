using MedsManager.ViewModels;

namespace MedsManager.Pages;

public partial class MedicineListPage : ContentPage
{
    private readonly MedicineListPageViewModel viewModel;

    public MedicineListPage(MedicineListPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        viewModel.LoadMedsCommand.Execute(this);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //viewModel.LoadMedsCommand.Execute(this);
    }
}