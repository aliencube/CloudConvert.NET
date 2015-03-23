namespace Aliencube.CloudConvert.Wrapper.DataFormats
{
    /// <summary>
    /// This represents the presentation format entity.
    /// </summary>
    public class Presentation
    {
        /// <summary>
        /// Encapsulated PostScript
        /// </summary>
        public string Eps { get { return "eps"; } }

        /// <summary>
        /// HTML Document
        /// </summary>
        public string Html { get { return "html"; } }

        /// <summary>
        /// Keynote Presentation
        /// </summary>
        public string Key { get { return "key"; } }

        /// <summary>
        /// Zipped Keynote Presentation
        /// </summary>
        public string KeyZip { get { return "key.zip"; } }

        /// <summary>
        /// OpenDocument Presentation
        /// </summary>
        public string Odp { get { return "odp"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// PowerPoint Slide Show
        /// </summary>
        public string Pps { get { return "pps"; } }

        /// <summary>
        /// PowerPoint Open XML Slide Show
        /// </summary>
        public string Ppsx { get { return "ppsx"; } }

        /// <summary>
        /// Microsoft PowerPoint 97/2000/XP
        /// </summary>
        public string Ppt { get { return "ppt"; } }

        /// <summary>
        /// Microsoft PowerPoint XML
        /// </summary>
        public string Pptx { get { return "pptx"; } }

        /// <summary>
        /// PostScript
        /// </summary>
        public string Ps { get { return "ps"; } }

        /// <summary>
        /// StarDraw 5.0 (OpenOffice.org Impress)
        /// </summary>
        public string Sda { get { return "sda"; } }

        /// <summary>
        /// Macromedia Flash (SWF)
        /// </summary>
        public string Swf { get { return "swf"; } }
    }
}