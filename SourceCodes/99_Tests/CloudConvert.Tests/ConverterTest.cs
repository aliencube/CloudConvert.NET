using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Aliencube.CloudConvert.Tests
{
    [TestFixture]
    public class ConverterTest
    {
        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public async void GetProcessId_GivenApiKey_ReturnResult()
        {
            var service = new ConverterService();
            var formats = new Formats();
            var response = await service.ProcessAsync(formats.Document.Md, formats.Document.Docx);
            response.Id.Should().NotBeNullOrEmpty();
        }
    }

    public class ConverterService
    {
        public async Task<ProcessResponse> ProcessAsync(string inputFormat, string outputFormat)
        {
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            var processUrl = ConfigurationManager.AppSettings["Url.Process"];

            string result;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var request = new ProcessRequest() { InputFormat = inputFormat, OutputFormat = outputFormat };

                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new LowercaseContractResolver();
                var requestString = JsonConvert.SerializeObject(request, Formatting.None, settings);

                using (var content = new StringContent(requestString, Encoding.UTF8, "application/json"))
                using (var response = await client.PostAsync(processUrl, content))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return JsonConvert.DeserializeObject<ProcessResponse>(result);
        }
    }
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }

    public class ProcessRequest
    {
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
    }

    public class ProcessResponse
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Host { get; set; }
        public DateTime Expires { get; set; }
        public int MaxTime { get; set; }
        public int Minutes { get; set; }
    }

    /// <summary>
    /// This represents the all formats entity.
    /// </summary>
    public class Formats
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
        /// Gets the <c>Archive</c> formats.
        /// </summary>
        public Archive Archive
        {
            get { return this._archive; }
        }

        /// <summary>
        /// Gets the <c>Audio</c> formats.
        /// </summary>
        public Audio Audio
        {
            get { return this._audio; }
        }

        /// <summary>
        /// Gets the <c>Cad</c> formats.
        /// </summary>
        public Cad Cad
        {
            get { return this._cad; }
        }

        /// <summary>
        /// Gets the <c>Document</c> formats.
        /// </summary>
        public Document Document
        {
            get { return this._document; }
        }

        /// <summary>
        /// Gets the <c>Ebook</c> formats.
        /// </summary>
        public Ebook Ebook
        {
            get { return this._ebook; }
        }

        /// <summary>
        /// Gets the <c>Font</c> formats.
        /// </summary>
        public Font Font
        {
            get { return this._font; }
        }

        /// <summary>
        /// Gets the <c>Image</c> formats.
        /// </summary>
        public Image Image
        {
            get { return this._image; }
        }

        /// <summary>
        /// Gets the <c>Presentation</c> formats.
        /// </summary>
        public Presentation Presentation
        {
            get { return this._presentation; }
        }

        /// <summary>
        /// Gets the <c>Spreadsheet</c> formats.
        /// </summary>
        public Spreadsheet Spreadsheet
        {
            get { return this._spreadsheet; }
        }

        /// <summary>
        /// Gets the <c>Vector</c> formats.
        /// </summary>
        public Vector Vector
        {
            get { return this._vector; }
        }

        /// <summary>
        /// Gets the <c>Video</c> formats.
        /// </summary>
        public Video Video
        {
            get { return this._video; }
        }

        /// <summary>
        /// Gets the <c>Website</c> formats.
        /// </summary>
        public Web Website
        {
            get { return this._website; }
        }
    }

    /// <summary>
    /// This represents the archive format entity.
    /// </summary>
    public class Archive
    {
        /// <summary>
        /// 7-Zip Compressed File
        /// </summary>
        public string SevenZ { get { return "7z"; } }

        /// <summary>
        /// WinAce Compressed File
        /// </summary>
        public string Ace { get { return "ace"; } }

        /// <summary>
        /// ALZip Archive
        /// </summary>
        public string Alz { get { return "alz"; } }

        /// <summary>
        /// Compressed File Archive
        /// </summary>
        public string Arc { get { return "arc"; } }

        /// <summary>
        /// ARJ Compressed File Archive
        /// </summary>
        public string Arj { get { return "arj"; } }

        /// <summary>
        /// Bzip Compressed File
        /// </summary>
        public string Bz { get { return "bz"; } }

        /// <summary>
        /// Bzip2 Compressed File
        /// </summary>
        public string Bz2 { get { return "bz2"; } }

        /// <summary>
        /// Windows Cabinet File
        /// </summary>
        public string Cab { get { return "cab"; } }

        /// <summary>
        /// Unix CPIO Archive
        /// </summary>
        public string Cpio { get { return "cpio"; } }

        /// <summary>
        /// Debian Software Package
        /// </summary>
        public string Deb { get { return "deb"; } }

        /// <summary>
        /// DMG Image
        /// </summary>
        public string Dmg { get { return "dmg"; } }

        /// <summary>
        /// eMail Message
        /// </summary>
        public string Eml { get { return "eml"; } }

        /// <summary>
        /// Gnu Zipped Archive
        /// </summary>
        public string Gz { get { return "gz"; } }

        /// <summary>
        /// Image
        /// </summary>
        public string Img { get { return "img"; } }

        /// <summary>
        /// ISO image
        /// </summary>
        public string Iso { get { return "iso"; } }

        /// <summary>
        /// Java Archive File
        /// </summary>
        public string Jar { get { return "jar"; } }

        /// <summary>
        /// LHARC Compressed Archive
        /// </summary>
        public string Lha { get { return "lha"; } }

        /// <summary>
        /// Lzip Compressed File
        /// </summary>
        public string Lz { get { return "lz"; } }

        /// <summary>
        /// LZMA Compressed File
        /// </summary>
        public string Lzma { get { return "lzma"; } }

        /// <summary>
        /// LZO Compressed File
        /// </summary>
        public string Lzo { get { return "lzo"; } }

        /// <summary>
        /// WinRAR Archive
        /// </summary>
        public string Rar { get { return "rar"; } }

        /// <summary>
        /// Red Hat Package Manager File
        /// </summary>
        public string Rpm { get { return "rpm"; } }

        /// <summary>
        /// Rzip Compressed File
        /// </summary>
        public string Rz { get { return "rz"; } }

        /// <summary>
        /// Consolidated Unix File Archive
        /// </summary>
        public string Tar { get { return "tar"; } }

        /// <summary>
        /// tar+7zip
        /// </summary>
        public string TarSevenZ { get { return "tar.7z"; } }

        /// <summary>
        /// tar+bzip
        /// </summary>
        public string TarBz { get { return "tar.bz"; } }

        /// <summary>
        /// tar+bzip2
        /// </summary>
        public string TarBz2 { get { return "tar.bz2"; } }

        /// <summary>
        /// tar+gz
        /// </summary>
        public string TarGz { get { return "tar.gz"; } }

        /// <summary>
        /// tar+lzop
        /// </summary>
        public string TarLzo { get { return "tar.lzo"; } }

        /// <summary>
        /// tar+xz
        /// </summary>
        public string TarXz { get { return "tar.xz"; } }

        /// <summary>
        /// tar+compress
        /// </summary>
        public string TarZ { get { return "tar.Z"; } }

        /// <summary>
        /// tar+bzip
        /// </summary>
        public string Tbz { get { return "tbz"; } }

        /// <summary>
        /// tar+bzip2
        /// </summary>
        public string Tbz2 { get { return "tbz2"; } }

        /// <summary>
        /// tar+gz
        /// </summary>
        public string Tgz { get { return "tgz"; } }

        /// <summary>
        /// tar+compress
        /// </summary>
        public string Tz { get { return "tZ"; } }

        /// <summary>
        /// tar+lzop
        /// </summary>
        public string Tzo { get { return "tzo"; } }

        /// <summary>
        /// XZ Compressed Archive
        /// </summary>
        public string Xz { get { return "xz"; } }

        /// <summary>
        /// Unix Compressed File
        /// </summary>
        public string Z { get { return "z"; } }

        /// <summary>
        /// Zipped File
        /// </summary>
        public string Zip { get { return "zip"; } }
    }

    /// <summary>
    /// This represents the audio format entity.
    /// </summary>
    public class Audio
    {
        /// <summary>
        /// Advanced Audio Coding
        /// </summary>
        public string Aac { get { return "aac"; } }

        /// <summary>
        /// Audio Coding 3
        /// </summary>
        public string Ac3 { get { return "ac3"; } }

        /// <summary>
        /// Audio Interchange File Format
        /// </summary>
        public string Aif { get { return "aif"; } }

        /// <summary>
        /// Compressed Audio Interchange File
        /// </summary>
        public string Aifc { get { return "aifc"; } }

        /// <summary>
        /// Audio Interchange File Format
        /// </summary>
        public string Aiff { get { return "aiff"; } }

        /// <summary>
        /// Adaptive Multi-Rate Codec File
        /// </summary>
        public string Amr { get { return "amr"; } }

        /// <summary>
        /// Core Audio Format
        /// </summary>
        public string Caf { get { return "caf"; } }

        /// <summary>
        /// Free Lossless Audio Codec
        /// </summary>
        public string Flac { get { return "flac"; } }

        /// <summary>
        /// MPEG-4 Audio Layer
        /// </summary>
        public string M4A { get { return "m4a"; } }

        /// <summary>
        /// MPEG-4 Audio Book
        /// </summary>
        public string M4B { get { return "m4b"; } }

        /// <summary>
        /// MPEG-1 Audio Layer 3
        /// </summary>
        public string Mp3 { get { return "mp3"; } }

        /// <summary>
        /// Ogg Vorbis Compressed Audio File
        /// </summary>
        public string Oga { get { return "oga"; } }

        /// <summary>
        /// Ogg Vorbis Compressed Audio File
        /// </summary>
        public string Ogg { get { return "ogg"; } }

        /// <summary>
        /// SoundFont
        /// </summary>
        public string Sf2 { get { return "sf2"; } }

        /// <summary>
        /// sfArk Compressed SoundFont
        /// </summary>
        public string Sfark { get { return "sfark"; } }

        /// <summary>
        /// Waveform audio format
        /// </summary>
        public string Wav { get { return "wav"; } }

        /// <summary>
        /// Windows Media Audio
        /// </summary>
        public string Wma { get { return "wma"; } }
    }

    /// <summary>
    /// This represents the cad format entity.
    /// </summary>
    public class Cad
    {
        /// <summary>
        /// AutoCAD Drawing
        /// </summary>
        public string Dwg { get { return "dwg"; } }

        /// <summary>
        /// AutoCAD Drawing Interchange Format
        /// </summary>
        public string Dxf { get { return "dxf"; } }
    }

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

    /// <summary>
    /// This represents the ebook format entity.
    /// </summary>
    public class Ebook
    {
        /// <summary>
        /// Amazon Kindle eBook File
        /// </summary>
        public string Azw { get { return "azw"; } }

        /// <summary>
        /// Amazon Kindle
        /// </summary>
        public string Azw3 { get { return "azw3"; } }

        /// <summary>
        /// Amazon Print Replica eBook
        /// </summary>
        public string Azw4 { get { return "azw4"; } }

        /// <summary>
        /// Comic Book Archive file
        /// </summary>
        public string Cbc { get { return "cbc"; } }

        /// <summary>
        /// Comic Book Archive file
        /// </summary>
        public string Cbr { get { return "cbr"; } }

        /// <summary>
        /// Comic Book Archive file
        /// </summary>
        public string Cbz { get { return "cbz"; } }

        /// <summary>
        /// Microsoft Compiled HTML Help
        /// </summary>
        public string Chm { get { return "chm"; } }

        /// <summary>
        /// Microsoft Office Open XML
        /// </summary>
        public string Docx { get { return "docx"; } }

        /// <summary>
        /// IDPF/EPUB
        /// </summary>
        public string Epub { get { return "epub"; } }

        /// <summary>
        /// FictionBook
        /// </summary>
        public string Fb2 { get { return "fb2"; } }

        /// <summary>
        /// HTML Document
        /// </summary>
        public string Htm { get { return "htm"; } }

        /// <summary>
        /// HTML Document
        /// </summary>
        public string Html { get { return "html"; } }

        /// <summary>
        /// Zipped HTML file
        /// </summary>
        public string Htmlz { get { return "htmlz"; } }

        /// <summary>
        /// Microsoft Reader
        /// </summary>
        public string Lit { get { return "lit"; } }

        /// <summary>
        /// Sony media
        /// </summary>
        public string Lrf { get { return "lrf"; } }

        /// <summary>
        /// Mobipocket eBook
        /// </summary>
        public string Mobi { get { return "mobi"; } }

        /// <summary>
        /// ODF Text Document
        /// </summary>
        public string Odt { get { return "odt"; } }

        /// <summary>
        /// Open eBook File
        /// </summary>
        public string Oeb { get { return "oeb"; } }

        /// <summary>
        /// Palm Media
        /// </summary>
        public string Pdb { get { return "pdb"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// Palm Markup Language
        /// </summary>
        public string Pml { get { return "pml"; } }

        /// <summary>
        /// Mobipocket
        /// </summary>
        public string Prc { get { return "prc"; } }

        /// <summary>
        /// Rocket eBook
        /// </summary>
        public string Rb { get { return "rb"; } }

        /// <summary>
        /// Rich Text Format
        /// </summary>
        public string Rtf { get { return "rtf"; } }

        /// <summary>
        /// Shanda Bambook
        /// </summary>
        public string Snb { get { return "snb"; } }

        /// <summary>
        /// Psion Series 3 eBook File
        /// </summary>
        public string Tcr { get { return "tcr"; } }

        /// <summary>
        /// Text
        /// </summary>
        public string Txt { get { return "txt"; } }

        /// <summary>
        /// TXTz
        /// </summary>
        public string Txtz { get { return "txtz"; } }
    }

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

    /// <summary>
    /// This represents the image format entity.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Hasselblad 3F RAW Image
        /// </summary>
        public string ThreeFr { get { return "3fr"; } }

        /// <summary>
        /// Sony Digital Camera Image
        /// </summary>
        public string Arw { get { return "arw"; } }

        /// <summary>
        /// Windows Bitmap
        /// </summary>
        public string Bmp { get { return "bmp"; } }

        /// <summary>
        /// Canon Raw Image File
        /// </summary>
        public string Cr2 { get { return "cr2"; } }

        /// <summary>
        /// Canon Raw CIFF Image File
        /// </summary>
        public string Crw { get { return "crw"; } }

        /// <summary>
        /// Kodak RAW Image File
        /// </summary>
        public string Dcr { get { return "dcr"; } }

        /// <summary>
        /// Digital Negative Image File
        /// </summary>
        public string Dng { get { return "dng"; } }

        /// <summary>
        /// Encapsulated PostScript
        /// </summary>
        public string Eps { get { return "eps"; } }

        /// <summary>
        /// Epson RAW File
        /// </summary>
        public string Erf { get { return "erf"; } }

        /// <summary>
        /// Graphics Interchange Format
        /// </summary>
        public string Gif { get { return "gif"; } }

        /// <summary>
        /// Apple Icon Image format
        /// </summary>
        public string Icns { get { return "icns"; } }

        /// <summary>
        /// Icon
        /// </summary>
        public string Ico { get { return "ico"; } }

        /// <summary>
        /// Joint Photographic Experts Group
        /// </summary>
        public string Jpeg { get { return "jpeg"; } }

        /// <summary>
        /// Joint Photographic Experts Group
        /// </summary>
        public string Jpg { get { return "jpg"; } }

        /// <summary>
        /// Leaf Camera RAW File
        /// </summary>
        public string Mos { get { return "mos"; } }

        /// <summary>
        /// Minolta Raw Image File
        /// </summary>
        public string Mrw { get { return "mrw"; } }

        /// <summary>
        /// Nikon Electronic Format RAW Image
        /// </summary>
        public string Nef { get { return "nef"; } }

        /// <summary>
        /// OpenDocument Drawing
        /// </summary>
        public string Odd { get { return "odd"; } }

        /// <summary>
        /// Olympus RAW File
        /// </summary>
        public string Orf { get { return "orf"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// Pentax Electronic File
        /// </summary>
        public string Pef { get { return "pef"; } }

        /// <summary>
        /// Portable Network Graphic
        /// </summary>
        public string Png { get { return "png"; } }

        /// <summary>
        /// Portable Pixmap Image File
        /// </summary>
        public string Ppm { get { return "ppm"; } }

        /// <summary>
        /// PostScript
        /// </summary>
        public string Ps { get { return "ps"; } }

        /// <summary>
        /// Adobe Photoshop bitmap
        /// </summary>
        public string Psd { get { return "psd"; } }

        /// <summary>
        /// Fuji RAW Image File
        /// </summary>
        public string Raf { get { return "raf"; } }

        /// <summary>
        /// Raw Image Data File
        /// </summary>
        public string Raw { get { return "raw"; } }

        /// <summary>
        /// Scalable Vector Graphics
        /// </summary>
        public string Svg { get { return "svg"; } }

        /// <summary>
        /// Tagged Image File Format
        /// </summary>
        public string Tif { get { return "tif"; } }

        /// <summary>
        /// Tagged Image File Format
        /// </summary>
        public string Tiff { get { return "tiff"; } }

        /// <summary>
        /// WebP
        /// </summary>
        public string Webp { get { return "webp"; } }

        /// <summary>
        /// SIGMA X3F Camera RAW File
        /// </summary>
        public string X3F { get { return "x3f"; } }

        /// <summary>
        /// eXperimental Computing Facility
        /// </summary>
        public string Xcf { get { return "xcf"; } }

        /// <summary>
        /// XML Paper Specification
        /// </summary>
        public string Xps { get { return "xps"; } }
    }

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

    /// <summary>
    /// This represents the vector format entity.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Adobe Illustrator File
        /// </summary>
        public string Ai { get { return "ai"; } }

        /// <summary>
        /// CorelDRAW Image File
        /// </summary>
        public string Cdr { get { return "cdr"; } }

        /// <summary>
        /// Computer Graphics Metafile
        /// </summary>
        public string Cgm { get { return "cgm"; } }

        /// <summary>
        /// Windows Enhanced Metafile
        /// </summary>
        public string Emf { get { return "emf"; } }

        /// <summary>
        /// Encapsulated PostScript
        /// </summary>
        public string Eps { get { return "eps"; } }

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public string Pdf { get { return "pdf"; } }

        /// <summary>
        /// PostScript
        /// </summary>
        public string Ps { get { return "ps"; } }

        /// <summary>
        /// Sketch/Skencil format
        /// </summary>
        public string Sk { get { return "sk"; } }

        /// <summary>
        /// sK1 format
        /// </summary>
        public string Sk1 { get { return "sk1"; } }

        /// <summary>
        /// Scalable Vector Graphics
        /// </summary>
        public string Svg { get { return "svg"; } }

        /// <summary>
        /// Visio Drawing File
        /// </summary>
        public string Vsd { get { return "vsd"; } }

        /// <summary>
        /// Windows Metafile
        /// </summary>
        public string Wmf { get { return "wmf"; } }
    }

    /// <summary>
    /// This represents the video format entity.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 3GPP2 file format
        /// </summary>
        public string ThreeG2 { get { return "3g2"; } }

        /// <summary>
        /// 3GP Multimedia File
        /// </summary>
        public string ThreeGp { get { return "3gp"; } }

        /// <summary>
        /// 3GP Multimedia File
        /// </summary>
        public string ThreeGpp { get { return "3gpp"; } }

        /// <summary>
        /// Audio Video Interleave
        /// </summary>
        public string Avi { get { return "avi"; } }

        /// <summary>
        /// CAVS
        /// </summary>
        public string Cavs { get { return "cavs"; } }

        /// <summary>
        /// Digital Video File
        /// </summary>
        public string Dv { get { return "dv"; } }

        /// <summary>
        /// Microsoft Digital Video Recording
        /// </summary>
        public string Dvr { get { return "dvr"; } }

        /// <summary>
        /// Flash Video
        /// </summary>
        public string Flv { get { return "flv"; } }

        /// <summary>
        /// Graphics Interchange Format
        /// </summary>
        public string Gif { get { return "gif"; } }

        /// <summary>
        /// Blu-ray BDAV Video File
        /// </summary>
        public string M2Ts { get { return "m2ts"; } }

        /// <summary>
        /// MPEG-4 Video File
        /// </summary>
        public string M4V { get { return "m4v"; } }

        /// <summary>
        /// Matroska file
        /// </summary>
        public string Mkv { get { return "mkv"; } }

        /// <summary>
        /// MOD
        /// </summary>
        public string Mod { get { return "mod"; } }

        /// <summary>
        /// Apple QuickTime Movie
        /// </summary>
        public string Mov { get { return "mov"; } }

        /// <summary>
        /// MPEG-4 Part 14
        /// </summary>
        public string Mp4 { get { return "mp4"; } }

        /// <summary>
        /// Moving Pictures Experts Group
        /// </summary>
        public string Mpeg { get { return "mpeg"; } }

        /// <summary>
        /// Moving Pictures Experts Group
        /// </summary>
        public string Mpg { get { return "mpg"; } }

        /// <summary>
        /// AVCHD Video File
        /// </summary>
        public string Mts { get { return "mts"; } }

        /// <summary>
        /// Material Exchange Format
        /// </summary>
        public string Mxf { get { return "mxf"; } }

        /// <summary>
        /// Ogg Vorbis Compressed Audio File
        /// </summary>
        public string Ogg { get { return "ogg"; } }

        /// <summary>
        /// RealMedia file
        /// </summary>
        public string Rm { get { return "rm"; } }

        /// <summary>
        /// RealMedia Variable Bitrate
        /// </summary>
        public string Rmvb { get { return "rmvb"; } }

        /// <summary>
        /// Macromedia Flash (SWF)
        /// </summary>
        public string Swf { get { return "swf"; } }

        /// <summary>
        /// Video Transport Stream File
        /// </summary>
        public string Ts { get { return "ts"; } }

        /// <summary>
        /// Video Object File
        /// </summary>
        public string Vob { get { return "vob"; } }

        /// <summary>
        /// WebM Video File
        /// </summary>
        public string Webm { get { return "webm"; } }

        /// <summary>
        /// Windows Media Video
        /// </summary>
        public string Wmv { get { return "wmv"; } }

        /// <summary>
        /// Windows Recorded TV Show
        /// </summary>
        public string Wtv { get { return "wtv"; } }
    }

    /// <summary>
    /// This represents the website format entity.
    /// </summary>
    public class Web
    {
        /// <summary>
        /// Website
        /// </summary>
        public string Website { get { return "website"; } }
    }
}