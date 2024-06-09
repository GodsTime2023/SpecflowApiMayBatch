namespace SpecflowApiMayBatch.StepDefinitions
{
    [Binding]
    public class CreateNewUsersStepDefinitions : ApiRequest
    {
        string creatUserEndpoint;
        CreatNewResponseUserModel actualUserResponse;

        [Given(@"I have a ""(Create new|Update)"" user enpoint")]
        public void GivenIHaveACreateNewUserEnpoint(string endpoint)
        {
            if (endpoint == "Create new")
            {
                creatUserEndpoint = PostNewUserEndpoint;
            }
            else if (endpoint == "Update")
            {
                creatUserEndpoint = UpdateSingleUserEndpoint;
            }
        }

        [When(@"I request to ""(Create|Update|Delete|Patch)"" a new user with the following body:")]
        public void WhenIRequestToCreateANewUserWithTheFollowingBody(string method,CreatNewRequestUserTableModel body)
        {
            string flag = "CreatUserReqres";
            ApiRequest response = null;
            if (method == "Create")
            {
                response = PostRequest<CreatNewResponseUserModel>(
                   flag, creatUserEndpoint!,
                new { body.name, body.job }, null, Method.Post);
            }
            else if (method == "Update")
            {
                response = PostRequest<CreatNewResponseUserModel>(
                    flag, creatUserEndpoint!,
                new { body.name, body.job }, null, Method.Put);
            }
            
            actualUserResponse = response.DeserializeData<CreatNewResponseUserModel>();
        }

        [Then(@"The response code for newly created user is (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponse)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedResponse));
        }

        [Then(@"the response body includes the following")]
        public void ThenTheResponseBodyIncludesTheFollowing(CreatNewRequestUserTableModel expectedResponse)
        {
            Assert.That(expectedResponse.name, Is.EqualTo(actualUserResponse.name));
            Assert.That(expectedResponse.job, Is.EqualTo(actualUserResponse.job));
            //Assert.That(actualUserResponse.id != null);
            Assert.That(!actualUserResponse.createdAt.Equals(null));
        }
    }
}
