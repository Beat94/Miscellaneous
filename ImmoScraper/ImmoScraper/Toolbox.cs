using ImmoScraper.DataModel;

public class Toolbox
{
    public string RegionTypeToString(RegionType? region)
    {
        switch (region)
        {
            case RegionType.Kanton:
                return "kanton";
                break;
            case RegionType.Plz:
                return "plz";
                break;
            case RegionType.Region:
                return "region";
                break;
            case RegionType.Ort:
                return "ort";
                break;
            default:
                return "";
                break;
        }
    }
}