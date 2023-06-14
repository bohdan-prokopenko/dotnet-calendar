namespace Calendar.Core;

public static class DateUtils
{
    private const int FirstDay = 1;
    private static readonly DateTime CurrentDate = DateTime.Now;

    public static bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    public static bool IsCurrentDay(DateTime date)
    {
        return date == new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day);
    }

    public static DateTime[,] GetCalendarTable(DateTime dateTime)
    {
        int weeksInMonth = GetWeeksInCurrentMonth(dateTime);
        int daysInWeek = GetDaysInWeek();
        int daysInMonth = GetDaysInCurrentMonth(dateTime);
        var table = new DateTime[weeksInMonth, daysInWeek];
        int dayOfMonth = GetFirstDayOfMonth(dateTime).Day;

        for (int row = 0; row <= weeksInMonth; row++)
        {
            for (int column = 0; column < daysInWeek && dayOfMonth <= daysInMonth; column++)
            {
                DateTime date = new(dateTime.Year, dateTime.Month, dayOfMonth);
                column = (int) date.DayOfWeek;
                table[row, column] = date;
                dayOfMonth++;
            }
        }

        return table;
    }

    public static IEnumerable<string> GetDaysOfWeekShort()
    {
        return GetWeekDays().Select(d => d.ToString()[..2]);
    }

    public static DateTime FromString(string? str)
    {
        DateTime date = DateTime.Now;
        try
        {
            date = DateTime.Parse(str);
        }
        catch (ArgumentNullException)
        {
        }
        catch (FormatException)
        {
            Console.WriteLine($"The string '{str}' was not recognized as a valid DateTime.");
        }

        return date;
    }

    private static int GetWeeksInCurrentMonth(DateTime dateTime)
    {
        double daysInWeek = GetDaysInWeek();
        DateTime currentMonthEnd = GetLastDayOfMonth(dateTime);
        int daysInCurrentMonth = currentMonthEnd.Day;
        double weeksInMonth = Math.Ceiling(daysInCurrentMonth / daysInWeek);
        return (int) weeksInMonth;
    }

    private static int GetDaysInCurrentMonth(DateTime dateTime)
    {
        return GetLastDayOfMonth(dateTime).Day;
    }

    private static int GetDaysInWeek()
    {
        List<DayOfWeek> weekdays = GetWeekDays();
        return weekdays.Count;
    }

    private static List<DayOfWeek> GetWeekDays()
    {
        return Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
    }

    private static DateTime GetFirstDayOfMonth(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, FirstDay);
    }

    private static DateTime GetLastDayOfMonth(DateTime dateTime)
    {
        return GetFirstDayOfMonth(dateTime).AddMonths(1).AddDays(-1);
    }
}