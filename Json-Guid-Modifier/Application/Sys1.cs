using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application;

internal class Sys1 : IJsonSystem
{
    internal Guid lolz()
    { 
        return Guid.NewGuid();
    }

    internal JObject SetNewGuids(JObject input, string[] valuesToChange)
    {
        // should go through valuesToChange and set new Guids
        foreach (string value in valuesToChange)
        { 
            //input.
        }
        throw new NotImplementedException();
    }
}
