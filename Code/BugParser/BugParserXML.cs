using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BugParser
{
    public class BugParserXML // TODO implementar interfaz
    {
        public static List<Bug> GetBugs(string fullPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BugModel));
            FileStream fs = new FileStream(fullPath, FileMode.Open);
            BugModel completeImportedData;
            try
            {
                completeImportedData = (BugModel)serializer.Deserialize(fs);
            }
            catch (InvalidOperationException e)
            {
                throw new XmlException(e.Message);
            }
            List<Bug> importedBugs;
            try
            {
                importedBugs = completeImportedData.ConvertToBugs();
            }
            catch (NullReferenceException e)
            {
                throw new XmlException(e.Message);
            }
            return importedBugs;

        }

    }

    /*  XmlDocument xdoc = new XmlDocument();
    xdoc.Load(File.OpenRead(fullPath));
            var algo = xdoc.DocumentElement.FirstChild;
    XmlSerializer serializer = new XmlSerializer(typeof(BugModel));
    // FileStream fs = new FileStream(fullPath, FileMode.Open);
    BugModel completeImportedData = (BugModel)serializer.Deserialize(new XmlNodeReader(algo));*/
}
