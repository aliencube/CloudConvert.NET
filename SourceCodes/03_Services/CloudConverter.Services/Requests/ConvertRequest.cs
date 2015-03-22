using System.Collections.Generic;

namespace Aliencube.CloudConverter.Services.Requests
{
    /// <summary>
    /// This represents the convert request entity.
    /// </summary>
    public class ConvertRequest : BaseRequest
    {
        public string Input { get; set; }

        public string File { get; set; }

        public string Filename { get; set; }

        public object Tag { get; set; }

        public string OutputFormat { get; set; }

        public Dictionary<string, object> ConverterOptions { get; set; }

        public string Preset { get; set; }

        public int Timeout { get; set; }

        public bool Email { get; set; }

        public string Output { get; set; }

        public string Callback { get; set; }

        public bool Wait { get; set; }

        public string Download { get; set; }

        public bool Save { get; set; }
    }
}