# Short description
Request  to create testcase and http-request where partly made by copilot - logic made by me.

# Idea
This program adds testcases on other workitems. Each testcase has three teststeps.
The testcases and teststeps gets data out of csv file.

# Input-File
Input-File should have following columns in this order (in German):
- Alter Versicherte Person (integer)
- Basis Vorsorge (ja/nein)
- Zusatzvorsorge (ja/nein)
- Mehrere Basisvorsorge (ja/nein)
- Mehrere Zusatzvorsorge (ja/nein)
- Ist 1e (ja/nein)
- Ist FZP (ja/nein)
- Ist Avisierung Pensionierung (ja/nein)
- Versandquelle (string)
- Brief (string)
- Talon (x for true)
- Broschuere (x for true)
- Titelergänzung (string)

# Config-File
Config-file is placed in ADOScripter/.

```Configuration.json
{
  "Organization": "Company",
  "Project": "Project",
  "Pat": "pat",
  "Debug": false,
  "InputFile": "C:\\Mappe1.CSV",
  "AreaPath": "Company\\Area",
  "IterationPath": "Company\\Sprint 1",
  "ShortMode": false
}
```

# Request
Request should look like:
```c#
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string organization = "your-org";
        string project = "your-project";
        string pat = "your-pat";
        string url = $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/$Test%20Case?api-version=7.1-preview.3";

        var jsonPatch = new[]
        {
            new {
                op = "add",
                path = "/fields/System.Title",
                value = "Automatisierter Testfall aus .NET"
            },
            new {
                op = "add",
                path = "/fields/Microsoft.VSTS.TCM.Steps",
                value = @"
                <steps id='0' last='2'>
                  <step id='1' type='ActionStep'>
                    <parameterizedString isformatted='true'>Schritt 1: Öffne die App</parameterizedString>
                    <parameterizedString isformatted='true'>Erwartet: App öffnet sich</parameterizedString>
                  </step>
                  <step id='2' type='ActionStep'>
                    <parameterizedString isformatted='true'>Schritt 2: Klicke auf Login</parameterizedString>
                    <parameterizedString isformatted='true'>Erwartet: Login-Formular erscheint</parameterizedString>
                  </step>
                </steps>"
            }
        };

        using var client = new HttpClient();
        var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{pat}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(jsonPatch));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");

        var response = await client.PostAsync(url, content);
        var responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine(responseBody);
    }
}
```