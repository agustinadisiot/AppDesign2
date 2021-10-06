using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BugParser
{

    [Serializable]
    [XmlRoot("Empresa1")]
    public class BugModel
    {
        [XmlElement("Proyecto")]
        public string Proyecto { get; set; }
        [XmlElement("Bugs")]
        public BugsXML BugList { get; set; } // TODO cambiar xml a algo que no se acople a un formato de achivo

        internal List<Bug> ConvertToBugs()
        {
            List<Bug> bugs = new List<Bug>();

            if (BugList.Bugs != null)
            {
                foreach (BugXML bugXML in BugList.Bugs)
                {
                    Bug convertedBug = new Bug
                    {
                        Name = bugXML.Nombre.Trim(),
                        Description = bugXML.Descripcion.Trim(),
                        ProjectName = this.Proyecto.Trim(),
                        Version = bugXML.Version.Trim(),
                        IsActive = bugXML.Estado.Trim() == "Activo",
                    };
                    bugs.Add(convertedBug);
                    // bug.Validate TODO 
                }
            }
            return bugs;
        }

    }

    public class BugsXML
    {
        [XmlElement("Bug")]
        public BugXML[] Bugs { get; set; }

    }

    public class BugXML
    {
        [XmlElement("Id")]
        public string Id { get; set; }
        [XmlElement("Nombre")]
        public string Nombre { get; set; }
        [XmlElement("Descripcion")]
        public string Descripcion { get; set; }
        [XmlElement("Version")]
        public string Version { get; set; }
        [XmlElement("Estado")]
        public string Estado { get; set; }
    }



}
