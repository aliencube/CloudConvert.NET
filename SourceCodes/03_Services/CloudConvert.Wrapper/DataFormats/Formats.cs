using Aliencube.CloudConvert.Wrapper.Interfaces;

namespace Aliencube.CloudConvert.Wrapper.DataFormats
{
    /// <summary>
    /// This represents the all formats entity.
    /// </summary>
    public class Formats : IFormats
    {
        private readonly Archive _archive;
        private readonly Audio _audio;
        private readonly Cad _cad;
        private readonly Document _document;
        private readonly Ebook _ebook;
        private readonly Font _font;
        private readonly Image _image;
        private readonly Presentation _presentation;
        private readonly Spreadsheet _spreadsheet;
        private readonly Vector _vector;
        private readonly Video _video;
        private readonly Web _website;

        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <c>Formats</c> class.
        /// </summary>
        public Formats()
        {
            this._archive = new Archive();
            this._audio = new Audio();
            this._cad = new Cad();
            this._document = new Document();
            this._ebook = new Ebook();
            this._font = new Font();
            this._image = new Image();
            this._presentation = new Presentation();
            this._spreadsheet = new Spreadsheet();
            this._vector = new Vector();
            this._video = new Video();
            this._website = new Web();
        }

        /// <summary>
        /// Gets the <c>Archive</c> object.
        /// </summary>
        public Archive Archive { get { return this._archive; } }

        /// <summary>
        /// Gets the <c>Audio</c> object.
        /// </summary>
        public Audio Audio { get { return this._audio; } }

        /// <summary>
        /// Gets the <c>Cad</c> object.
        /// </summary>
        public Cad Cad { get { return this._cad; } }

        /// <summary>
        /// Gets the <c>Document</c> object.
        /// </summary>
        public Document Document { get { return this._document; } }

        /// <summary>
        /// Gets the <c>Ebook</c> object.
        /// </summary>
        public Ebook Ebook { get { return this._ebook; } }

        /// <summary>
        /// Gets the <c>Font</c> object.
        /// </summary>
        public Font Font { get { return this._font; } }

        /// <summary>
        /// Gets the <c>Image</c> object.
        /// </summary>
        public Image Image { get { return this._image; } }

        /// <summary>
        /// Gets the <c>Presentation</c> object.
        /// </summary>
        public Presentation Presentation { get { return this._presentation; } }

        /// <summary>
        /// Gets the <c>Spreadsheet</c> object.
        /// </summary>
        public Spreadsheet Spreadsheet { get { return this._spreadsheet; } }

        /// <summary>
        /// Gets the <c>Vector</c> object.
        /// </summary>
        public Vector Vector { get { return this._vector; } }

        /// <summary>
        /// Gets the <c>Video</c> object.
        /// </summary>
        public Video Video { get { return this._video; } }

        /// <summary>
        /// Gets the <c>Website</c> object.
        /// </summary>
        public Web Website { get { return this._website; } }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}