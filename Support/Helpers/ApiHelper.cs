using APIUnitTestMayBatch.Modules;
using RestSharp;
using System.Net;

namespace SpecflowApiMayBatch.Support.Helpers
{
    public class ApiHelper
    {
        public RestClient Client { get; set; }

        public RestRequest Request { get; set; }

        public string ContentType { get; set; }

        public string baseUrl = "https://reqres.in/";

        private string Endpoint => "api/users?page=1";

        public HttpStatusCode StatusCode { get; set; }

        public AllUsersResponseModel allUsersResponseModel { get; set; }


        public async Task<(T, HttpStatusCode)> SendRequest<T>(string resource,
            Method method,
            object payload = null,
            Dictionary<string, string> header = null,
            Dictionary<string, string> param = null)
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri(resource),
            };
            Client = new RestClient(options);
            Request = new RestRequest(Endpoint,
                method);

            if (payload != null)
            {
                Request.AddBody(payload, ContentType);
            }

            if (header != null)
            {
                header?.ToList()
                    .ForEach(kvp =>
                    Request.AddHeader(kvp.Key, kvp.Value));
            }

            if (param != null)
            {
                param?.ToList()
                    .ForEach(kvp =>
                    Request.AddHeader(kvp.Key, kvp.Value));
            }

            var Response = await Client.ExecuteAsync<T>(Request);
            StatusCode = Response.StatusCode;
            return (Response.Data!, StatusCode);
        }
    }
}
