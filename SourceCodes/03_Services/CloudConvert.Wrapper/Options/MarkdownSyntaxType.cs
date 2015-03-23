namespace Aliencube.CloudConvert.Wrapper.Options
{
    /// <summary>
    /// This represents the markdown syntax type entity.
    /// </summary>
    public class MarkdownSyntaxType
    {
        /// <summary>
        /// Identifies auto detection.
        /// </summary>
        public const string Auto = null;

        /// <summary>
        /// Identifies the original markdown syntax.
        /// </summary>
        public const string Strict = "strict";

        /// <summary>
        /// Identifies the multi-markdown syntax.
        /// </summary>
        public const string MultiMarkdown = "mmd";

        /// <summary>
        /// Identifies the Pandoc extended markdown syntax.
        /// </summary>
        public const string PandocExtendedMarkdown = "pandoc";

        /// <summary>
        /// Identifies the GitHub flavoured markdown syntax.
        /// </summary>
        public const string GitHubFlavourdMarkdown = "github";
    }
}