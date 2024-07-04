using TimeCalcCalc;
using TimeCalcCalc.Models;

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

    /*
    [Theory]
    [InlineData("{'Start':'28.03.24','End':'30.03.24'}")]
    public void LoadconfigTest(string input)
    {
        // new Config out of inlinedate
        Config testConfig = tb.LoadConfig(input);

        // Compare result with inputdata
        Assert.Equal("", testConfig);
    }
    */
}