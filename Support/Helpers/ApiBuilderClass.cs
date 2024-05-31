namespace SpecflowApiMayBatch.Support.Helpers
{
    public class ApiBuilderClass
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        private readonly string baseUrl = "";


        public RestClient SetUrl()
        {
            var url = Path.Combine(baseUrl);
            _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest GetRequest(string endPoint, Method method)
        {
            _restRequest = new RestRequest(endPoint, method);
            _restRequest.AddHeader("Accept", "Application/json");
            return _restRequest;
        }

        public RestRequest DeleteRequest(string endPoint)
        {
            _restRequest = new RestRequest(endPoint, Method.Delete);
            _restRequest.AddHeader("Accept", "Application/json");
            return _restRequest;
        }

        //public RestRequest PostRequest<T>(T payload, string endPoint, string apiValue)
        //{
        //    _restRequest = new RestRequest(endPoint, Method.Post);
        //    _restRequest.AddHeader("Accept", "Application/json");
        //    _restRequest.AddHeader("X-Api-Key", apiValue);
        //    _restRequest.AddParameter("application/json",
        //        _restRequest.AddJsonBody(payload), ParameterType.RequestBody);
        //    return _restRequest;
        //}

        //public RestRequest PutRequest<T>(T payload)
        //{
        //    _restRequest = new RestRequest(Method.Put);
        //    _restRequest.AddHeader("Accept", "Application/json");
        //    _restRequest.AddParameter("application/json",
        //        _restRequest.AddJsonBody(payload), ParameterType.RequestBody);
        //    return _restRequest;
        //}

        //public RestRequest PatchRequest<T>(T payload, string apiValue)
        //{
        //    _restRequest = new RestRequest(Method.PATCH);
        //    _restRequest.AddHeader("Accept", "Application/json");
        //    _restRequest.AddHeader("X-Api-Key", apiValue);
        //    _restRequest.AddParameter("application/json",
        //        _restRequest.AddJsonBody(payload), ParameterType.RequestBody);
        //    return _restRequest;
        //}

        //public IRestResponse GetResponse(RestClient client, RestRequest request)
        //{
        //    return client.Execute(request);
        //}
        //public DTO GetContent<DTO>(IRestResponse response)
        //{
        //    var content = response.Content;
        //    DTO contentObject = JsonConvert.DeserializeObject<DTO>(content);
        //    return contentObject;
        //}

        //public string Serialise(dynamic content)
        //{
        //    string serialiseObject = JsonConvert.SerializeObject(content, Formatting.Indented);
        //    return serialiseObject;
        //}
    }
}
