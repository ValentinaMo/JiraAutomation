using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using System;


namespace NET_Challenge
{
    [TestFixture]
    public class APITests
    {
        private readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string ConfigUsername = ConfigurationManager.AppSettings["Username"];
        private readonly string ConfigPassword = ConfigurationManager.AppSettings["Password"];
        private readonly string IssueEndpoint = ConfigurationManager.AppSettings["IssueEndpoint"];
        private readonly string ProjectEndpoint = ConfigurationManager.AppSettings["ProjectEndpoint"];

        RestClient restClient;

        [SetUp]
        public void SetUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
        }

        [Test]
        public void ANewEpicIsCreatedUsingTheAPI()
        {
            var createIssue = new CreateIssueBuilder().
                WithIssueType("Story").
                WithDescription("This is an example story  with description").
                WithSummary("Creating a story with API");
            Console.WriteLine(""+createIssue.Build());
            var issue = new Requests(restClient);
            String key = issue.PostRequest(createIssue.Build(), IssueEndpoint);
            Assert.AreEqual(key, issue.getRequest(key, IssueEndpoint));
        }

        [Test]
        public void deleteAnIssue()
        {
            var issue = new Requests(restClient);
            Assert.AreEqual(issue.DeleteRequest("CN-36", IssueEndpoint), String.Empty);
        }

        [Test]
        public void newProjectIsCreatedUsingAPI()
        {
            var createProject = new CreateProjectBuilder().
                SetKey("NET").
                SetName("NET");
            var project = new Requests(restClient);
            String key = project.PostRequest(createProject.Build(), ProjectEndpoint);
            Assert.AreEqual(key, project.getRequest(key, ProjectEndpoint));
        }

        [Test]
        public void getProjectUsingApi()
        {
            var project = new Requests(restClient);
            Assert.AreEqual("CN", project.getRequest("CN", ProjectEndpoint));
        }

        [Test]
        public void deleteProjectUsingApi()
        {
            var project = new Requests(restClient);
            Assert.AreEqual(project.DeleteRequest("NET", ProjectEndpoint), String.Empty);
        }

        [Test]
        public void updateProjectUsingApi()
        {
            var createProject = new CreateProjectBuilder().
                SetKey("BUS").
                SetName("Bussines").
                SetDescription("this is an update to the project");
            var project = new Requests(restClient);
            Assert.AreEqual("this is an update to the project", project.PutRequest(createProject.Build(), "BUS", ProjectEndpoint));

        }

        [Test]
        public void getAnIssueUssingApi()
        {
            var issue = new Requests(restClient);
            Assert.AreEqual("CN-26", issue.getRequest("CN-31", IssueEndpoint));
        }
    }
}


