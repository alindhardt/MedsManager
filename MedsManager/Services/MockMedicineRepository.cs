using MedsManager.Models;

namespace MedsManager.Services;

public class MockMedicineRepository : IMedicineRepository
{
    private Random _random = new Random();

    private List<Medicine> _meds = new List<Medicine>
    {
        new Medicine
        {
            Id= Guid.NewGuid(),
            Name = "Blue pill",
            Description = "You wake up in your bed and believe whatever you want to believe.",
            DosePerUnit = 500,
            UnitOfMeasurement = MassUnit.Milligram
        },
        new Medicine
        {
            Id = Guid.NewGuid(),
            Name = "Red pill",
            Description = "You stay in Wonderland, and I show you how deep the rabbit hole goes.",
            DosePerUnit = 500,
            UnitOfMeasurement = MassUnit.Milligram
        }
    };

    public async Task<IEnumerable<Medicine>> GetAllMedsAsync()
    {
        await SimulateDelayAsync();

        return _meds;
    }

    public async Task<Medicine> GetByIdAsync(Guid id)
    {
        await SimulateDelayAsync();

        var index = _random.Next(_meds.Count);

        return _meds[index];
    }

    private async Task SimulateDelayAsync()
    {
        await Task.Delay(_random.Next(50, 400));
    }
}
