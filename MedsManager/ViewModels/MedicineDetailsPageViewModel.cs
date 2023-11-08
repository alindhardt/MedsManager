using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using MedsManager.Controls;
using MedsManager.Models;
using MedsManager.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CommunityToolkit.Maui.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MedsManager.Validations;


namespace MedsManager.ViewModels;

[QueryProperty(nameof(Medicine), "Medicine")]
public partial class MedicineDetailsPageViewModel : ObservableObject
{
    public IList<MassUnit> AllMassUnits { get; } = Enum.GetValues(typeof(MassUnit)).Cast<MassUnit>().ToList();

    [ObservableProperty]
    MassUnit selectedMassUnit = MassUnit.Microgram;

    [ObservableProperty]
    ValidatableObject<string> name = new();

    [ObservableProperty]
    ValidatableObject<double> dosePerUnit = new();


    [ObservableProperty]
    ValidatableObject<int> quantity = new();

    [ObservableProperty]
    Medicine medicine;
    private readonly IMedicineRepository medicineRepository;


    public MedicineDetailsPageViewModel(IMedicineRepository medicineRepository)
    {
        this.medicineRepository = medicineRepository;
        Name.Validations.Add(new IsNotNullOrEmptyRule<string>
        {
            ValidationMessage = "Name is required."
        });
        DosePerUnit.Validations.Add(new IsZeroOrHigherRule<double>
        {
            ValidationMessage = "Dose can not be lower than zero."
        });
        Quantity.Validations.Add(new IsZeroOrHigherRule<int> 
        { 
            ValidationMessage = "Quantity can not be lower than zero"
        });
    }

    [RelayCommand]
    async Task CancelAsync()
        => await Shell.Current.GoToAsync("..");

    [RelayCommand]
    async Task Save()
    {
        Validate();
        if (DosePerUnit.IsValid && Name.IsValid && Quantity.IsValid)
        {
            Medicine.Name = Name.Value;
            Medicine.Quantity = Quantity.Value;
            Medicine.DosePerUnit = DosePerUnit.Value;
            Medicine.UnitOfMeasurement = SelectedMassUnit;

            await medicineRepository.UpdateAsync(Medicine);

            await Shell.Current.GoToAsync("..");
        }
    }

    [RelayCommand]
    void NavigatedTo()
    {
        Name.Value = Medicine.Name;
        DosePerUnit.Value = Medicine.DosePerUnit;
        Quantity.Value = Medicine.Quantity;
        SelectedMassUnit = Medicine.UnitOfMeasurement;
    }

    [RelayCommand]
    void Validate()
    {
        DosePerUnit.Validate();
        Name.Validate();
        Quantity.Validate();
    }
}
