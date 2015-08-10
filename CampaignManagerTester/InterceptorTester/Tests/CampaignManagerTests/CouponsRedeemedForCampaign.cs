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
    class CouponsRedeemedForCampaign
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void couponRedeemedHappyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionKey = TestGlobals.sessionKey;
            string slug = TestGlobals.slug;
            string redeemedDate = TestGlobals.redeemedDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/dwh/CouponRedeemed?"
            + "slug=" + slug + "&"
            + "redeemedDate=" + redeemedDate, null);

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET,client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }
    }
}
