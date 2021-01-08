using System.IO;
using System.Threading.Tasks;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using aws;

namespace FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public async Task Test_RunAsync_Get()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ValuesController-RunAsync_Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Headers"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Origin"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Methods"));
            Assert.Equal("Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token", response.MultiValueHeaders["Access-Control-Allow-Headers"][0]);
            Assert.Equal("*", response.MultiValueHeaders["Access-Control-Allow-Origin"][0]);
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }

        [Fact]
        public async Task Test_Run_Get()
        {
            var lambdaFunction = new LambdaEntryPoint();

            var requestStr = File.ReadAllText("./SampleRequests/ValuesController-Run_Get.json");
            var request = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var context = new TestLambdaContext();
            var response = await lambdaFunction.FunctionHandlerAsync(request, context);

            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Headers"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Origin"));
            Assert.True(response.MultiValueHeaders.ContainsKey("Access-Control-Allow-Methods"));
            Assert.Equal("Content-Type,X-Amz-Date,Authorization,X-Api-Key,X-Amz-Security-Token", response.MultiValueHeaders["Access-Control-Allow-Headers"][0]);
            Assert.Equal("*", response.MultiValueHeaders["Access-Control-Allow-Origin"][0]);
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }
    }
}
