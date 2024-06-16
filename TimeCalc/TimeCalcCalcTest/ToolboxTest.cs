using TimeCalcCalc;

namespace TimeCalcCalcTest;
public class ToolboxText
{
    Toolbox tb = new Toolbox();

    [Theory]
    [InlineData("today_01-02-23.txt", 01,02,23)]
    public void DateOnlyToFilenameTest(string excpected, int day, int month, int year)
    {
        DateOnly date = new DateOnly(year,month,day);
        string testValue = tb.DateOnlyToFilename(date);
        Assert.Equal(excpected,testValue) ;
    }

    [Theory]
    [InlineData()]
    public void InputToConfigTest()
    {
        // new Config out of inlinedate

        // 
    }
}