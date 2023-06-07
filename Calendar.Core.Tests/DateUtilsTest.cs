namespace Calendar.Core.Tests;

using static DateUtils;

[TestFixture]
public class DateUtilsTest
{
    [Test]
    public void GetCalendarTableTest()
    {
        int[,] result = GetCalendarTable(new DateTime(2023, 6, 1));
        int[,] expected = GetExpectedTable();
        Assert.That(result, Is.EqualTo(expected));
    }

    private int[,] GetExpectedTable()
    {
        return new int[,]
        {
            {0, 0, 0, 0, 1, 2, 3},
            {4, 5, 6, 7, 8, 9, 10},
            {11, 12, 13, 14, 15, 16, 17},
            {18, 19, 20, 21, 22, 23, 24},
            {25, 26, 27, 28, 29, 30, 0},
        };
    }
}