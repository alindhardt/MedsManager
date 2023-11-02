using CommunityToolkit.Maui.Markup;
using MedsManager.Controls;
using MedsManager.Helpers;
using MedsManager.ViewModels;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MedsManager.Pages;

public class CalendarPage : ContentPage
{
	public CalendarPage(CalendarPageViewModel vm)
	{
		BindingContext = vm;
		Title = "Calendar";

		var grid = new Grid
		{
			RowDefinitions = Rows.Define(Auto, Star),
			ColumnDefinitions = Columns.Define(Star),
			Children =
			{
				new FlexLayoutTextCarousel().Row(0)
                .Bind(FlexLayoutTextCarousel.NextCommandProperty, nameof(CalendarPageViewModel.ToNextMonthCommand))
				.Bind(FlexLayoutTextCarousel.PreviousCommandProperty, nameof(CalendarPageViewModel.ToPreviousMonthCommand))
				.Bind(FlexLayoutTextCarousel.TextProperty, nameof(CalendarPageViewModel.HeaderText)),
				new WeekDayGrid().Row(1)
                .Bind(WeekDayGrid.MonthProperty, nameof(CalendarPageViewModel.MonthCurrentlyViewed))
            }
		}
		.BindSwipeGesture(nameof(CalendarPageViewModel.ToNextMonthCommand), direction: SwipeDirection.Left)
		.BindSwipeGesture(nameof(CalendarPageViewModel.ToPreviousMonthCommand), direction: SwipeDirection.Right);

        Content = grid;
	}
}