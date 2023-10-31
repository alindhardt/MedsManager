using MedsManager.Models;
using System.ComponentModel;

namespace MedsManager.ViewModels;

public class MedicineListPageViewModel : INotifyPropertyChanged
{
    public MedicineListPageViewModel()
    {
        Meds.AddRange(new[]
        {
            new Medicine
            {
                Id= Guid.NewGuid(),
                Name = "Blue pill",
                Description = "You wake up in your bed and believe whatever you want to believe."
            },
            new Medicine
            {
                Id = Guid.NewGuid(),
                Name = "Red pill",
                Description = "You stay in Wonderland, and I show you how deep the rabbit hole goes."
            }
        });

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Meds)));
    }

    public List<Medicine> Meds { get; set; } = new();
    public event PropertyChangedEventHandler PropertyChanged;
}
