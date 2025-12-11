using System.ComponentModel;
using FluentAssertions;
public class MarkdownHelperTest
{
    MarkdownHelper markdownHelper = new MarkdownHelper();

    [Theory]
    #region Testdata
    [InlineData("a!b", "ab")]
    [InlineData("a?b", "ab")]
    [InlineData("a.b", "ab")]
    [InlineData("a,b", "ab")]
    [InlineData("a:b", "ab")]
    [InlineData("a;b", "ab")]
    [InlineData("a'b", "ab")]
    [InlineData("a(b", "ab")]
    [InlineData("a)b", "ab")]
    [InlineData("a[b", "ab")]
    [InlineData("a]b", "ab")]
    [InlineData("a{b", "ab")]
    [InlineData("a}b", "ab")]
    [InlineData("a@b", "ab")]
    [InlineData("a#b", "ab")]
    [InlineData("a$b", "ab")]
    [InlineData("a%b", "ab")]
    [InlineData("a^b", "ab")]
    [InlineData("a&b", "ab")]
    [InlineData("a*b", "ab")]
    [InlineData("a+b", "ab")]
    [InlineData("a=b", "ab")]
    [InlineData("a|b", "ab")]
    [InlineData("a/b", "ab")]    // Slash
    [InlineData("a<b", "ab")]
    [InlineData("a>b", "ab")]
    #endregion
    public void chapterToToc(string input, string targetValue)
    {
        string result = markdownHelper.chapterToToc(input);

        result.Should().Be(targetValue);
    }

    
    [Theory]
    // Fall 1: einfache Überschriften mit unterschiedlichen Levels und Satzzeichen
    [InlineData(
        "# Kapitel 1\n" +
        "Text unterhalb.\n" +
        "## Kapitel 2: Übersicht!\n" +
        "Noch ein Text.\n" +
        "### Kapitel 3 (Details)\n",
        new[] { "Kapitel 1", "Kapitel 2 Übersicht!", "Kapitel 3 (Details)" },
        new[] { "# kapitel 1", "## kapitel 2: übersicht!", "### kapitel 3 (details)" } // Erwartete TOC vor Cleaning? Siehe unten – wird bereinigt
    )]
    // Fall 2: Zeichenbereinigung (&, <, >, ?, :, etc.) durch chapterToToc
    [InlineData(
        "# Einführung &amp; Überblick\n" +
        "Normale Zeile.\n" +
        "## Ziele: Was wollen wir?\n" +
        "### Begriffe &lt;Definitionen&gt;\n",
        new[] { "Einführung amp; Überblick", "Ziele Was wollen wir?", "Begriffe lt;Definitionengt;" },
        new[] { "# einführung  überblick", "## ziele was wollen wir", "### begriffe definitionen" }
    )]
    public void GoThroughFile(string inputText, string[] desc, string[] toc)
    {
        List<(string desc, string toc)> result = markdownHelper.GoThroughFile(inputText, true);

        result[0].desc.Should().Contain(desc[0]);
        result[0].toc.Should().Contain(toc[0]);
    }
}
