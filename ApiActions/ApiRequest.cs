﻿namespace SpecflowApiMayBatch.ApiActions
{
    public class ApiRequest
    {
        public RestClient client;

        public RestRequest request;

        public RestResponse response;

        private string baseUrl { get; set; } = "https://reqres.in/";
        private string baseUrl2 { get; set; } = "https://automationexercise.com/";
        public string GetAllUsersEndpoint = "api/users?page=2";
        public string GetSingleUserEndpoint = "api/users/2";
        public string GetSingleUserNotfoundEndpoint = "api/users/23";
        public string PostNewUserEndpoint = "api/users";
        public string UpdateSingleUserEndpoint = "api/users/2";
        public string GetProductList = "api/productsList";
        public string CreateNewUser = "api/createAccount";

        public async Task<RestResponse> SendRequest(
            string endPoint, 
            Method method = Method.Get)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, method);
            response = await client.ExecuteAsync(request);

            return response;
        }

        public ApiRequest GetRequest<T>(string flag,
            string endPoint, 
            Method method = Method.Get)
        {
            client = new RestClient(
                flag == "UserList" 
                ? baseUrl
                : flag == "ProductList"
                ? baseUrl2 : null!);
            request = new RestRequest(endPoint, method);
            response = client.Execute<T>(request);
            return this;
        }

        public ApiRequest PostRequest<T>(string flag,
            string endPoint,
            object payload,
            Dictionary<string, string> param = null,
            Method method = Method.Post)
        {
            client = new RestClient(flag == "CreatUserReqres"
                ? baseUrl
                : flag == "CreateNewUserAutomationExcercise"
                ? baseUrl2 : null!);
            request = new RestRequest(endPoint, method);
            if (payload != null)
            {
                request.AddBody(payload);
            }

            if (param != null)
            {
                foreach (var key in param)
                {
                    request.AddParameter(key.Key, key.Value);
                }
            }
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
