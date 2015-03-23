using System;
using Aliencube.CloudConvert.Wrapper.DataFormats;

namespace Aliencube.CloudConvert.Wrapper.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>Formats</c> class.
    /// </summary>
    public interface IFormats : IDisposable
    {
        /// <summary>
        /// Gets the <c>Archive</c> formats.
        /// </summary>
        Archive Archive { get; }

        /// <summary>
        /// Gets the <c>Audio</c> formats.
        /// </summary>
        Audio Audio { get; }

        /// <summary>
        /// Gets the <c>Cad</c> formats.
        /// </summary>
        Cad Cad { get; }

        /// <summary>
        /// Gets the <c>Document</c> formats.
        /// </summary>
        Document Document { get; }

        /// <summary>
        /// Gets the <c>Ebook</c> formats.
        /// </summary>
        Ebook Ebook { get; }

        /// <summary>
        /// Gets the <c>Font</c> formats.
        /// </summary>
        Font Font { get; }

        /// <summary>
        /// Gets the <c>Image</c> formats.
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// Gets the <c>Presentation</c> formats.
        /// </summary>
        Presentation Presentation { get; }

        /// <summary>
        /// Gets the <c>Spreadsheet</c> formats.
        /// </summary>
        Spreadsheet Spreadsheet { get; }

        /// <summary>
        /// Gets the <c>Vector</c> formats.
        /// </summary>
        Vector Vector { get; }

        /// <summary>
        /// Gets the <c>Video</c> formats.
        /// </summary>
        Video Video { get; }

        /// <summary>
        /// Gets the <c>Website</c> formats.
        /// </summary>
        Web Website { get; }
    }
}