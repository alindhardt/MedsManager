using CommunityToolkit.Mvvm.ComponentModel;
using MedsManager.Helpers;
using System.Diagnostics;
using System.Globalization;

namespace MedsManager.ViewModels;

public partial class CalendarPageViewModel : ObservableObject
{
    private readonly DateTime _today = DateTime.Today;
    
    public CalendarPageViewModel()
    {
        MonthCurrentlyViewed = new DateTime(_today.Year, _today.Month, 1);

        ToNextMonthCommand = new Command(ToNextMonth);

        ToPreviousMonthCommand = new Command(ToPreviousMonth);
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HeaderText))]
    DateTime monthCurrentlyViewed;

    public Command ToNextMonthCommand { get; }
    public Command ToPreviousMonthCommand { get; }
    public string HeaderText => MonthCurrentlyViewed.ToString("MMMM yyyy");

    private void ToNextMonth()
        => MonthCurrentlyViewed = MonthCurrentlyViewed.AddMonths(1);
    
    private void ToPreviousMonth()
        => MonthCurrentlyViewed = MonthCurrentlyViewed.AddMonths(-1);
}
