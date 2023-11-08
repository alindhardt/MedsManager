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
            UnitOfMeasurement = MassUnit.Milligram,
            Quantity = 1
        },
        new Medicine
        {
            Id = Guid.NewGuid(),
            Name = "Red pill",
            Description = "You stay in Wonderland, and I show you how deep the rabbit hole goes.",
            DosePerUnit = 500,
            UnitOfMeasurement = MassUnit.Milligram,
            Quantity = 2
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

        return _meds.SingleOrDefault(m => m.Id == id);
    }

    public Task<bool> UpdateAsync(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    private async Task SimulateDelayAsync()
    {
        await Task.Delay(_random.Next(50, 400));
    }
}
