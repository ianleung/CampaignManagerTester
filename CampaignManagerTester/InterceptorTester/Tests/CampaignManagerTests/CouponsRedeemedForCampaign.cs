using ConsoleApplication1;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void happyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionKey = TestGlobals.sessionKey;
            string slug = TestGlobals.slug;
            string redeemedDate = TestGlobals.redeemedDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/dwh/CouponRedeemed?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionKey=" + sessionKey + "&"
            + "slug=" + slug + "&"
            + "redeemedDate=" + redeemedDate, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }
    }
}
