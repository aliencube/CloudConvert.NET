namespace Aliencube.CloudConverter.Services.DataFormats
{
    /// <summary>
    /// This represents the document format entity.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// AbiWord Document
        /// </summary>
        public string Abw { get { return "abw"; } }

        /// <summary>
        /// DjVu
        /// </summary>
        public string Djvu { get { return "djvu"; } }

        /// <summary>
        /// Microsoft Word
        /// </summary>
        public string Doc { get { return "doc"; } }

        /// <summary>
        /// Microsoft Office Open XML
        /// </summary>
        public string Docx { get { return "docx"; } }

        /// <summary>
        /// HTML Document
        /// </summary>
        public string Html { get { return "html"; } }

        /// <summary>
        /// Lotus Word Pro
        /// </summary>
        public string Lwp { get { return "lwp"; } }

        /// <summary>
        /// Markdown Documentation File
        /// </summary>
        public string Md { get { return "md"; } }

        /// <summary>
        /// ODF Text Document
        /// </summary>
        public string Odt { get { return "odt"; } }

        /// <summary>
        /// Pages Document
        /// </summary>
        public string Pages { get { return "pages"; } }

        /// <summary>
        /// Zipped Pages Document
        /// </summary>
        public string PagesZip { get { return "pages.zip"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// Rich Text Format
        /// </summary>
        public string Rtf { get { return "rtf"; } }

        /// <summary>
        /// StarWriter 5.0
        /// </summary>
        public string Sdw { get { return "sdw"; } }

        /// <summary>
        /// LaTeX Source Document
        /// </summary>
        public string Tex { get { return "tex"; } }

        /// <summary>
        /// Text
        /// </summary>
        public string Txt { get { return "txt"; } }

        /// <summary>
        /// WordPerfect Document
        /// </summary>
        public string Wpd { get { return "wpd"; } }

        /// <summary>
        /// Microsoft Works Document
        /// </summary>
        public string Wps { get { return "wps"; } }

        /// <summary>
        /// Compressed AbiWord Document
        /// </summary>
        public string Zabw { get { return "zabw"; } }
    }
}