using CommunityToolkit.Mvvm.ComponentModel;
using MedsManager.Models;
using MedsManager.Services;
using MedsManager.ViewModels;

namespace MedsManager.Pages;

public partial class MedicineDetailsPage : ContentPage
{
    
    public MedicineDetailsPage(MedicineDetailsPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}