using ImmoScraper;
using ImmoScraper.DataModel;
using Microsoft.Playwright;

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
        
        Assert.True(true);
    }

    // Playwright test
    [Fact]
    public async Task Test2()
    {
        ImmoSetting immoSetting = new ImmoSetting()
        {
            regionType = RegionType.Plz,
            regionInfo = "8840"
        };
        
        HomegateScraper scraper = new HomegateScraper();
        string url = scraper.urlCreator(immoSetting);
        
        
        using var playwright = await Playwright.CreateAsync();
        
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, // Set to false so you can see it happen
            Args = new[] { "--disable-blink-features=AutomationControlled" }
        });
        
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        
        
        await page.GotoAsync(url);

        Console.Write("Press Enter:");
        Console.ReadLine();

        await browser.CloseAsync();
        
        Assert.True(true);
    }
}