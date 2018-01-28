using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quotation.Infrastructure.Utilities
{
    public static class XmlParser
    {
        public static T ConvertFromXml<T>(string xml)
        {
            object result = null;
            var serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(xml))
            {
                result = serializer.Deserialize(reader);
            }
            return (T)result;
        }

        public static void ConvertToXml<T>(T instance, string filename)
        {
            using (var filestream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(filestream, instance);
            }
        }
    }
}
