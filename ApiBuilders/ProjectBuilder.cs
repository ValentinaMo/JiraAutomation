
using Newtonsoft.Json;

namespace NET_Challenge
{
    class CreateProjectBuilder
    {
        private string _key = "TES";
        private string _name = "TestProject";
        private string _projectTypeKey = "business";
        private string _lead = "valentinal0929";
        private string _description = "this is a default description";

        public CreateProjectBuilder SetKey(string key)
        {
            _key = key;
            return this;
        }
        public CreateProjectBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        public CreateProjectBuilder SetProjectTypeKey(string projectTypeKey)
        {
            _projectTypeKey = projectTypeKey;
            return this;
        }
        public CreateProjectBuilder SetLead(string lead)
        {
            _lead = lead;
            return this;
        }
        public CreateProjectBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public string Build()
        { 
            ProjectCreation fields = new ProjectCreation
            {
                key = _key,
                name = _name,
                projectTypeKey = _projectTypeKey,
                lead = _lead,
                description = _description
            };
            string json = JsonConvert.SerializeObject(fields);
            return json;
        }

    }
}

