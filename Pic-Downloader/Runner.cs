using System.Net;

namespace picDownloader;
public class Runner
{
    public string savepath { get; set; }
    public string datapath { get; set; }
    public string cookie { get; set; }

    public void running()
    {
        if (string.IsNullOrEmpty(savepath) || string.IsNullOrEmpty(datapath))
        {
            throw new NullReferenceException("check saveURL or datapath - one or both are appearing empty");
        }

        List<string> urls = getLinkList(savepath); ;

        string fileName = string.Empty;
        foreach (string url in urls)
        {
            fileName = url.Split('/').Last();

            _ = getPic(url, $"{datapath}/{fileName}", cookie);

            Console.WriteLine($"File {url} wurde herunter geladen und gespeichert");
            Thread.Sleep(1000);
        }
    }

    private async Task getPic(string url, string savePath, string cookieInput)
    {
        using (var handler = new HttpClientHandler())
        {

            if (!string.IsNullOrEmpty(cookieInput))
            {
                string[] cookiePairs = cookieInput.Split(';');
                foreach (string cookiePair in cookiePairs)
                {
                    string[] parts = cookiePair.Trim().Split('=');
                    if (parts.Length == 2)
                    {
                        handler.CookieContainer.Add(new Uri(url), new Cookie(parts[0], parts[1]));
                    }
                }
            }

            using (HttpClient httpClient = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    byte[] picRaw = await response.Content.ReadAsByteArrayAsync();
                    await File.WriteAllBytesAsync(savePath, picRaw);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error fetching {url}\n{e.Message}");
                }
            }
        }
    }

    /// <summary>
    /// Loads file (usual txt-file, each line one link to a picture) list into string-list and returns it
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private List<string> getLinkList(string path)
        => File.ReadAllLines(path).ToList<string>();
}