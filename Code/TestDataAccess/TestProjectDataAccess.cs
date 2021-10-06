using BusinessLogic;
using Domain;
using Domain.Utils;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace TestDataAccess
{
    [TestClass]
    public class TestProjectDataAccess
    {

        private readonly DbConnection connection;
        private readonly ProjectDataAccess projectDataAccess;
        private readonly BugManagerContext bugManagerContext;
        private readonly DbContextOptions<BugManagerContext> contextOptions;

        public TestProjectDataAccess()
        {
            connection = new SqliteConnection("Filename=:memory:");
            contextOptions = new DbContextOptionsBuilder<BugManagerContext>().UseSqlite(connection).Options;
            bugManagerContext = new BugManagerContext(contextOptions);
            projectDataAccess = new ProjectDataAccess(bugManagerContext);
        }

        [TestInitialize]
        public void Setup()
        {
            connection.Open();
            bugManagerContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            bugManagerContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAll()
        {
            var projectsExpected = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "a",
                    Testers = new List<Tester>(),
                    Developers = new List<Developer>(),
                    Bugs = new List<Bug>()
                }
             };
            bugManagerContext.Add(new Project
            {
                Id = 1,
                Name = "a",
                Testers = new List<Tester>(),
                Developers = new List<Developer>(),
                Bugs = new List<Bug>()
            }); ;
            bugManagerContext.SaveChanges();
            List<Project> projectDataBase = projectDataAccess.GetAll().ToList();

            Assert.AreEqual(1, projectDataBase.Count);
            CollectionAssert.AreEqual(projectsExpected, projectDataBase, new ProjectComparer());
        }

        [TestMethod]
        public void Update()
        {
            Project project = projectDataAccess.Create(new Project
            {
                Id = 1,
                Name = "b"
            });

            var projectUpdated = new Project
            {
                Id = 1,
                Name = "a"
            };

            projectDataAccess.Update(project.Id, projectUpdated);
            bugManagerContext.SaveChanges();

            var projectSaved = projectDataAccess.GetById(1);

            Assert.AreEqual(0, new ProjectComparer().Compare(projectUpdated, projectSaved));

        }

        [TestMethod]
        public void Create()
        {
            Project expectedProject = new Project()
            {
                Id = 1,
                Name = "project1",

            };

            projectDataAccess.Create(new Project()
            {
                Id = 1,
                Name = "project1"
            });
            bugManagerContext.SaveChanges();

            var projectSaved = projectDataAccess.GetById(1);
            Assert.AreEqual(0, new ProjectComparer().Compare(expectedProject, projectSaved));

        }

        [TestMethod]
        public void Delete()
        {
            Project notExpectedProject = new Project()
            {
                Id = 1,
                Name = "NotAProject"
            };
            projectDataAccess.Create(notExpectedProject);
            projectDataAccess.Delete(notExpectedProject.Id);
            bugManagerContext.SaveChanges();

            var projectsSaved = projectDataAccess.GetAll().ToList();

            CollectionAssert.DoesNotContain(projectsSaved, notExpectedProject);

        }

        [TestMethod]
        public void GetAllBugs()
        {
            Project project = new Project()
            {
                Id = 1,
                Name = "project1"
            };
            var bugsExpected = new List<Bug>
            {
                new Bug
                {
                    Id = 1,
                    Name = "a",
                    Description = "a",
                    Version = "1.0",
                    IsActive = true,
                     Project = project
                    }
                };
            bugManagerContext.Add(new Bug
            {
                Id = 1,
                Name = "a",
                Description = "a",
                Version = "1.0",
                IsActive = true,
                Project = project
            });
            bugManagerContext.SaveChanges();
            List<Bug> bugsFromDb = projectDataAccess.GetBugs(1).ToList();

            Assert.AreEqual(1, bugsFromDb.Count);
            CollectionAssert.AreEqual(bugsExpected, bugsFromDb, new BugComparer());
        }

        [TestMethod]
        public void GetBugsQuantity()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
                Bugs = new List<Bug>()
                {
                    new Bug() {
                        Name = "Not working button",
                        Description = "Upload button not working",
                        Version = "1",
                        IsActive = true,
                        CompletedBy = null,
                    },
                    new Bug() {
                        Name = "Not working button",
                        Description = "Upload button not working",
                        Version = "1",
                        IsActive = true,
                        CompletedBy = null,
                    }
                }
              };
            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();

            int cantExpected = project.Bugs.Count();
            Assert.AreEqual(cantExpected, projectDataAccess.GetBugsQuantity(project.Id).quantity);

        }

        [TestMethod]
        public void GetAllDevelopers()
        {
            var devsExpected = new List<Developer>
            {
                new Developer()
                {
                    Username = "aguspink",
                },
                new Developer()
                {
                    Username = "ivo",
                }
            };

            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
                Developers = devsExpected
            };
            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();
            List<Developer> devsFromDb = projectDataAccess.GetDevelopers(project.Id).ToList();

            Assert.AreEqual(2, devsFromDb.Count);
            CollectionAssert.AreEqual(devsExpected, devsFromDb, new UserComparer());
        }

        [TestMethod]
        public void GetAllTesters()
        {
            var testersExpected = new List<Tester>
            {
                new Tester()
                {
                    Username = "aguspink",
                },
                new Tester()
                {
                    Username = "ivo",
                }
            };

            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
                Testers = testersExpected
            };
            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();
            List<Tester> testersFromDb = projectDataAccess.GetTesters(project.Id).ToList();

            Assert.AreEqual(2, testersFromDb.Count);
            CollectionAssert.AreEqual(testersExpected, testersFromDb, new UserComparer());
        }


        [TestMethod]
        public void AddDeveloperNotFoundToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();

            int nonexistentDevId = 4;
            Assert.ThrowsException<NonexistentUserException>(() => projectDataAccess.AddDeveloperToProject(project.Id, nonexistentDevId));

        }

        [TestMethod]
        public void AddDeveloperToProjectNotFound()
        {
            Developer devExpected = new Developer()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            bugManagerContext.Developer.Add(devExpected);
            bugManagerContext.SaveChanges();
            int nonexistentProjectId = 4;
            Assert.ThrowsException<NonexistentProjectException>(() => projectDataAccess.AddDeveloperToProject(nonexistentProjectId, devExpected.Id));

        }

        [TestMethod]
        public void AddDeveloperToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            Developer devExpected = new Developer()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };


            projectDataAccess.Create(project);
            bugManagerContext.Developer.Add(devExpected);
            bugManagerContext.SaveChanges();

            Developer devResult = projectDataAccess.AddDeveloperToProject(project.Id, devExpected.Id);

            Assert.AreEqual(devExpected, devResult);
        }

        [TestMethod]
        public void AddTesterNotFoundToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();

            int nonexistentTesterId = 4;
            Assert.ThrowsException<NonexistentUserException>(() => projectDataAccess.AddTesterToProject(project.Id, nonexistentTesterId));

        }

        [TestMethod]
        public void AddTesterToProjectNotFound()
        {
            Tester testerExpected = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            bugManagerContext.Tester.Add(testerExpected);
            bugManagerContext.SaveChanges();
            int nonexistentProjectId = 4;
            Assert.ThrowsException<NonexistentProjectException>(() => projectDataAccess.AddDeveloperToProject(nonexistentProjectId, testerExpected.Id));

        }

        [TestMethod]
        public void AddTesterToProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            Tester testerExpected = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };


            projectDataAccess.Create(project);
            bugManagerContext.Tester.Add(testerExpected);
            bugManagerContext.SaveChanges();

            Tester testerResult = projectDataAccess.AddTesterToProject(project.Id, testerExpected.Id);

            Assert.AreEqual(testerExpected, testerResult);
        }

        [TestMethod]
        public void DeleteDeveloperNotFoundFromProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();

            int nonexistentDevId = 4;
            Assert.ThrowsException<NonexistentUserException>(() => projectDataAccess.RemoveDeveloperFromProject(project.Id, nonexistentDevId));

        }

        [TestMethod]
        public void DeleteDeveloperFromProjectNotFound()
        {
            Developer devExpected = new Developer()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            bugManagerContext.Developer.Add(devExpected);
            bugManagerContext.SaveChanges();
            int nonexistentProjectId = 4;
            Assert.ThrowsException<NonexistentProjectException>(() => projectDataAccess.RemoveDeveloperFromProject(nonexistentProjectId, devExpected.Id));

        }
        [TestMethod]
        public void DeleteDeveloperFromProject()
        {
            
                Project project = new Project()
                {
                    Name = "project3",
                    Id = 1,
                };

                Developer devExpected = new Developer()
                {
                    Id = 2,
                    Name = "Agustina",
                    Lastname = "didios",
                    Username = "Agus",
                    Password = "rosadopastel",
                    Email = "hell@yahoo.com"
                };


                projectDataAccess.Create(project);
                bugManagerContext.Developer.Add(devExpected);
                bugManagerContext.SaveChanges();

                ResponseMessage result = projectDataAccess.RemoveDeveloperFromProject(project.Id, devExpected.Id);

                Assert.IsTrue(result is ResponseMessage);
         }


        [TestMethod]
        public void DeleteTesterNotFoundFromProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            projectDataAccess.Create(project);
            bugManagerContext.SaveChanges();

            int nonexistentTesterId = 4;
            Assert.ThrowsException<NonexistentUserException>(() => projectDataAccess.RemoveTesterFromProject(project.Id, nonexistentTesterId));

        }

        [TestMethod]
        public void DeleteTesterFromProjectNotFound()
        {
            Tester testerExpected = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };
            bugManagerContext.Tester.Add(testerExpected);
            bugManagerContext.SaveChanges();
            int nonexistentProjectId = 4;
            Assert.ThrowsException<NonexistentProjectException>(() => projectDataAccess.RemoveDeveloperFromProject(nonexistentProjectId, testerExpected.Id));

        }

        [TestMethod]
        public void DeleteTesterFromProject()
        {
            Project project = new Project()
            {
                Name = "project3",
                Id = 1,
            };

            Tester testerExpected = new Tester()
            {
                Id = 2,
                Name = "Agustina",
                Lastname = "didios",
                Username = "Agus",
                Password = "rosadopastel",
                Email = "hell@yahoo.com"
            };


            projectDataAccess.Create(project);
            bugManagerContext.Tester.Add(testerExpected);
            bugManagerContext.SaveChanges();

            ResponseMessage result = projectDataAccess.RemoveTesterFromProject(project.Id, testerExpected.Id);

            Assert.IsTrue(result is ResponseMessage);
        }

    }
}
