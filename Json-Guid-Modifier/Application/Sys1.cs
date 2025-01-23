using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application;

public class Sys1 : IJsonSystem
{
    public JObject SetNewGuids(JObject input, string[] valuesToChange)
    {
        // should go through valuesToChange and set new Guids

        try
        {
            foreach (string value in valuesToChange)
            {
                input[value] = Guid.NewGuid().ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return input;
    }
}
