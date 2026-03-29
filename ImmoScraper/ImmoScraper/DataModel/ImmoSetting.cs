namespace ImmoScraper.DataModel;

public class ImmoSetting
{
    // This one is Homegate-Specific
    public RegionType? regionType { get; set; }
    public string? regionInfo { get; set; }
    public string? umkreisInMeter { get; set; }
    public string? anzZimmerVon { get; set; }
    public string? anzZimmerBis { get; set; }
    public bool? inserateMitPreis { get; set; }
    public int? preisVon { get; set; }
    public int? preisBis { get; set; }
    public int? baujahrVon { get; set; }
    public int? baujahrBis { get; set; }
    public int? flaecheVon { get; set; }
    public int? flaecheBis { get; set; }
}