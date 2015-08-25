using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Configuration;
using Nito.AsyncEx;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ConsoleApplication1;
using InterceptorTester.Tests.AdminTests;

namespace InterceptorTester.Tests.CampaignManagerTests
{
    /*
    [TestFixture()]
    class DailySubscriptions
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void dailySubHappyPath()
        {
            //int;
            string orgId = TestGlobals.orgId.ToString();
            string timeFilter = TestGlobals.timeFilter;
            string startDate = TestGlobals.startDate;
            string endDate = TestGlobals.endDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/api/dwh/SubscriptionsDaily?"
            + "orgId=" + orgId + "&"
            + "timeFilter=" + timeFilter + "&"
            + "startdate=" + startDate + "&"
            + "enddate=" + endDate, null);

			Test mTest = new Test(request);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }
    }
     */
}
