namespace Aliencube.CloudConverter.Services.Options
{
    public class MarkdownConverterOptionKeys
    {
        public const string InputMarkdownSyntax = "input_markdown_syntax";
        public const string OutputMarkdownSyntax = "output_markdown_syntax";
    }

    public class MarkdownSyntaxType
    {
        public const string Auto = null;
        public const string Strict = "strict";
        public const string MultiMarkdown = "mmd";
        public const string PandocExtendedMarkdown = "pandoc";
        public const string GitHubFlavourdMarkdown = "github";
    }
}