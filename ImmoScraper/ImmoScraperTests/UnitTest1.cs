using ImmoScraper;
using ImmoScraper.DataModel;

namespace ImmoScraperTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        ImmoSetting immoSetting = new ImmoSetting()
        {
            regionType = RegionType.Plz,
            regionInfo = "8840"
        };
        
        HomegateScraper scraper = new HomegateScraper();
        string url = scraper.urlCreator(immoSetting);

        var immobilies = scraper.getImmobiles(url);
        
        Assert.Equal(true, true);
    }
}