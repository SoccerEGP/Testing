using RestSharp;
using System.Collections.Generic;

namespace CSharpTestFramework.WebService
{
    class RestHandler
    {
        private static RestClient client;

        public RestHandler(string endpoint)
        {
            client = new RestClient(endpoint);
        }

        public IRestResponse Get(string URI, Dictionary<string, string> headers)
        {
            var request = new RestRequest(URI, Method.GET);
            request = AddHeaders(request, headers);
            return client.Execute(request);
        }

        public IRestResponse Post(string URI, Dictionary<string, string> headers, JsonObject payload)
        {
            var request = new RestRequest(URI, Method.POST);
            request = AddHeaders(request, headers);
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return client.Execute(request);
        }

        public IRestResponse Put(string URI, Dictionary<string, string> headers, JsonObject payload)
        {
            var request = new RestRequest(URI, Method.PUT);
            request = AddHeaders(request, headers);
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return client.Execute(request);
        }

        public IRestResponse Delete(string URI, Dictionary<string, string> headers)
        {
            var request = new RestRequest(URI, Method.DELETE);
            request = AddHeaders(request, headers);
            return client.Execute(request);
        }

        private RestRequest AddHeaders(RestRequest request, Dictionary<string, string> headers)
        {
            foreach(KeyValuePair<string, string> entry in headers)
            {
                request.AddHeader(entry.Key, entry.Value);
            }
            return request;
        }
    }
}
