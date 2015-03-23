using System;

namespace Aliencube.CloudConverter.Wrapper.Options
{
    /// <summary>
    /// This represents the converter options entity for markdown.
    /// </summary>
    public partial class MarkdownConverterOptions : BaseConverterOptions
    {
        /// <summary>
        /// Checks whether the <c>OutputMarkdownSyntax</c> property should be serialised or not.
        /// </summary>
        /// <returns>Returns <c>True</c>, if the <c>OutputMarkdownSyntax</c> property is not null; otherwise returns <c>False</c>.</returns>
        public bool ShouldSerializeOutputMarkdownSyntax()
        {
            return !String.IsNullOrWhiteSpace(this.OutputMarkdownSyntax);
        }
    }
}