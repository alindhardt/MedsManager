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
    {
        var list = await dbContext.Meds.AsNoTracking().ToListAsync();
        return list;
    }

    public async Task<Medicine> GetByIdAsync(Guid id)
    {
        var med = await dbContext.Meds.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        return med;
    }

    public async Task<bool> UpdateAsync(Medicine medicine)
    {
        dbContext.Entry(await dbContext.Meds.FirstOrDefaultAsync(m => m.Id == medicine.Id)).CurrentValues.SetValues(medicine);
        return (await dbContext.SaveChangesAsync()) > 0;
    }

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
