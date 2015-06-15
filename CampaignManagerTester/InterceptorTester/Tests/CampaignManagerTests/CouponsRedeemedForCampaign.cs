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
            string sessionId = TestGlobals.sessionId;
            string slug = TestGlobals.slug;
            string redeemedDate = TestGlobals.redeemedDate;

            GenericRequest request = new GenericRequest(TestGlobals.adminServer, "/dwh/CouponRedeemed?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId + "&"
            + "slug=" + slug + "&"
            + "redeemedDate=" + redeemedDate, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }
    }
}
