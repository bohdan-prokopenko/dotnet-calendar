namespace Calendar;

public static class ConsoleUtils
{
    private const string _1Space = @" ";
    private const string _2Space = @"  ";
    private const string _3Space = @"   ";

    public static void PrintTable(
        DateTime[,] table,
        Func<DateTime, bool> isGreen,
        Func<DateTime, bool> isBlue,
        Func<DateTime, bool> isRed
    )
    {
        int rows = table.GetLength(0);
        int columns = table.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (table[i, j] == DateTime.MinValue)
                {
                    Console.Write(_3Space);
                    continue;
                }
                
                if (isRed(table[i, j]) && isBlue(table[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    PrintNumber(table[i, j]);
                    Console.ResetColor();
                    continue;
                }
                
                if (isRed(table[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintNumber(table[i, j]);
                    Console.ResetColor();
                    continue;
                }

                if (isGreen(table[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    PrintNumber(table[i, j]);
                    Console.ResetColor();
                    continue;
                }

                if (isBlue(table[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    PrintNumber(table[i, j]);
                    Console.ResetColor();
                    continue;
                }

                PrintNumber(table[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static void PrintTitle(IEnumerable<string> titles)
    {
        IEnumerable<string> shortTitles = titles
            .Select(t => _1Space + t);

        Console.WriteLine(string.Join("", shortTitles));
    }

    private static void PrintNumber(DateTime date)
    {
        Console.Write(
            date.Day < 10
                ? _2Space + date.Day
                : _1Space + date.Day
        );
    }
}