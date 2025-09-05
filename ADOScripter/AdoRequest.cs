using ADOScripter.Models;
using System.Text;
using System.Text.Json;

namespace ADOScripter;
public class AdoRequest
{
    private string pat;
    private string url;
    private int featureId;
    bool debug;
    ConfigModel configModel;

    public AdoRequest(
        int mergeToWi,
        ConfigModel configModel)
    {
        this.featureId = mergeToWi;
        this.pat = configModel.Pat;
        this.url = $"https://dev.azure.com/{configModel.Organization}/{configModel.Project}/_apis/wit/workitems/$Test Case?api-version=7.0";
        this.debug = configModel.Debug;
        this.configModel = configModel;
    }

    // Pseudocode:
    // 1. Check the request body format for Azure DevOps API (should be a JSON Patch array).
    // 2. Ensure the URL is correct for creating work items (project and type).
    // 3. Log the response content for debugging if status is not success.
    // 4. Add error details to the exception for easier troubleshooting.

    public async Task<string> CreateWorkItems(List<CSVModel> TestCaseList)
    {
        TestCaseCreator testCaseCreator = new();
        List<object> testCases = testCaseCreator.addTestcases(TestCaseList, featureId, this.configModel);
        string output = "";
        int count = 0;

        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        foreach (object testCase in testCases)
        {
            if (count > 1 && debug && configModel.ShortMode)
            {
                return output;
            }

            string json = JsonSerializer.Serialize(testCase, options);

            if (debug)
            {
                Console.WriteLine($"WorkItem ID:\t{featureId}");
                Console.WriteLine($"Debug:\t\t{configModel.AreaPath}");
                Console.WriteLine($"IterationPath:\t{configModel.IterationPath}");
                Console.WriteLine(json);
                //return "Debug mode - no work items created.";
            }
            if (!debug)
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json-patch+json"));
                var authToken = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($":{pat}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json-patch+json");
                var response = await client.PostAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    output += responseBody;
                }
                else
                {
                    Console.WriteLine($"Request URL: {url}");
                    Console.WriteLine($"Request Body: {json}");
                    Console.WriteLine($"Response: {responseBody}");
                    throw new Exception($"Error creating work item: {response.StatusCode} - {response.ReasonPhrase}\n{responseBody}");
                }
            }

            count++;
        }

        return output;
    }
}
