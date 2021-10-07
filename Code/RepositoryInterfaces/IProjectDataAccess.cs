using BusinessLogicInterfaces;
using Domain;
using System.Collections.Generic;

namespace RepositoryInterfaces
{
    public interface IProjectDataAccess
    {
        public Project Create(Project project);
        public Project GetById(int id);
        public Project GetByName(string name);

        public IEnumerable<Project> GetAll();

        public Project Update(int id, Project projectUpdated);

        public Project UpdateByName(string name, Project projectUpdated);

        public ResponseMessage Delete(int id); // TODO sacar response message

        public ResponseMessage DeleteByName(string name);
        List<Bug> GetBugs(int id);

        public BugsQuantity GetBugsQuantity(int idProject);
        List<Developer> GetDevelopers(int id);
        List<Tester> GetTesters(int id);
    }
}