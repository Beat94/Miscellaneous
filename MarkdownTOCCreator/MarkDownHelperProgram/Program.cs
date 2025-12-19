public static class Program
{
    public static void Main(string[]args)
    {
        bool isTesting = false;
        string linkToMarkdown = "C:\\Users\\Support-Fach.md";

        MarkdownHelper markdownHelper = new(isTesting);

        markdownHelper.GoThroughFile(linkToMarkdown);

        markdownHelper.TocToClipboard();
    }
}
