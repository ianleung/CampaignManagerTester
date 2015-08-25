using ConsoleApplication1;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using InterceptorTester.Tests.AdminTests;

namespace InterceptorTester.Tests.CampaignManagerTests
{
    /*
    [TestFixture()]
    class CouponIssuedForCampaign
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void couponIssuedHappyPath()
        {
            //Setup strings
            string slug = TestGlobals.slug;
            string issuedDate = TestGlobals.issuedDate;

			string query = "/api/dwh/CouponsIssued?"
			               + "slug=" + slug + "&"
			               + "issuedDate=" + issuedDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, query, null);

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET,client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }
    }
    */
}
