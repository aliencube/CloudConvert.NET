using Aliencube.CloudConvert.Wrapper.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.CloudConvert.Wrapper.Converters
{
    public class DownloadMethodConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DownloadMethod);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (DownloadMethod)value;

            switch (item)
            {
                case DownloadMethod.None:
                    writer.WriteUndefined();
                    break;
                case DownloadMethod.True:
                    writer.WriteValue(true);
                    break;
                case DownloadMethod.False:
                    writer.WriteValue(false);
                    break;
                default:
                    writer.WriteValue(item.ToString());
                    break;
            }

            writer.Flush();
        }
    }
}
