using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace CSharkLibrary
{
    public static class ConfigSettings
    {
        private static string fileName = "config.xml";

        private static bool DoesFileExist()
        {
            string path = System.Environment.CurrentDirectory;
            return File.Exists(path + Path.DirectorySeparatorChar + fileName);
        }

        public static string InitFile()
        {
            if (!DoesFileExist())
            {
                try
                {
                    XmlWriter xmlWriter = XmlWriter.Create(fileName);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("user");
                    xmlWriter.WriteStartElement("username");
                    xmlWriter.WriteString("Anonymous"); // default name
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return ReadElement("username");
        }

        public static string ReadElement(string ElementName)
        {
            if (!DoesFileExist())
                return "Error";

            string elementValue = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);

                XmlNode elementNode = xmlDocument.GetElementsByTagName(ElementName)[0];
                elementValue = elementNode.InnerText;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return elementValue;
        }

        public static void EditElement(string ElementName, string ElementValue)
        {
            if (!DoesFileExist())
                return;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);

                XmlNode elementNode = xmlDocument.GetElementsByTagName(ElementName)[0];
                elementNode.InnerText = ElementValue;

                xmlDocument.Save(fileName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
