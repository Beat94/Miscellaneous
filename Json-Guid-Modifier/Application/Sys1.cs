using Newtonsoft.Json;

namespace Application;

internal class Sys1
{
    internal string inputString { get; set; }

    internal Guid lolz()
    { 
        return Guid.NewGuid();
    }
}
