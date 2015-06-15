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
    class CouponIssuedForCampaign
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
            string issuedDate = TestGlobals.issuedDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/dwh/CouponsIssued?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId + "&"
            + "slug=" + slug + "&"
            + "issuedDate=" + issuedDate, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }
    }
}
