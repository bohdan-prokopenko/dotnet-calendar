using static Calendar.Core.DateUtils;
using static Calendar.ConsoleUtils;

int[,] table = GetCalendarTable(DateTime.Now);

PrintTitle(GetDaysOfWeekShort());
PrintTable(table, IsWeekend, IsCurrentDay);
Console.ReadLine();