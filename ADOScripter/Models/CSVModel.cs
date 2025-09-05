namespace ADOScripter.Models;

public class CSVModel
{
    public int AlterVersPerson { get; set; }
    public bool BasisVorsorge { get; set; }
    public bool ZusatzVorsorge { get; set; }
    public bool MultipleBasisvorsorge { get; set; }
    public bool MultipleZusatzvorsorge { get; set; }
    public bool is1e { get; set; }
    public bool isFZP { get; set; }
    public bool isAvisierungPensionierung { get; set; }
    public string Versandquelle { get; set; }
    public string Brief { get; set; }
    public bool Talon { get; set; }
    public bool Broschure { get; set; }
    public string Titelergaenzung { get; set; }
}
