public static class Program
{
    public static void Main(string[]args)
    {
        bool isTesting = false;
        string linkToMarkdown = "C:\\Users\\reyb\\OneDrive - Swiss Life AG\\H Laufwerk\\Dokumente\\Projekte\\2025\\Christine-Fach\\Support-Fach\\Support-Fach.md";

        MarkdownHelper markdownHelper = new(isTesting);

        markdownHelper.GoThroughFile(linkToMarkdown);

        markdownHelper.TocToClipboard();
    }
}