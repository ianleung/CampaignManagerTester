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
    class OrgDetails
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void detailsHappyPath()
        {
            //Setup strings
            string id = TestGlobals.orgId.ToString();
            string applicationKey = TestGlobals.applicationKey;
            string sessionId = TestGlobals.sessionId;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Organizations?"
            + "id=" + id + "&"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }

        [Test()]
        public static void updateHappyPath()
        {
            //Setup strings
            string id = TestGlobals.orgId.ToString();
            string applicationKey = TestGlobals.applicationKey;
            string sessionId = TestGlobals.sessionId;

            ConsoleApplication1.OrgUpdateJSON json = new ConsoleApplication1.OrgUpdateJSON();
            json.defaultTermsAndConditions = "Termzan Condit Ions";
            json.id = "1124";
            json.logoUrl = "http://zombo.com";
            json.name = "Umbra";
            json.privacyPolicy = "stuff";

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Organizations?"
            + "id=" + id + "&"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId, json);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }
    }
}
