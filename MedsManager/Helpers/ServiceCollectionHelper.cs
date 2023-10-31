﻿using MedsManager.Pages;
using MedsManager.Services;
using MedsManager.ViewModels;

namespace MedsManager.Helpers;

public static class ServiceCollectionHelper
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<MedicineListPage>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IMedicineRepository, MockMedicineRepository>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MedicineListPageViewModel>();
    }
}