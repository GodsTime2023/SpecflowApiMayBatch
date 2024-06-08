namespace SpecflowApiMayBatch.StepDefinitions
{
    [Binding]
    public sealed class GetAllUsersSteps : ApiRequest
    {
        string getAllUsersEndPoint;
        AllUsersResponseModel actual;

        [Given(@"I have a resource")]
        public void GivenIAmAResource()
        {
            getAllUsersEndPoint = GetAllUsersEndpoint;
        }

        [When(@"I request all users info")]
        public void WhenIRequestAllUsersInfo()
        {
            string flag = "UserList";
            var response = GetRequest<AllUsersResponseModel>(flag,
                getAllUsersEndPoint, RestSharp.Method.Get);
            actual = response.DeserializeData<AllUsersResponseModel>();
        }

        [Then(@"The response code to retrieve all users is (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponse)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedResponse));
        }

        [Then(@"the response body includes the following:")]
        public void ThenTheResponseBodyIncludesTheFollowing(IEnumerable<TableModel> expected)
        {
            Assert.That(actual?.page, Is.EqualTo(expected.First().page));
            Assert.That(actual?.per_page, Is.EqualTo(expected.First().per_page));
            Assert.That(actual?.total, Is.EqualTo(expected.First().total));
            Assert.That(actual?.total_pages, Is.EqualTo(expected.First().total_pages));

            //0
            Assert.That(actual?.data[0].id, Is.EqualTo(expected.First().id));
            Assert.That(actual?.data[0].first_name, Is.EqualTo(expected.First().first_name));
            Assert.That(actual?.data[0].last_name, Is.EqualTo(expected.First().last_name));
            Assert.That(actual?.data[0].email, Is.EqualTo(expected.First().email));
            Assert.That(actual?.data[0].avatar, Is.EqualTo(expected.First().avatar));

            //1
            Assert.That(actual?.data[1].id, Is.EqualTo(expected.Last().id));
            Assert.That(actual?.data[1].first_name, Is.EqualTo(expected.Last().first_name));
            Assert.That(actual?.data[1].last_name, Is.EqualTo(expected.Last().last_name));
            Assert.That(actual?.data[1].email, Is.EqualTo(expected.Last().email));
            Assert.That(actual?.data[1].avatar, Is.EqualTo(expected.Last().avatar));
        }
    }
}
