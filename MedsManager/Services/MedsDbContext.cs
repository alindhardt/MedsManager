using MedsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace MedsManager.Services;

public class MedsDbContext : DbContext
{
    public DbSet<Medicine> Meds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionsString = $"Filename={GetPath("meds.db")}";
        optionsBuilder.UseSqlite(connectionsString);
    }

    string GetPath(string dbName)
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(path, "..", "Library", dbName);
        }
        else
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
        }
    }
}
