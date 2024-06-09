namespace SpecflowApiMayBatch.StepDefinitions
{
    [Binding]
    public class ApiTaskResolutionStepDefinitions : ApiRequest
    {
        string getAllProductsEndPoint;
        string createNewUserEndPoint;
        ProductListResponseModel actual;
        CreateUserResponseModel newUserActualResponse;

        [Given(@"I have a product resource")]
        public void GivenIHaveAProductResource()
        {
            getAllProductsEndPoint = GetProductList;
        }

        [When(@"I request product list")]
        public void WhenIRequestProductList()
        {
            string flag = "ProductList";
            var response = 
                GetRequest<ProductListResponseModel>(flag,
                    getAllProductsEndPoint, RestSharp.Method.Get);
            actual = response.DeserializeData<ProductListResponseModel>();
        }

        [Then(@"response includes theh following:")]
        public void ThenResponseIncludesThehFollowing(Table table)
        {
            var tableList = table.CreateSet<ProductTableModel>();

            tableList.Zip(actual.products, (tableItem, actualProduct) => new { tableItem, actualProduct })
                .ToList()
                .ForEach(pair =>
                {
                    Assert.That(pair.tableItem.id, Is.EqualTo(pair.actualProduct.id));
                    Assert.That(pair.tableItem.name, Is.EqualTo(pair.actualProduct.name));
                    Assert.That(pair.tableItem.price, Is.EqualTo(pair.actualProduct.price));
                    Assert.That(pair.tableItem.brand, Is.EqualTo(pair.actualProduct.brand));
                    Assert.That(pair.tableItem.usertype, Is.EqualTo(pair.actualProduct.category.usertype.usertype));
                    Assert.That(pair.tableItem.category, Is.EqualTo(pair.actualProduct.category.category));
                });

            //for (int i = 0; i < tableList.Count(); i++)
            //{
            //    Assert.That(tableList.ElementAt(i).id, 
            //        Is.EqualTo(actual.products.ElementAt(i).id));
            //    Assert.That(tableList.ElementAt(i).name, 
            //        Is.EqualTo(actual.products.ElementAt(i).name));
            //    Assert.That(tableList.ElementAt(i).price,
            //        Is.EqualTo(actual.products.ElementAt(i).price));
            //    Assert.That(tableList.ElementAt(i).brand, 
            //        Is.EqualTo(actual.products.ElementAt(i).brand));
            //    Assert.That(tableList.ElementAt(i).usertype,
            //        Is.EqualTo(actual.products.ElementAt(i).category.usertype.usertype));
            //    Assert.That(tableList.ElementAt(i).category,
            //        Is.EqualTo(actual.products.ElementAt(i).category.category));
            //}
        }

        [Given(@"I have new user product resource")]
        public void GivenIHaveNewUserProductResource()
        {
            createNewUserEndPoint = CreateNewUser;
        }

        [When(@"I request to create new user with the following parameters:")]
        public void WhenIRequestToCreateNewUserWithTheFollowingParameters(Table table)
        {
            var param = new Dictionary<string, string>();

            foreach (var key in table.Header)
            {
                var value =
                    table.Rows[0][key];
                var updatedEmail = key == "email" 
                    ? string.Format(value, new Random().Next(1, 999))
                    : key;
                var updatedValue = key == "email" ? updatedEmail : value;
                param.Add(key, updatedValue);
            }

            string flag = "CreateNewUserAutomationExcercise";
           var response = PostRequest<CreateUserResponseModel>(
                    flag,
                    createNewUserEndPoint, null, param, RestSharp.Method.Post);
            newUserActualResponse = response.DeserializeData<CreateUserResponseModel>();
        }

        [Then(@"the response code is (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponseCode)
        {
            newUserActualResponse = JsonConvert.DeserializeObject<CreateUserResponseModel>(response.Content);
            Assert.That((int)newUserActualResponse.responseCode, Is.EqualTo(expectedResponseCode));
        }

        [Then(@"The response message is '([^']*)'")]
        public void ThenTheResponseMessageIs(string expectedMessage)
        {
            Assert.That(newUserActualResponse.message, Is.EqualTo(expectedMessage));
        }
    }
}
