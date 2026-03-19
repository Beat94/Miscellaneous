using ImmoScraper.DataModel;
using System;
using System.Globalization;

public class HomegateScraper
{
    private static string url = "https://www.homegate.ch/mieten/immobilien/";
    private string requestURL = string.Empty;
    private Toolbox toolbox = new();

    public void Starter()
    {
        
    }
    
    private void urlCreator(HomegateImmoSetting immoSetting)
    {
        string returnUrl = url;
        
        // Theory: if specific value is set - add the value to the string
        if (Enum.IsDefined(typeof(HomegateImmoSetting), immoSetting.regionType))
        {
            if (!string.IsNullOrEmpty(immoSetting.regionInfo))
            {
                returnUrl = string.Concat(
                    returnUrl, 
                    toolbox.RegionTypeToString(immoSetting.regionType), 
                    "-", 
                    immoSetting.regionInfo);
            }
        }
        
        requestURL = returnUrl;
    }
}