
using Newtonsoft.Json;
using System.Windows.Input;


namespace NET_Challenge
{
    public class CreateIssueBuilder
    {
        private string _summary = "Issue created from API";
        private string _description = "Created from the automation solution";
        private string _key = "CN";
        private string _name = "Epic";


        public string Build()
        {
            var project = new Project
            {
                key = _key
            };

            var issueType = new Issuetype
            {
                name = _name
            };

            IssueCreation body = new IssueCreation
            {

                fields = new FieldsIssues
                {
                    project = project,
                    summary = _summary,
                    description = _description,
                    issuetype = issueType,
                }
                
            };
            string json = JsonConvert.SerializeObject(body);
            return json;
        }

        public CreateIssueBuilder WithIssueType(string issueType)
        {
            _name = issueType;
            return this;
        }

        public CreateIssueBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        public CreateIssueBuilder WithSummary(string summary)
        {
            _summary = summary;
            return this;
        }
        public CreateIssueBuilder WithKey(string key)
        {
            _key = key;
            return this;
        }

    }
}
