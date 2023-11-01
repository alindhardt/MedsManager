using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace MedsManager.ViewModels;

public partial class CalendarPageViewModel : ObservableObject
{
    [ObservableProperty]
    DateTime today = DateTime.Today;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HeaderText))]
    DateTime monthCurrentlyViewed;

    public Command ToNextMonthCommand { get; }
    public Command ToPreviousMonthCommand { get; }

    public CalendarPageViewModel()
    {
        MonthCurrentlyViewed = new DateTime(Today.Year, Today.Month, 1);

        ToNextMonthCommand = new Command(ToNextMonth);

        ToPreviousMonthCommand = new Command(ToPreviousMonth);
    }

    private void ToNextMonth()
    {
        MonthCurrentlyViewed = MonthCurrentlyViewed.AddMonths(1);
        Debug.WriteLine("Month increased");
    }
    private void ToPreviousMonth()
    {
        MonthCurrentlyViewed = MonthCurrentlyViewed.AddMonths(-1);
        Debug.WriteLine("Month decreased");
    }


    public string HeaderText => MonthCurrentlyViewed.ToString("MMMM yyyy");


}
