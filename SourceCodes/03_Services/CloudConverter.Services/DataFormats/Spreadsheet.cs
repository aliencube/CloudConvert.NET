namespace Aliencube.CloudConverter.Services.DataFormats
{
    /// <summary>
    /// This represents the spreadsheet format entity.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// CSV
        /// </summary>
        public string Csv { get { return "csv"; } }

        /// <summary>
        /// HTML Document
        /// </summary>
        public string Html { get { return "html"; } }

        /// <summary>
        /// Numbers Spreadsheet
        /// </summary>
        public string Numbers { get { return "numbers"; } }

        /// <summary>
        /// Zipped Numbers Spreadsheet
        /// </summary>
        public string NumbersZip { get { return "numbers.zip"; } }

        /// <summary>
        /// Open Document Spreadsheet
        /// </summary>
        public string Ods { get { return "ods"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// StarCalc 5.0
        /// </summary>
        public string Sdc { get { return "sdc"; } }

        /// <summary>
        /// Microsoft Excel 97/2000/XP
        /// </summary>
        public string Xls { get { return "xls"; } }

        /// <summary>
        /// Microsoft Excel XML
        /// </summary>
        public string Xlsx { get { return "xlsx"; } }
    }
}