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
            string sessionId = TestGlobals.sessionId;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }

        //TODO: Do this when API is legible
        [Test()]
        public static void putHappyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionId = TestGlobals.sessionId;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }

        [Test()]
        public static void deleteHappyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionId = TestGlobals.sessionId;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.DELETE));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("204", HTTPSCalls.result.Value.ToString());
        }
    }
}
