using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

#nullable enable
public class AdoHelper
{
    private string organisation;
    private string project;
    private string pat;
    private bool debug;

    public AdoHelper(string organisation, string project, string pat, bool debug)
    {
        this.organisation = organisation;
        this.project = project;
        this.pat = pat;
        this.debug = debug;
    }

    public async Task<JsonElement> getRelatedWorkItemsByWorkItemId(string WorkItemId)
    {
        string requestUrl = $"https://dev.azure.com/{this.organisation}/{this.project}/_apis/wit/workitems/{WorkItemId}?%24expand=relations&api-version=7.0";
        List<string> outputWorkItemId = new List<string>();
        HttpClient client = new HttpClient();
        string authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes(":" + this.pat));
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json-patch+json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        HttpResponseMessage response = await client.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();
        Stream stream = await response.Content.ReadAsStreamAsync();
        JsonDocument doc = await JsonDocument.ParseAsync(stream);
        JsonElement rootElement = doc.RootElement;

        return rootElement;
    }

    public async Task<List<(string id, string workitemType)>> getJsonElementByAdoCall(
      string workitemId)
    {
        JsonElement jsonElement = await this.getRelatedWorkItemsByWorkItemId(workitemId);
        JsonElement jsonRoot = jsonElement;

        List<(string, string)> outputWorkItemId = new List<(string, string)>();
        foreach (JsonElement jsonRelation in jsonRoot.GetProperty("relations").Deserialize<List<JsonElement>>())
        {
            JsonElement element = jsonRelation;
            string relatedWorkItemId = (element.GetProperty("url").ToString().Split("/")).Last<string>();
            string relatedWorkItemType = await this.getItemByWorkItemId(relatedWorkItemId);
            outputWorkItemId.Add((relatedWorkItemId, relatedWorkItemType));
        }
        List<(string, string)> elementByAdoCall = outputWorkItemId;

        return elementByAdoCall;
    }

    public async Task<string> getItemByWorkItemId(string workitemId)
    {
        JsonElement jsonElement = await this.getRelatedWorkItemsByWorkItemId(workitemId);
        JsonElement jsonRoot = jsonElement;
        string itemByWorkItemId = jsonRoot.GetProperty("fields").GetProperty("System.WorkItemType").ToString();

        return itemByWorkItemId;
    }

    public async Task setWorkitemCancel(string workItemId, string workItemType)
    {
        string finalState = string.Empty;
        if (workItemType.Equals("Test Case", StringComparison.InvariantCultureIgnoreCase))
            finalState = "Closed";
        else if (workItemType.Equals("Task", StringComparison.InvariantCultureIgnoreCase))
            finalState = "Removed";

        await this.setWorkitemState(workItemId, finalState);
    }

    // here
    public async Task setWorkitemState(string workItemId, string setState)
    {
        string requestUrl = $"https://dev.azure.com/{this.organisation}/{this.project}/_apis/wit/workitems/{workItemId}?%24expand=relations&api-version=7.0";
        var ops = new []
        {
            new
            {
                op = "add",
                path = "/fields/System.State",
                value = setState
            },
            new
            {
                op = "add",
                path = "/fields/System.History",
                value = "Status via API aktualisiert"
            }
        };
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json-patch+json"));
        string authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes(":" + this.pat));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        string patchBody = JsonSerializer.Serialize(ops);
        StringContent content = new StringContent(patchBody, Encoding.UTF8, "application/json-patch+json");
        HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUrl)
        {
            Content = (HttpContent)content
        };


        HttpResponseMessage response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string result = await response.Content.ReadAsStringAsync();
        if (this.debug)
        {
            Console.WriteLine(result);
        }
    }
}