using JSONImporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestJSONImporter
{
    [TestClass]
    public class TestImporter
    {
        const string baseDirectory = "../../../TestFiles/";
        private Importer jsonImporter;

        [TestInitialize]
        public void CreateImporterInstance()
        {
            jsonImporter = new Importer();
        }

        [TestMethod]
        public void ImportOneBug()
        {
            string fullPath = baseDirectory + "OneBug.xml";
            List<Parameter> parameters = new List<Parameter>()
            {

            }
            List<ImportedBug> actualBugs = jsonImporter.Import(fullPath);

            List<Bug> expectedBugs = new List<Bug>()
            {
                new Bug(){
                Name = "Error en el envío de correo",
                Description = "El error se produce cuando el usuario no tiene un correo asignado",
                Version = "1.0",
                IsActive = true,
                CompletedBy = null,
                ProjectName = "Nombre del Proyecto"
                }
            };

            CollectionAssert.AreEqual(expectedBugs, actualBugs, new BugComparer());
        }
    }
}
