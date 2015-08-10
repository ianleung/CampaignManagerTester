using ConsoleApplication1;
using InterceptorTester.Tests.AdminTests;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorTester.Tests.CampaignManagerTests
{
    [TestFixture()]
    class CampaignRedemptions
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void campaignRedemptionHappyPath()
        {
            //int;
            string orgId = TestGlobals.orgId.ToString();
            string timeFilter = TestGlobals.timeFilter;
            string startDate = TestGlobals.startDate;
            string endDate = TestGlobals.endDate;

            string query = "/dwh/Redemptions?"
            + "orgId=" + orgId + "&"
            + "timeFilter=" + timeFilter + "&"
            + "startdate=" + startDate + "&"
            + "enddate=" + endDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, query, null);

            Console.WriteLine(query.ToString());

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }
    }
}
