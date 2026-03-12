namespace ImmoScraper.DataModel;

public class RealEstate
{
    public string title { get; set; }
    public string strasse { get; set; }
    public string ort { get; set; } // with PLZ
    public long price { get; set; }
    public string phoneNumber { get; set; }
    public string link { get; set; }
    public bool isDuplicate { get; set; }
    public int idOfFirstDupliciate { get; set; }
}