using CommunityToolkit.Mvvm.ComponentModel;
using MedsManager.Models;
using MedsManager.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MedsManager.ViewModels;

public partial class MedicineListPageViewModel : ObservableObject
{
    private readonly IMedicineRepository medicineRepository;

    public MedicineListPageViewModel(IMedicineRepository medicineRepository)
    {
        this.medicineRepository = medicineRepository;
        LoadMedsCommand = new Command(async () => await LoadMedsAsync());
    }

    [ObservableProperty]
    ObservableCollection<Medicine> meds = new();

    [ObservableProperty]
    bool isRetrievingMeds;

    public Command LoadMedsCommand { get; }
    public async Task LoadMedsAsync()
    {
        IsRetrievingMeds = true;
        Meds = new ObservableCollection<Medicine>(await medicineRepository.GetAllMedsAsync());
        IsRetrievingMeds = false;
    }
}
