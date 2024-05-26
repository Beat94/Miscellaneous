using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCalcCalc.Models;

public class Config
{
    public string Location { get; set; }
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
}
