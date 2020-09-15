using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;

using Newtonsoft.Json;
using OpenQA.Selenium.Remote;


namespace NET_Challenge
{
    public class Requests
    {

        RestClient restClient;  
        public Requests(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public string DeleteRequest (string issueKey, string endpoint)
        {
            var request = new RestRequest(endpoint + issueKey);
            request.AddHeader("Content-Type", "application/json");
            String content = restClient.Delete(request).Content;
            return content;
        }

        public string PostRequest(String body, string endpoint)
        {
            var request = new RestRequest(endpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            String content = restClient.Post(request).Content;
            IssueCreateResponse jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<IssueCreateResponse>(content);
            return jsonObject.key;
        }


        public String getRequest(String key, string endpoint)
        {
            var request = new RestRequest(endpoint + key);
            request.AddHeader("Content-Type", "application/json");
            String content = restClient.Get(request).Content;
            ProjectCreateResponse.Root jsonObject = JsonConvert.DeserializeObject<ProjectCreateResponse.Root>(content);
            return jsonObject.key;
        }

        public Object PutRequest(String body, String project, String endpoint)
        {
            var request = new RestRequest(endpoint + project);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            String content = restClient.Put(request).Content;
            ProjectCreateResponse.Root jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectCreateResponse.Root>(content);
            return jsonObject.description;
        }

    }
}
