using CommunityToolkit.Maui;
using MedsManager.Pages;
using MedsManager.Services;
using MedsManager.ViewModels;

namespace MedsManager.Helpers;

public static class ServiceCollectionHelper
{
    public static void AddMyServices(this IServiceCollection services)
    {
        //repos
        services.AddSingleton<IMedicineRepository, SQLiteMedicineRepository>();

        //pages
        services.AddTransient<CalendarPage>();
        services.AddTransient<MedicineDetailsPage>();
        services.AddTransient<MedicineListPage>();

        //view models
        services.AddTransient<CalendarPageViewModel>();
        services.AddTransient<MedicineDetailsPageViewModel>();
        services.AddTransient<MedicineListPageViewModel>();

        //db contexts
        services.AddDbContext<MedsDbContext>();

        using var dbContext = new MedsDbContext();
        dbContext.Database.EnsureCreated();
    }
}
