using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BGManager.Core.Utility
{
    public interface IXmlUtility
    {
        T DeserializeString<T>(string rawXml);
    }
    public class XmlUtility : IXmlUtility
    {
        public T DeserializeString<T>(string rawXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(rawXml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
