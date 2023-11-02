using CommunityToolkit.Maui.Markup;
using MedsManager.Helpers;
using System.Runtime.CompilerServices;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MedsManager.Controls;

public class WeekDayGrid : Grid
{
    const string letterS = "S";
    const string letterM = "M";
    const string letterT = "T";
    const string letterW = "W";
    const string letterF = "F";

    private readonly Color LightModeColorEnabled = new Color(220, 220, 220);
    private readonly Color LightModeColorDisabled = new Color(250, 250, 250);

    private readonly Color DarkModeColorEnabled = new Color(50, 50, 50);
    private readonly Color DarkModeColorDisabled = new Color(80, 80, 80);
    public WeekDayGrid()
	{
        Padding = new Thickness(2);
        ColumnDefinitions = Columns.Define(Star, Star, Star, Star, Star, Star, Star);
        RowDefinitions = Rows.Define(Auto,Star, Star, Star, Star, Star);
    }

    private void RenderColumns()
    {
        Children.Clear();
        RenderWeekLetters();
        RenderDays();
    }

    private void RenderWeekLetters()
    {
        Children.Add(new Label()
            .Text(letterS)
            .TextCenterHorizontal()
            .Column(0));
        Children.Add(new Label()
            .Text(letterM)
            .TextCenterHorizontal()
            .Column(1));
        Children.Add(new Label()
            .Text(letterT)
            .TextCenterHorizontal()
            .Column(2));
        Children.Add(new Label()
            .Text(letterW)
            .TextCenterHorizontal()
            .Column(3));
        Children.Add(new Label()
            .Text(letterT)
            .TextCenterHorizontal()
            .Column(4));
        Children.Add(new Label()
            .Text(letterF)
            .TextCenterHorizontal()
            .Column(5));
        Children.Add(new Label()
            .Text(letterS)
            .TextCenterHorizontal()
            .Column(6));
    }

    private void RenderDays()
    {
        var date = Month.GetSunday();
        for (int x = 0; x < 5; x++)
        {
            for (int i = 0; i < 7; i++)
            {
                var vertLay = new VerticalStackLayout()
                {
                    new Label()
                    .Text($"{date.Day}")
                    .FontSize(10)
                    .Bold()
                }.Column(i).Row(x +1)
                .AppThemeColorBinding(VerticalStackLayout.BackgroundColorProperty,
                date.Month == Month.Month ? LightModeColorEnabled : LightModeColorDisabled,
                date.Month == Month.Month ? DarkModeColorEnabled : DarkModeColorDisabled)
                .Margins(2, 2, 2, 0)
                .Paddings(5, 5, 5, 5);

                Children.Add(vertLay);

                date = date.AddDays(1);
            }
        }
    }

    #region MonthProperty binding
    public static readonly BindableProperty MonthProperty = BindableProperty.Create(
    nameof(Month),
    typeof(DateTime),
    typeof(FlexLayoutTextCarousel));

    public DateTime Month
    {
        get => (DateTime)GetValue(MonthProperty);
        set
        {
            SetValue(MonthProperty, value);
        }
    }
    #endregion

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName is nameof(Month))
            RenderColumns();
    }
}