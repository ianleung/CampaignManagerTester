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
    class CampaignObject
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();

        }

        [Test()]
        public static void getHappyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
			string sessionKey = TestGlobals.sessionKey;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/?"
            + "applicationKey=" + TestGlobals.applicationKey + "&"
            + "sessionKey=" + TestGlobals.sessionKey, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }

        //TODO: Do this when API is legible
        [Test()]
        public static void putHappyPath()
        {
            //Setup strings
            

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns?"
            + "applicationKey=" + TestGlobals.applicationKey + "&"
            + "sessionKey=" + TestGlobals.sessionKey, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }

        [Test()]
        public static void removeHappyPath()
        {
            //Setup strings
            
			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/" + TestGlobals.campaignId+ "?"
            + "applicationKey=" + TestGlobals.applicationKey + "&"
			+ "orgId=" + TestGlobals.orgIdWithCampSignedUp + "&"
            + "sessionKey=" + TestGlobals.sessionKey, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.DELETE));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("204", statusCode);
        }
    }
}
