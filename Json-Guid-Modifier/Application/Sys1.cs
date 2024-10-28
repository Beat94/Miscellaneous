using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application;

public class Sys1 : IJsonSystem
{
    internal Guid lolz()
    { 
        return Guid.NewGuid();
    }

    public JObject SetNewGuids(JObject input, string[] valuesToChange)
    {
        // should go through valuesToChange and set new Guids
        foreach (string value in valuesToChange)
        {
            try
            {
                
            }
            catch (Exception ex)
            { 
                
            }
        }

        return input;
    }
}
