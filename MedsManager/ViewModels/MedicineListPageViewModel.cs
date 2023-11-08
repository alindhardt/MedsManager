using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    Medicine selectedMedicine;

    [ObservableProperty]
    ObservableCollection<Medicine> meds = new();

    [ObservableProperty]
    bool isRetrievingMeds;

    public Command LoadMedsCommand { get; }

    async Task LoadMedsAsync()
    {
        IsRetrievingMeds = true;
        Meds = new ObservableCollection<Medicine>(await medicineRepository.GetAllMedsAsync());
        IsRetrievingMeds = false;
    }

    [RelayCommand]
    async Task MedicineTappedAsync(Medicine med)
    {
        var parameters = new Dictionary<string, object>
        {
            { "Medicine", med }
        };

        await Shell.Current.GoToAsync("medicine/details", parameters);
    }
}
