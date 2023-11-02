using MedsManager.Pages;
using MedsManager.Services;
using MedsManager.ViewModels;

namespace MedsManager.Helpers;

public static class ServiceCollectionHelper
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<MedicineListPage>();
        services.AddSingleton<CalendarPage>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IMedicineRepository, SQLiteMedicineRepository>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MedicineListPageViewModel>();
        services.AddSingleton<CalendarPageViewModel>();
    }
}
