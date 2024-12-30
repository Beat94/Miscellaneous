using RDP_File_Creator.Models;
using RdpConnection;
using System.Text;
using System.Text.Json;

namespace RDP_File_Creator;
class Program
{ 
    public static void Main()
    {
        string inputJsonLocation = ".\\Input-Files\\input.json";
        string outputRdpLocation = "C:\\Users\\[Username]";

        Console.WriteLine($"Input-File: {inputJsonLocation}");
        Console.WriteLine($"Output-Location: {outputRdpLocation}");

        Input input;

        try 
        {
            input = JsonSerializer.Deserialize<Input>(File.ReadAllText(inputJsonLocation));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Error-Data: {ex.Data}");
            return;
        }

        foreach (string server in input.ServerNames)
        {
            var rdp = new MicrosoftTerminalServiceClientProperties()
            {
                FullAddress = server,
                ScreenModeId = 2, // 1: window mode, 2: full screen
                Username = input.Username
            };

            rdp.SetPassword(input.Password);

            File.WriteAllText(@$"{outputRdpLocation}\{server}.rdp", string.Join(Environment.NewLine, rdp.Serialize()), new UTF8Encoding(false));
        }
    }
}