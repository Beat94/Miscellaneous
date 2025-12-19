using TextCopy;
using System.Windows;
public class MarkdownHelper
{
    string[] charPattern = [
        "!", "?", ".", ",", ":", ";", "'", "(", ")", "[", "]", "{", "}",
        "@", "$", "%", "#", "^", "&", "*", "+", "=", "|", "/", "<", ">"];


    private bool testing;
    List<(string toc, string desc)> tableOfContent = new();
    List<string> markdownFileList = new();

    public MarkdownHelper(bool testing)
    {
        this.testing = testing;
    }

    /// <summary>
    /// This function goes through file and checks if lines - 
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="testing"></param>
    /// <returns></returns>
    public List<(string toc, string desc)> GoThroughFile(string filePath)
    {
        if(!testing)
        {
            markdownFileList = File.ReadAllLines(filePath).ToList();
        }
        else
        {
            markdownFileList = filePath.Split("\n").ToList();
        }

        if(markdownFileList.Count == 0)
        {
            throw new NullReferenceException();
        }

        foreach (string line in markdownFileList)
        {
            if(line.Length > 0)
            {
                if(line[0] == '#')
                {
                    tableOfContent.Add((chapterToToc(ReplaceStart(line)), 
                        ReplaceStart(line)));
                }
            }
        }

        return tableOfContent;
    }

    private string ReplaceStart(string input)
    => input.Replace("#",string.Empty).TrimStart();

    public string chapterToToc(string input)
    {
        foreach(string cPattern in charPattern)
        {
            input = input.ToLower().Replace(cPattern, string.Empty);
            input = input.Replace(" ", "-");
        }   

        return input;
    }

    public string createTOC()
    {
        string output = string.Empty;

        foreach((string toc, string desc) line in tableOfContent)
        {
            output += $"[{line.desc}](#{line.toc})\n";
        }

        return output;
    }

    public void TocToClipboard()
    {
        var clipboard = new Clipboard();
        clipboard.SetText(createTOC());

        Console.WriteLine("TOC ist im Clipboard gesetzt!");
    }

    // for further development
    public void replaceStringWithToc(string tag, string toc)
    {
        int i = 0;

        foreach(string line in markdownFileList)
        {
            markdownFileList[i] = line.Replace(tag, toc);
            i++;
        }
    }
}
