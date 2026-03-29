using ImmoScraper.DataModel;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class HomegateScraper
{
    private static string url = "https://www.homegate.ch/mieten/immobilien/";
    private Toolbox toolbox = new();

    public void Starter(ImmoSetting immoSetting)
    {
        string requestUrl = urlCreator(immoSetting);
        
        // go Through items and return them to main function - to add them into sqlite-db 
        List<object> objectList = getImmobiles(requestUrl);
    }

    public List<object> getImmobiles(string requestUrl)
    {
        
        HttpResponseMessage response = new HttpResponseMessage();
        
        // Go through website and scrape data
        using (HttpClient _httpClient = new HttpClient()) 
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 ...");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "de-DE, ...");
    
            response = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();
        }

        string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        Console.WriteLine(responseBody);
        
        throw new NotImplementedException();
    }

    public string urlCreator(ImmoSetting immoSettingInput)
    {
        string returnUrl = url;
        
        // Theory: if specific value is set - add the value to the string
        if (Enum.TryParse<RegionType>(immoSettingInput.regionType.ToString(), out var validatedRegion))
        {
            if (!string.IsNullOrEmpty(immoSettingInput.regionInfo))
            {
                returnUrl = string.Concat(
                    returnUrl, 
                    toolbox.RegionTypeToString(validatedRegion), // Nutze das validierte Enum
                    "-", 
                    immoSettingInput.regionInfo);
            }
        }

        if (!string.IsNullOrWhiteSpace(immoSettingInput.umkreisInMeter) ||
            !string.IsNullOrWhiteSpace(immoSettingInput.anzZimmerVon) ||
            !string.IsNullOrWhiteSpace(immoSettingInput.anzZimmerBis) ||
            immoSettingInput.inserateMitPreis.HasValue ||
            immoSettingInput.preisVon.HasValue ||
            immoSettingInput.preisBis.HasValue ||
            immoSettingInput.baujahrVon.HasValue ||
            immoSettingInput.baujahrBis.HasValue ||
            immoSettingInput.flaecheVon.HasValue ||
            immoSettingInput.flaecheBis.HasValue)
        {
            returnUrl = string.Concat(returnUrl, "trefferliste?");
        }

        List<string> queryParams = new();
        
        if (!string.IsNullOrEmpty(immoSettingInput.umkreisInMeter))
        {
            //returnUrl = string.Concat(returnUrl, "/be=" ,immoSettingInput.umkreisInMeter);
            queryParams.Add(string.Concat("be=",immoSettingInput.umkreisInMeter));
        }

        if (immoSettingInput.baujahrVon.HasValue)
        {
            queryParams.Add(string.Concat("bf=", immoSettingInput.baujahrVon.ToString()));
        }

        if (immoSettingInput.baujahrBis.HasValue)
        {
            queryParams.Add(string.Concat("bg=", immoSettingInput.baujahrBis.ToString()));
        }
        
        if (immoSettingInput.flaecheVon.HasValue)
        {
            queryParams.Add(string.Concat("ak=", immoSettingInput.flaecheVon.ToString()));
        }

        if (immoSettingInput.flaecheBis.HasValue)
        {
            queryParams.Add(string.Concat("al=", immoSettingInput.flaecheBis.ToString()));
        }
        
        if (!string.IsNullOrEmpty(immoSettingInput.anzZimmerVon))
        {
            queryParams.Add(string.Concat("ac=", immoSettingInput.anzZimmerVon));
        }

        if (!string.IsNullOrEmpty(immoSettingInput.anzZimmerBis))
        {
            queryParams.Add(string.Concat("ad=", immoSettingInput.anzZimmerBis));
        }
        
        if (immoSettingInput.inserateMitPreis.HasValue && immoSettingInput.inserateMitPreis == true)
        {
            queryParams.Add(string.Concat("ipd=", immoSettingInput.inserateMitPreis));
        }
        
        if (immoSettingInput.preisVon.HasValue)
        {
            queryParams.Add(string.Concat("ag=", immoSettingInput.preisVon.ToString()));
        }

        if (immoSettingInput.preisBis.HasValue)
        {
            queryParams.Add(string.Concat("ah=", immoSettingInput.preisBis));
        }
        
        // connect string with &
        
        return string.Concat(returnUrl, string.Join("&", queryParams));
    }
}