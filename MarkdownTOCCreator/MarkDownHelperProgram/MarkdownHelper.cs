public class MarkdownHelper
{
    string[] charPattern = [
        "!", "?", ".", ",", ":", ";", "'", "(", ")", "[", "]", "{", "}",
        "@", "#", "$", "%", "^", "&", "*", "+", "=", "|", "/", "<", ">"];

    //public List<(string, string)> tableOfContent;

    /// <summary>
    /// This function goes through file and checks if lines - 
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="testing"></param>
    /// <returns></returns>
    public List<(string toc, string desc)> GoThroughFile(string filePath, bool testing)
    {
        List<string> markdownFileList = new();

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

        List<(string, string)> tableOfContent = new();

        foreach (string line in markdownFileList)
        {
            if(line[0] == '#')
            {
                tableOfContent.Add((line.Replace("#",string.Empty).TrimStart(),
                chapterToToc(line)));
            }
        }

        return tableOfContent;
    }

    public string chapterToToc(string input)
    {
        foreach(string cPattern in charPattern)
        {
            input = input.ToLower().Replace(cPattern, string.Empty);
        }   

        return input;
    }


}