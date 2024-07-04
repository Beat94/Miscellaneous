using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCalcCalc.Models;

public class Config
{
    public string LocationFiles { get; set; }
    public string LocationOutput {get; set; }
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
}
