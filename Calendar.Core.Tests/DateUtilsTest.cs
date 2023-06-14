namespace Calendar.Core.Tests;

using static DateUtils;

[TestFixture]
public class DateUtilsTest
{
    [Test]
    public void GetCalendarTableTest()
    {
        DateTime[,] result = GetCalendarTable(new DateTime(2023, 6, 1));
        Assert.That(result[2,3], Is.EqualTo(new DateTime(2023,06, 14)));
        Assert.That(result[3,3], Is.EqualTo(new DateTime(2023,06, 21)));
        Assert.That(result[4,2], Is.EqualTo(new DateTime(2023,06, 27)));
    }
}