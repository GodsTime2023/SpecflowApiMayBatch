namespace SpecflowApiMayBatch.StepDefinitions
{
    [Binding]
    public class CreateNewUsersStepDefinitions : ApiRequest
    {
        string creatUserEndpoint;
        CreatNewResponseUserModel actualUserResponse;

        [Given(@"I have a create new user enpoint")]
        public void GivenIHaveACreateNewUserEnpoint()
        {
            creatUserEndpoint = PostNewUserEndpoint;
        }

        [When(@"I request to create a new user with the following body:")]
        public void WhenIRequestToCreateANewUserWithTheFollowingBody(CreatNewRequestUserTableModel body)
        {
            var payload = new
            {
                name = body.name,
                job = body.job,
            };

            var response = PostRequest<CreatNewResponseUserModel>(creatUserEndpoint, payload);
            actualUserResponse = response.DeserializeData<CreatNewResponseUserModel>();
        }

        [Then(@"The response code for newly created user is (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponse)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedResponse));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Then(@"the response body includes the following")]
        public void ThenTheResponseBodyIncludesTheFollowing(CreatNewRequestUserTableModel expectedResponse)
        {
            Assert.That(expectedResponse.name, Is.EqualTo(actualUserResponse.name));
            Assert.That(expectedResponse.job, Is.EqualTo(actualUserResponse.job));
            Assert.That(actualUserResponse.id != null);
            Assert.That(actualUserResponse.createdAt != null);
        }
    }
}
