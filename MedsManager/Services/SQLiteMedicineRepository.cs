using MedsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace MedsManager.Services;

public class SQLiteMedicineRepository : IMedicineRepository
{
    private readonly Medicine[] medsSeed = new[] 
    {
        new Medicine
        {
            Name = "Blue pill",
            Description = "You wake up in your bed and believe whatever you want to believe.",
            DosePerUnit = 500,
            UnitOfMeasurement = MassUnit.Milligram,
            Quantity = 1
        },
        new Medicine
        {
            Name = "Red pill",
            Description = "You stay in Wonderland, and I show you how deep the rabbit hole goes.",
            DosePerUnit = 500,
            UnitOfMeasurement = MassUnit.Milligram,
            Quantity = 2
        }
    };
    private readonly MedsDbContext dbContext;

    public SQLiteMedicineRepository(MedsDbContext dbContext)
    {
        this.dbContext = dbContext;

        SeedDummyData();
    }

    public async Task<IEnumerable<Medicine>> GetAllMedsAsync()
        => await dbContext.Meds.ToListAsync();

    public async Task<Medicine> GetByIdAsync(Guid id)
        => await dbContext.Meds.SingleOrDefaultAsync(x => x.Id == id);

    private void SeedDummyData()
    {
        foreach (var med in medsSeed)
        {
            var entry = dbContext.Meds.SingleOrDefault(m => m.Name == med.Name);

            if (entry is null)
            {
                dbContext.Meds.Add(med);
            }
        }

        if (dbContext.ChangeTracker.HasChanges())
            dbContext.SaveChanges();
    }
}
