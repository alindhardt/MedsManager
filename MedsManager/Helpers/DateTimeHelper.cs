using System.Globalization;

namespace MedsManager.Helpers;

public static class DateTimeHelper
{
    public static DateTime GetSunday(this DateTime dateTime)
        => new GregorianCalendar().AddDays(dateTime, -(int)dateTime.DayOfWeek);
}
