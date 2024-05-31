using APIUnitTestMayBatch.Modules;
using NUnit.Framework;
using SpecflowApiMayBatch.ApiActions;

namespace APIUnitTestMayBatch.TestModule
{
    public class ApiPostRequest : ApiRequest
    {
        [Test]
        public void CreateNewUser()
        {
            //Model type example
            //var payload = new PostNewRequestUser
            //{
            //    name = "morpheus",
            //    job = "leader"
            //};

            //var response = 
            //    PostRequest<PostResponseModel>(PostNewUserEndpoint,
            //    payload,
            //    RestSharp.Method.Post)
            //    .DeserializeData<PostResponseModel>();
            //-------------------------------------------------------

            //Anonymouse type
            //var payload = new
            //{
            //    name = "morpheus",
            //    job = "leader"
            //};

            var response =
                PostRequest<PostResponseModel>(PostNewUserEndpoint,
                new { name = "morpheus", job = "leader" },
                RestSharp.Method.Post)
                .DeserializeData<PostResponseModel>();


            Assert.That(response.name.Equals("morpheus"), Is.EqualTo(true));
            Assert.IsTrue(response.job == "leader");
            Assert.That(response.id != null);
            Assert.That(response?.createdAt != null);
        }
    }
}
