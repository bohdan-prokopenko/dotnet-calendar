using static Calendar.Core.DateUtils;
using static Calendar.ConsoleUtils;

DateTime date = FromString(args.Length > 0 ? args[0] : null);
DateTime[,] table = GetCalendarTable(date);

PrintTitle(GetDaysOfWeekShort());
PrintTable(table, IsWeekend, IsCurrentDay, (d1) => date == d1);
Console.WriteLine("Press any key to exit.");
Console.ReadLine();