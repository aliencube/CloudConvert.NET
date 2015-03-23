namespace Aliencube.CloudConverter.Wrapper.DataFormats
{
    /// <summary>
    /// This represents the font format entity.
    /// </summary>
    public class Font
    {
        /// <summary>
        /// Embedded OpenType
        /// </summary>
        public string Eot { get { return "eot"; } }

        /// <summary>
        /// OpenType
        /// </summary>
        public string Otf { get { return "otf"; } }

        /// <summary>
        /// TrueType
        /// </summary>
        public string Ttf { get { return "ttf"; } }

        /// <summary>
        /// Web Open Font Format
        /// </summary>
        public string Woff { get { return "woff"; } }
    }
}