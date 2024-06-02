﻿namespace SpecflowApiMayBatch.ApiActions
{
    public class ApiRequest
    {
        public RestClient client;

        public RestRequest request;

        public RestResponse response;

        private string baseUrl { get; set; } = "https://reqres.in/";
        public string GetAllUsersEndpoint = "api/users?page=2";
        public string GetSingleUserEndpoint = "api/users/2";
        public string GetSingleUserNotfoundEndpoint = "api/users/23";
        public string PostNewUserEndpoint = "api/users";
        public string UpdateSingleUserEndpoint = "api/users/2";

        public async Task<RestResponse> SendRequest(
            string endPoint, 
            Method method = Method.Get)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            response = await client.ExecuteAsync(request);

            return response;
        }

        public ApiRequest GetRequest<T>(
            string endPoint, 
            Method method = Method.Get)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            response = client.Execute<T>(request);
            return this;
        }

        public ApiRequest PostRequest<T>(
            string endPoint,
            object payload,
            Method method = Method.Post)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            request.AddBody(payload);
            response = client.Execute<T>(request);
            return this;
        }

        public ApiRequest PostRequestWithBearerToken<T>(
            string endPoint,
            object payload,
            string token,
            Method method = Method.Post)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            request.AddBody(payload);
            request.AddHeader("Authorization", $"Bearer {token}");
            response = client.Execute<T>(request);
            return this;
        }

        public ApiRequest PostRequestWithBasicToken<T>(
            string endPoint,
            object payload,
            string username,
            string password,
            Method method = Method.Post)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            request.AddBody(payload);
            var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
            request.AddHeader("Authorization", $"Basic {token}");
            response = client.Execute<T>(request);
            return this;
        }

        public T DeserializeData<T>()
        {
            var data = client.Execute<T>(request).Data;
            return data;
        }
    }
}
